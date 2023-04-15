using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace WriteDownOnlineApi.Infra.CrossCutting.Http
{
    public static class ClientHttp
    {
        public static T PostAsync<T>(string url, dynamic content, string token, int secondsTimeout = 15)
        {
            var data = JsonConvert.SerializeObject(content);
            var contentData = new StringContent(data, Encoding.UTF8, "application/json");

            using var client = new HttpClient();
            HttpResponseMessage retorno;
            if (token != null)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.Timeout = TimeSpan.FromSeconds(secondsTimeout);
                retorno = client.PostAsync(new Uri(url), contentData).Result;
                var str = retorno.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(str.Result);
            }

            retorno = client.PostAsync(new Uri(url), contentData).Result;
            return JsonConvert.DeserializeObject<T>(retorno.Content.ReadAsStringAsync().Result);
        }

        public static T GetAsync<T>(string url, string token)
        {
            using var client = new HttpClient();
            HttpResponseMessage retorno;
            if (!string.IsNullOrWhiteSpace(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.Timeout = TimeSpan.FromSeconds(15);
                retorno = client.GetAsync(new Uri(url)).Result;
                string json = retorno.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(json);
            }

            retorno = client.GetAsync(new Uri(url)).Result;
            return JsonConvert.DeserializeObject<T>(retorno.Content.ReadAsStringAsync().Result);
        }
    }
}
