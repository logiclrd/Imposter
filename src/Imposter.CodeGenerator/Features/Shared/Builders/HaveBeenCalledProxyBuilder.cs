using Imposter.CodeGenerator.SyntaxHelpers;
using Imposter.CodeGenerator.SyntaxHelpers.Builders;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq.Expressions;
using static Imposter.CodeGenerator.SyntaxHelpers.SyntaxFactoryHelper;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Imposter.CodeGenerator.Features.Shared.Builders;

internal static class HaveBeenCalledProxyBuilder
{
    public static ClassDeclarationSyntax Build(in TypeSyntax ownerType, in NameSyntax verifierInterfaceType)
    {
        var parameterName = Identifier("owner");
        var localName = Identifier("_owner");

        var ownerParameter = Parameter(parameterName).WithType(ownerType);

        return ClassDeclaration(HaveBeenCalledProxyMetadata.Name)
            .AddBaseListTypes([
                SimpleBaseType(verifierInterfaceType)
            ])
            .AddMembers([
                SingleVariableField(ownerType, localName),
                new ConstructorBuilder(HaveBeenCalledProxyMetadata.Name)
                    .WithModifiers(TokenList(Token(SyntaxKind.InternalKeyword)))
                    .AddParameter(ownerParameter)
                    .WithBody(
                        new BlockBuilder()
                            .AddStatement(
                                ExpressionStatement(
                                    AssignmentExpression(
                                        SyntaxKind.SimpleAssignmentExpression,
                                        IdentifierName(localName),
                                        IdentifierName(parameterName))
                            ))
                            .Build()
                    )
                    .Build(),
                new MethodDeclarationBuilder(WellKnownTypes.Void, HaveBeenCalledMethodMetadata.Name)
                .AddParameter(
                    ParameterSyntax(
                        HaveBeenCalledMethodMetadata.CountParameter.Type,
                        HaveBeenCalledMethodMetadata.CountParameter.Name
                    )
                )
                .WithExplicitInterfaceSpecifier(
                    ExplicitInterfaceSpecifier(verifierInterfaceType)
                )
                .WithExpressionBody(
                    ArrowExpressionClause(
                        InvocationExpression(
                            MemberAccessExpression(
                                Microsoft.CodeAnalysis.CSharp.SyntaxKind.SimpleMemberAccessExpression,
                                IdentifierName(localName),
                                IdentifierName(HaveBeenCalledMethodMetadata.Name)
                            ),
                            ArgumentList([
                                Argument(IdentifierName(HaveBeenCalledMethodMetadata.CountParameter.Name))
                            ])
                        )
                    )
                )
                .WithSemicolon()
                .Build()
            ]);
    }
}
