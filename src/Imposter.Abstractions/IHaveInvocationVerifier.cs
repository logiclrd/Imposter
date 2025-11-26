namespace Imposter.Abstractions;

/// <summary>
/// Defines a contract for exposing the verifier for a method imposter group.
/// </summary>
/// <typeparam name="TVerifier">The type of the verifier.</typeparam>
/// <remarks>
/// Generated method imposter groups derive from <see cref="HaveInvocationVerifier{TVerifier}"/>,
/// which implements this interface, so test code can verify that expected calls did or did not
/// occur.
/// </remarks>
public interface IHaveInvocationVerifier<out TVerifier>
    where TVerifier : class
{
    /// <summary>
    /// Gets the associated verifier.
    /// </summary>
    TVerifier Should();
}
