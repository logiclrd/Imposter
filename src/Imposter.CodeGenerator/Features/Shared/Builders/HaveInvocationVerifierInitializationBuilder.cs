using Imposter.Abstractions;
using Imposter.CodeGenerator.SyntaxHelpers;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Reflection.Metadata;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Imposter.CodeGenerator.Features.Shared.Builders;

internal static class HaveInvocationVerifierInitializationBuilder
{
    internal static StatementSyntax Build()
    {
        return InvocationExpression(
            MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                BaseExpression(),
                IdentifierName(nameof(HaveInvocationVerifier<string>.InitializeInvocationVerifier))
            ),
            ArgumentList([
                Argument(
                    ObjectCreationExpression(
                        IdentifierName(HaveBeenCalledProxyMetadata.Name),
                        ArgumentList([
                            Argument(ThisExpression())
                        ]),
                        initializer: null
                    )
                )
            ])
        ).ToStatementSyntax();
    }
}
