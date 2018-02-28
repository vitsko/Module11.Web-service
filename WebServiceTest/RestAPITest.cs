namespace WebServiceTest
{
    using System;
    using System.Net;
    using Assert;
    using HttpUtil;
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class RestAPITest
    {
        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void VerifyStatusCode()
        {
            var response = RestAPIUtil.GetResponse(Config.UrlToJSON);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK, Resource.IncorrectStatusCode);
        }

        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void VerifyHTTPResponseHeader()
        {
            var response = RestAPIUtil.GetResponse(Config.UrlToJSON);

            var contentTypeOfResponse = response.GetResponseHeader("Content-Type");

            var softAssert = new SoftAssertions();

            softAssert.That(!string.IsNullOrWhiteSpace(contentTypeOfResponse), Resource.ContentTypeIsNull);
            softAssert.That(contentTypeOfResponse.Equals(Resource.ValueOfContentType, StringComparison.InvariantCultureIgnoreCase), string.Format(Resource.IncorrectContentType, Resource.ValueOfContentType));
            softAssert.AssertAll();
        }

        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void VerifyHTTPResponseBody()
        {
            var json = RestAPIUtil.GetResponseBody(Config.UrlToJSON);
            JArray jsonObjects = JArray.Parse(json);

            Assert.IsTrue(jsonObjects.Count == int.Parse(Config.CountOfUsers), Resource.IncorectCountofUserInJSON);
        }
    }
}