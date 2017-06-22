using AliCloudOpenSearch.com.API;
using Xunit;

namespace AliCloudAPITest
{
    
    public class DeserializeToModalTest
    {
        [Fact]
        public void TestResponseDeserialize()
        {
            var json = "{'status':'OK','request_id':'1422348642065805100373587'}";

            var deserializedObj = Utilities.ConvertResult(json);

            Assert.Equal("OK", deserializedObj.Status);
            Assert.Equal("1422348642065805100373587", deserializedObj.RequestId);
        }

        [Fact]
        public void TestResponseDeserializeWithErrors()
        {
            var json =
                "{'status':'FAIL','errors':[{'code':4012,'message':'Table dose not exist'}],'request_id':'1422348739084222300234072'}";

            var deserializedObj = Utilities.ConvertResult(json);

            Assert.Equal("FAIL", deserializedObj.Status);
            Assert.Equal("1422348739084222300234072", deserializedObj.RequestId);
            Assert.NotNull(deserializedObj.Errors);
            Assert.Equal(1, deserializedObj.Errors.Length);
            Assert.Equal("4012", deserializedObj.Errors[0].Code);
            Assert.Equal("Table dose not exist", deserializedObj.Errors[0].Message);
        }
    }
}