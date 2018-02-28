namespace HttpUtil
{
    using System.IO;
    using System.Net;
    using System.Text;

    public class RestAPIUtil
    {
        public static HttpWebResponse GetResponse(string url)
        {
            var request = WebRequest.Create(url);
            request.Method = "GET";

            return (HttpWebResponse)request.GetResponse();
        }

        public static string GetResponseBody(string url)
        {
            string body = string.Empty;

            var response = RestAPIUtil.GetResponse(url);

            using (StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                body = myStreamReader.ReadToEnd();
            }

            return body;
        }
    }
}