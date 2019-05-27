namespace Shop.Common.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using Models;
    using Newtonsoft.Json;
    using System.Threading.Tasks;

    public class ApiService
    {
        public async Task<Response> GetListAsync<T>(string urlBase, string servicePrefix, string controller)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };
                var url = $"{servicePrefix}{controller}";
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                //Si el codigo de respuesta no es 200:ok entonces...
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }
                //Deserializar es coger un string y volverlo Json
                //El resultado se deserializando como una lista de T
                var list = JsonConvert.DeserializeObject<List<T>>(result);
                return new Response
                {
                    IsSuccess = true,
                    Result = list
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }

}
