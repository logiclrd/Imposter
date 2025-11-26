using Imposter.CodeGenerator.SyntaxHelpers;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Imposter.CodeGenerator.Features.PropertyImpersonation.Metadata.SetterImposter;

internal readonly struct InvocationCountMetadata
{
    internal readonly ParameterMetadata CriteriaParameter;

    internal readonly string InvocationCountVariableName = "invocationCount";

    internal InvocationCountMetadata(in ImposterPropertyCoreMetadata property)
    {
        CriteriaParameter = new ParameterMetadata("criteria", property.AsArgType);
    }
}
