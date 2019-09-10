﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace MathSharp.UnitTests.VectorTests.VectorSingle.BasicMathsTests
{
    public class Remainder
    {
        public static IEnumerable<object[]> Data =>
            new[]
            {
                new object[] { new Vector4(10.4f), new Vector4(2f) },
                new object[] { new Vector4(-10.4f), new Vector4(2f) },
                new object[] { new Vector4(float.NaN, float.MinValue, float.MaxValue, float.PositiveInfinity), new Vector4(3f) },
                new object[] { new Vector4(float.NaN, float.MinValue, float.MaxValue, float.PositiveInfinity), new Vector4(2.4f) },
                new object[] { new Vector4(23.45f), new Vector4(219f) },
                new object[] { new Vector4(12), new Vector4(float.NaN) },
                new object[] { new Vector4(-10000000f), new Vector4(2.2f) },
                new object[] { new Vector4(10000000f), new Vector4(2.2f) },
                new object[] { new Vector4(float.NegativeInfinity), new Vector4(3f) }
            };

        [Theory]
        [MemberData(nameof(Data))]
        public void Remainder_Theory(Vector4 left, Vector4 right)
        {
            var l = Vector.Load(left);
            var r = Vector.Load(right);

            var remainder = Vector.Remainder(l, r);
            var expected = new Vector4(left.X % right.X, left.Y % right.Y, left.Z % right.Z, left.W % right.W);

            TestHelpers.AreEqual(expected, remainder);
        }
    }
}
