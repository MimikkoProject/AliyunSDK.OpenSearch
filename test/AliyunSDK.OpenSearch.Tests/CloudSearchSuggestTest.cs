using AliCloudOpenSearch.com.API;
using Xunit;

namespace AliCloudAPITest
{
    
    public class CloudSearchSuggestTest : CloudSearchApiAliyunBase
    {
#if DEBUG
        [Fact]
        public void testGetSuggest()
        {
            var suggest = new CloudsearchSuggest(ApplicationName, "suggest1", api);
            var result = suggest.GetSuggest("云", 5);


            Assert.NotNull(result);
        }
#endif
    }
}