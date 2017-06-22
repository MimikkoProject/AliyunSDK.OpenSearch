﻿using System;
using AliCloudOpenSearch.com.API;
using Xunit;

namespace AliCloudAPITest
{
    /// <summary>
    ///     这是 CloudSearchIndexTest 的测试类，旨在
    ///     包含所有 CloudSearchIndexTest 单元测试
    /// </summary>
    public class CloudSearchAnalysisTest : CloudSearchApiAliyunBase
    {
        [Fact]
        public void testTopQuery()
        {
            var css = new CloudsearchAnalysis("hotel", mockApi);
            var result = css.GetTopQuery(100, 100);
            AssertEqualFromQueryString("num", "100", result);
            AssertEqualFromQueryString("days", "100", result);
        }
    }
}