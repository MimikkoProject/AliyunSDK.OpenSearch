using AliCloudOpenSearch.com.API.Builder;
using Xunit;

namespace AliCloudAPITest
{
    
    public class FilterTest
    {
        [Fact]
        public void Test1()
        {
            var filter = new Filter("filed1=a");
            Assert.Equal("filed1=a", ((IBuilder) filter).BuildQuery());

            filter.And(new Filter("field2>3"));
            Assert.Equal("filed1=a AND (field2>3)", ((IBuilder) filter).BuildQuery());

            filter.Or(new Filter("field2<-1"));
            Assert.Equal("filed1=a AND (field2>3) OR (field2<-1)", ((IBuilder) filter).BuildQuery());
        }
    }
}