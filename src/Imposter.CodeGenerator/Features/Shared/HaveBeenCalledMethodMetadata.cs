using Imposter.CodeGenerator.SyntaxHelpers;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Imposter.CodeGenerator.Features.Shared;

internal static class HaveBeenCalledMethodMetadata
{
    internal const string Name = "HaveBeenCalled";

    internal static readonly TypeSyntax ReturnType = WellKnownTypes.Void;

    internal static readonly ParameterMetadata CountParameter =
        new ParameterMetadata("count", WellKnownTypes.Imposter.Abstractions.Count);
}
