using Xunit.Abstractions;

namespace WatchShopTest.Utilities
{
    public class TestCollectionOrderer : ITestCollectionOrderer
    {
        public IEnumerable<ITestCollection> OrderTestCollections(IEnumerable<ITestCollection> testCollections)
        {
            return testCollections.OrderBy(tc => tc.DisplayName);
        }
    }
}
