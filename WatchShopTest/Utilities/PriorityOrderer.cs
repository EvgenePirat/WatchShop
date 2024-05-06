using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace WatchShopTest.Utilities
{
    public class PriorityOrderer : ITestCaseOrderer
    {
        public const string Name = "PriorityOrderer";
        public const string Assembly = "Your.Assembly.Name";

        public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases)
            where TTestCase : ITestCase
        {
            var sortedTestCases = new SortedDictionary<int, List<TTestCase>>();

            foreach (var testCase in testCases)
            {
                var priority = 0;

                foreach (var attr in testCase.TestMethod.Method.GetCustomAttributes(typeof(PriorityAttribute).AssemblyQualifiedName))
                {
                    priority = attr.GetNamedArgument<int>("Priority");
                    break;
                }

                if (!sortedTestCases.ContainsKey(priority))
                    sortedTestCases.Add(priority, new List<TTestCase>());

                sortedTestCases[priority].Add(testCase);
            }

            foreach (var priorityGroup in sortedTestCases.Keys)
                foreach (var testCase in sortedTestCases[priorityGroup])
                    yield return testCase;
        }
    }
}
