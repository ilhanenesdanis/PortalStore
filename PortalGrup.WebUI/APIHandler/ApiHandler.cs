using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace PortalGrup.WebUI.APIHandler
{
    public class ApiHandler : IApiHandler
    {
        public T GetApi<T>(string url)
        {
            try
            {
                var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.Method = "GET";
                httpRequest.ContentType = "application/json";
                var response = httpRequest.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var result = reader.ReadToEnd();
                    var model = JsonConvert.DeserializeObject<T>(result);
                    response.Close();
                    return model;
                }
            }
            catch (Exception ex)
            {

                throw new NotImplementedException();
            }
        }

        public T PostApi<T>(dynamic dynamicModel, string Url)
        {
            try
            {
                var httpRequest = (HttpWebRequest)WebRequest.Create(Url);
                httpRequest.Method = "POST";
                httpRequest.ContentType = "application/json";
                string JsonData = JsonConvert.SerializeObject(dynamicModel);
                byte[] byteArray = Encoding.UTF8.GetBytes(JsonData);
                httpRequest.ContentLength = byteArray.Length;
                Stream dataStream = httpRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                var response = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    T model = JsonConvert.DeserializeObject<T>(result);
                    response.Close();
                    return model;
                }
            }
            catch (Exception ex)
            {

                throw new NotImplementedException();
            }
        }

        public string PostApiString(dynamic dynamicModel, string Url)
        {
            try
            {
                var httpRequest = (HttpWebRequest)WebRequest.Create(Url);
                httpRequest.Method = "POST";
                httpRequest.ContentType = "application/json";
                string JsonData = JsonConvert.SerializeObject(dynamicModel);
                byte[] byteArray = Encoding.UTF8.GetBytes(JsonData);
                httpRequest.ContentLength = byteArray.Length;
                Stream dataStream = httpRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                var response = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
