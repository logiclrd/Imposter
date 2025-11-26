using Imposter.CodeGenerator.SyntaxHelpers;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Imposter.CodeGenerator.Features.Shared;

internal readonly struct HaveBeenCalledProxyMetadata
{
    internal const string Name = HaveBeenCalledMethodMetadata.Name + "Proxy";

    internal static readonly TypeSyntax Syntax = SyntaxFactory.IdentifierName(Name);

    public HaveBeenCalledProxyMetadata()
    {
    }
}
