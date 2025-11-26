using Imposter.Abstractions;
using Imposter.Tests.Features.Docs.Methods.Verification;
using Shouldly;
using Xunit;

[assembly: GenerateImposter(typeof(IVerifyService))]

namespace Imposter.Tests.Features.Docs.Methods.Verification
{
    public interface IVerifyService
    {
        void Increment(int v);
        int Combine(int a, int b);
    }

    public class VerificationTests
    {
        [Fact]
        public void GivenVerificationScenarios_WhenCountingCalls_ShouldHonorBasicCounts()
        {
            var imposter = new IVerifyServiceImposter();
            var service = imposter.Instance();

            service.Increment(1);
            service.Increment(2);

            Should.NotThrow(() => imposter.Increment(Arg<int>.Any()).Should().HaveBeenCalled(Count.AtLeast(2)));
            Should.NotThrow(() => imposter.Increment(2).Should().HaveBeenCalled(Count.Once()));
        }

        [Fact]
        public void GivenVerificationScenarios_WhenMatchingArguments_ShouldRespectArgumentMatchers()
        {
            var imposter = new IVerifyServiceImposter();
            var service = imposter.Instance();

            // Exercise some calls
            for (int i = 0; i < 3; i++)
                service.Increment(11);
            service.Combine(2, 5);

            Should.NotThrow(() =>
                imposter.Increment(Arg<int>.Is(x => x > 10)).Should().HaveBeenCalled(Count.Exactly(3))
            );
            Should.NotThrow(() =>
                imposter
                    .Combine(Arg<int>.Is(x => x > 0), Arg<int>.Is(y => y < 10))
                    .Should().HaveBeenCalled(Count.Once())
            );
        }

        [Fact]
        public void GivenVerificationScenarios_WhenUsingCountHelpers_ShouldApplyCountConstraints()
        {
            var imposter = new IVerifyServiceImposter();
            var service = imposter.Instance();

            service.Increment(1);
            service.Increment(2);
            service.Increment(2);

            Should.NotThrow(() => imposter.Increment(Arg<int>.Any()).Should().HaveBeenCalled(Count.AtLeast(3)));
            Should.NotThrow(() => imposter.Increment(2).Should().HaveBeenCalled(Count.Exactly(2)));
            Should.NotThrow(() => imposter.Increment(1).Should().HaveBeenCalled(Count.Once()));
            Should.NotThrow(() => imposter.Increment(999).Should().HaveBeenCalled(Count.Never()));
            Should.NotThrow(() => imposter.Increment(Arg<int>.Any()).Should().HaveBeenCalled(Count.Any));
        }
    }
}
