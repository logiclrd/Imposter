using System.ComponentModel;

namespace Imposter.Abstractions;

/// <summary>
/// Provides a common implementation for method imposter groups to return verifiers.
/// </summary>
/// <typeparam name="TVerifier">The type of the verifier.</typeparam>
/// <remarks>
/// Generated method imposter groups derive from this type to provide a <code>.Should()</code>
/// method that test code can use to verify that expected calls did or did not occur.
/// </remarks>
public class HaveInvocationVerifier<TVerifier> : IHaveInvocationVerifier<TVerifier>
    where TVerifier : class
{
    TVerifier? _verifier;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="verifier"></param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void InitializeInvocationVerifier(TVerifier verifier)
    {
        _verifier = verifier;
    }

    /// <summary>
    /// Gets the associated verifier.
    /// </summary>
    public TVerifier Should() => _verifier!;
}
