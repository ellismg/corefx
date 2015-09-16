// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Reflection;
using Xunit;

namespace System.Globalization.Tests
{
    public class CalendarData
    {
        private static readonly Type calendarDataType = Type.GetType("System.Globalization.CalendarData");
        private static readonly MethodInfo normalizeDatePattern = calendarDataType.GetTypeInfo().GetDeclaredMethod("NormalizeDatePattern");

        [Theory]
        [PlatformSpecific(PlatformID.AnyUnix)]
        [InlineData("'EEEE '' LLL' y", "'EEEE '' LLL' yyyy")]
        [InlineData("EEEE, d MMMM y", "dddd, d MMMM yyyy")]
        [InlineData("ee, d LLLLL", "ddd, d MMM")]
        [InlineData("ccccc, d", "ddd, d")]
        [InlineData("GG yy/M/d", "g yy/M/d")]
        public static void TestNormalizeDatePattern(string input, string expected)
        {
            string actual = (string)normalizeDatePattern.Invoke(null, new object[] { input });
            Assert.Equal(expected, actual);
        }
    }
}
