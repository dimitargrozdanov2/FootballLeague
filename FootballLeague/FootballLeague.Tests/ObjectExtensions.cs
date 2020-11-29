using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FootballLeague.Tests
{
    public static class ObjectExtensions
    {
        private static readonly List<string> ignoredProps = new List<string>() { "SecurityStamp", "ConcurrencyStamp" };
        public static void AssertEqualProperties(this object left, object right, params string[] skip)
        {
            Assert.NotNull(right, "Right compare object is null");
            Assert.NotNull(left, "Left compare object is null");

            var skipPropertyList = new List<string>(skip);

            var leftProps = left.GetType().GetProperties();
            var rightProps = right.GetType().GetProperties();

            foreach (var leftProp in leftProps)
            {
                if (ignoredProps.Contains(leftProp.Name)) continue;
                if (skipPropertyList.Contains(leftProp.Name)) continue;

                var rightProp = rightProps.FirstOrDefault(p => p.Name == leftProp.Name);
                if (rightProp == null) continue;

                if (leftProp.PropertyType != rightProp.PropertyType) continue;

                var leftValue = leftProp.GetValue(left);
                var rightValue = rightProp.GetValue(right);
                if (leftProp.PropertyType.Name.ToLower() != "string" && leftValue is IEnumerable leftList && rightValue is IEnumerable rightList)
                {
                    IEnumerator leftEnumerator, rightEnumerator;
                    for (leftEnumerator = leftList.GetEnumerator(), rightEnumerator = rightList.GetEnumerator();
                        leftEnumerator.MoveNext() && rightEnumerator.MoveNext();)
                    {
                        if (leftEnumerator.Current?.GetType().Namespace != null && leftEnumerator.Current.GetType().Namespace.StartsWith("Intent2."))
                        {
                            leftEnumerator.Current.AssertEqualProperties(rightEnumerator.Current, skip);
                        }
                        else
                            Assert.AreEqual(leftEnumerator.Current, rightEnumerator.Current, $"Object collection property mismatch: {leftProp.Name} in object {left.GetType().Name}");
                    }
                }
                else
                {
                    if (leftProp.PropertyType.Namespace != null && leftValue != null &&
                        leftProp.PropertyType.Namespace.StartsWith("Intent2."))
                    {
                        leftValue.AssertEqualProperties(rightValue, skip);
                    }
                    else
                        Assert.AreEqual(leftValue, rightValue,
                            $"Object property mismatch: {leftProp.Name} in object {left.GetType().Name}");
                }
            }
        }

        public static void CopyProperties(this object left, object right, params string[] skip)
        {
            Assert.NotNull(right, "Right compare object is null");
            Assert.NotNull(left, "Left compare object is null");

            var skipPropertyList = new List<string>(skip);

            var leftProps = left.GetType().GetProperties();
            var rightProps = right.GetType().GetProperties();

            foreach (var leftProp in leftProps)
            {
                if (ignoredProps.Contains(leftProp.Name)) continue;
                if (skipPropertyList.Contains(leftProp.Name)) continue;

                var rightProp = rightProps.FirstOrDefault(p => p.Name == leftProp.Name);
                if (rightProp == null) continue;

                rightProp.SetValue(right, leftProp.GetValue(left));
            }
        }
    }
}
