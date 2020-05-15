using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MalkiaMVVM.Persistency
{
    class GenericWebApiServices<T> where T : class, new()
    {
        HttpClientHandler handler;
        HttpClient client;
        string _url;
        const string serverURL = "http://localhost:59561/";
        public GenericWebApiServices( string url)
        {
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true; // to make sure that the default credential are sent by the request
                                                  // below we r going to create our Http client inside a using statement
            client = new HttpClient(handler);
            client.BaseAddress = new Uri(serverURL);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _url = url;
        }

        public List<T> getAll() 
        {

            using (client)
            {

                try
                {
                    string s = _url;
                    var response = client.GetAsync(_url).Result;
                    response.EnsureSuccessStatusCode();
                    string data = response.Content.ReadAsStringAsync().Result;
                    List<T> cList = JsonConvert.DeserializeObject<List<T>>(data);
                    return cList;
                }

                catch (Exception ex)
                {
                    return new List<T>();
                }
            }

        }

        public async void createNewOne(T obj)
        {
            using (client)
            {
                try
                {
                    string data = JsonConvert.SerializeObject(obj);
                    StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(_url, content);
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public T deleteOne(int id)
        {
            using (client)
            {
                try
                {

                    string newURL = _url + "/" + id;
                    var response = client.DeleteAsync(newURL).Result;
                    response.EnsureSuccessStatusCode();
                    string data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<T>(data);
                }
                catch (Exception ex)
                {
                    return new T();
                }
            }
        }

        public async void updateOne(int id, T obj)
        {
            using (client)
            {
                try
                {
                    string newURL = _url + "/" + id;
                    string data = JsonConvert.SerializeObject(obj);
                    StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                    var response = await client.PutAsync(newURL, content);
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }



        }

    }
}
