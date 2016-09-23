using System;
using System.Runtime.InteropServices;

using Xunit;

public static class AbortTests
{
    [Fact]
    public static void AbortTest()
    {
        Interop.Abort();
    }

    public static class Interop
    {
        [DllImport("abort")]
        public static extern void Abort();
    }
}