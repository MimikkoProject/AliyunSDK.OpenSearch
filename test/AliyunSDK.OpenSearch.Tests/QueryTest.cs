using AliCloudOpenSearch.com.API.Builder;
using Xunit;

namespace AliCloudAPITest
{
    
    public class QueryTest
    {
        [Fact]
        public void Test1()
        {
            IBuilder qry = new Query("id1:a");
            Assert.Equal("id1:a", qry.BuildQuery());

            qry = new Query("a");
            Assert.Equal("default:a", qry.BuildQuery());
        }

        [Fact]
        public void Test2()
        {
            IBuilder qry = new Query("default:a", 100);
            Assert.Equal("default:a^99", qry.BuildQuery());

            qry = new Query("default:a", -2);
            Assert.Equal("default:a^0", qry.BuildQuery());

            qry = new Query("default:a", 2);
            Assert.Equal("default:a^2", qry.BuildQuery());
        }

        [Fact]
        public void Test3()
        {
            var qry = new Query("default:a", 2);
            qry.And(new Query("index1:B"));
            Assert.Equal("default:a^2 AND (index1:B)", ((IBuilder) qry).BuildQuery());

            qry.Or(new Query("index2:B"));
            Assert.Equal("default:a^2 AND (index1:B) OR (index2:B)", ((IBuilder) qry).BuildQuery());

            qry.AndNot(new Query("index2:B"));
            Assert.Equal("default:a^2 AND (index1:B) OR (index2:B) ANDNOT (index2:B)", ((IBuilder) qry).BuildQuery());

            qry.Rank(new Query("index2:B"));
            Assert.Equal("default:a^2 AND (index1:B) OR (index2:B) ANDNOT (index2:B) RANK (index2:B)",
                ((IBuilder) qry).BuildQuery());
        }
    }
}