using PDNotifier;
using PDNotifier.Tests;
using System;
using Xunit;

namespace Autofac.Events.Tests
{
    public class PublishEventTests : UnitTests
    {
        [Fact]
        public void EventPublisherPublishes()
        {
            using (var scope = BeginScope())
            {
                var dashboard = scope.Resolve<Dashboard>();
                var policeman = scope.Resolve<PolicemanNotifier>();

                Assert.Throws<InvalidOperationException>(() => dashboard.Notify("Exception"));
            }
        }
    }
}

