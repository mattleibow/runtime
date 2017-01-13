// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Security.AccessControl;
using Xunit;

namespace System.Threading.Tests
{
    public static class ThreadingAclExtensionsTests
    {
        [Fact]
        [PlatformSpecific(TestPlatforms.Windows)]
        public static void ExistenceTest_Windows()
        {
            var e = new ManualResetEvent(true);
            var s = new Semaphore(1, 1);
            var m = new Mutex();

            e.GetAccessControl();
            e.SetAccessControl(new EventWaitHandleSecurity());
            s.GetAccessControl();
            s.SetAccessControl(new SemaphoreSecurity());
            m.GetAccessControl();
            m.SetAccessControl(new MutexSecurity());
        }

        [Fact]
        [PlatformSpecific(TestPlatforms.AnyUnix)]
        public static void ExistenceTest_Unix()
        {
            var e = new ManualResetEvent(true);
            var s = new Semaphore(1, 1);
            var m = new Mutex();

            Assert.Throws<PlatformNotSupportedException>(() => e.GetAccessControl());
            Assert.Throws<PlatformNotSupportedException>(() => e.SetAccessControl(new EventWaitHandleSecurity()));
            Assert.Throws<PlatformNotSupportedException>(() => s.GetAccessControl());
            Assert.Throws<PlatformNotSupportedException>(() => s.SetAccessControl(new SemaphoreSecurity()));
            Assert.Throws<PlatformNotSupportedException>(() => m.GetAccessControl());
            Assert.Throws<PlatformNotSupportedException>(() => m.SetAccessControl(new MutexSecurity()));
        }
    }
}
