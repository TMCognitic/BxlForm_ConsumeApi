using ConsumeApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

//using Newtonsoft.Json;

namespace ConsumeApi
{
    class Program
    {
        static void Main(string[] args)
        {
            

            #region GetCategory
            //using (HttpClient httpClient = CreateHttpClient())
            //{
            //    try
            //    {
            //        int categoryId = 4;
            //        HttpResponseMessage httpResponseMessage = httpClient.GetAsync($"api/Category/{categoryId}").Result;
            //        httpResponseMessage.EnsureSuccessStatusCode(); //lève une exception si pas de code 2xx.
            //        string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
            //        Console.WriteLine(json);
            //        Console.WriteLine();

            //        Category category = JsonSerializer.Deserialize<Category>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            //        if (category is not null)
            //        {
            //            Console.WriteLine($"{category.Id} : {category.Name}");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}
            #endregion

            #region Post
            using (HttpClient httpClient = CreateHttpClient())
            {
                try
                {
                    Category category = new Category() { Name = "Evoliris" };
                    string json = JsonSerializer.Serialize(category);

                    using (HttpContent httpContent = new StringContent(json))
                    {
                        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                        HttpResponseMessage httpResponseMessage = httpClient.PostAsync($"api/Category/", httpContent).Result;
                        httpResponseMessage.EnsureSuccessStatusCode();

                        json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                        Console.WriteLine(json);
                        Console.WriteLine();

                        category = JsonSerializer.Deserialize<Category>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                        if (category is not null)
                        {
                            Console.WriteLine("Categorie insérée...");
                            Console.WriteLine($"{category.Id} : {category.Name}");
                            Console.WriteLine();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            #endregion

            #region Put
            //using (HttpClient httpClient = CreateHttpClient())
            //{
            //    try
            //    {
            //        Category category = new Category() { Id = 5, Name = "Delta Evoliris" };
            //        string json = JsonSerializer.Serialize(category);

            //        using (HttpContent httpContent = new StringContent(json))
            //        {
            //            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //            HttpResponseMessage httpResponseMessage = httpClient.PutAsync($"api/Category/{category.Id}", httpContent).Result;
            //            httpResponseMessage.EnsureSuccessStatusCode();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}
            #endregion

            #region Delete
            //using (HttpClient httpClient = CreateHttpClient())
            //{
            //    try
            //    {
            //        int categoryId = 5;
            //        HttpResponseMessage httpResponseMessage = httpClient.DeleteAsync($"api/Category/{categoryId}").Result;
            //        httpResponseMessage.EnsureSuccessStatusCode();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}
            #endregion

            #region GetCategories
            using (HttpClient httpClient = CreateHttpClient())
            {
                try
                {
                    HttpResponseMessage httpResponseMessage = httpClient.GetAsync("api/Category").Result;
                    //=> soit
                    httpResponseMessage.EnsureSuccessStatusCode(); //lève une exception si pas de code 2xx.
                    string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(json);
                    Console.WriteLine();

                    IEnumerable<Category> categories = JsonSerializer.Deserialize<Category[]>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    //ou NewtonSoft.Json
                    //IEnumerable<Category> categories = JsonConvert.DeserializeObject<Category[]>(json);

                    foreach (Category category in categories)
                    {
                        Console.WriteLine($"{category.Id} : {category.Name}");
                    }

                    //=> ou
                    //if (httpResponseMessage.IsSuccessStatusCode) // ou test
                    //{
                    //    string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    //    Console.WriteLine(json);
                    //    Console.WriteLine();

                    //    IEnumerable<Category> categories = JsonSerializer.Deserialize<Category[]>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                    //    foreach (Category category in categories)
                    //    {
                    //        Console.WriteLine($"{category.Id} : {category.Name}");
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            #endregion
        }

        private static HttpClient CreateHttpClient()
        {
            return new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7001/")
            };
        }
    }
}
