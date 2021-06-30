using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Essentials;

namespace TestLogicalData.Helpers
{
    public static class Utils
    {
        public static string serverToken = "AAAAEo1wwKc:APA91bEBIiOACsqHPBWkX1kXSWTmCoKE5zjdXNt8nWhy5a2eDGEaP--ZsexoEH_0jc03DdUsQRRqlK7ZLmGYX6Ro-96JuIgLKB-6ZJXTAxbjAnFrIUi993XPRu4qix_T7cLCRZRQWI-0";
        /// <summary>
        /// Realiza una consulta HTTP mediante POST. returna un string con la respuesta obtenida, la cual debe ser deserializada en formato JSON.
        /// </summary>
        /// <param name="pUrlConsulta"> string de URL en donde se debe realizar la consulta</param>
        /// <param name="pRequestBody">Request de la consulta. Debe ser un JSON serializado en formato string. Si no se envian parametros, se puede enviar NULL o String.Empty</param>
        /// <returns>Un string de la respuesta, debe ser deserializado en JSON.</returns>
        public async static System.Threading.Tasks.Task<string> ConsultaHttpPost(string pUrlConsulta, string pRequestBody)
        {
            try
            {
                //NOTA: El pRequestBody debe ser una entidad serializada por JSON. EJEM: JsonConvert.SerializeObject(pRequestBody);
                if (pRequestBody == null)
                    pRequestBody = string.Empty;

                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, pUrlConsulta);
                request.Headers.Add(System.Net.HttpRequestHeader.Accept.ToString(), "application/json");
                request.Headers.TryAddWithoutValidation(System.Net.HttpRequestHeader.Authorization.ToString(), $"key={serverToken}");
                request.Content = new StringContent(pRequestBody, Encoding.UTF8, "application/json");

                return  await client.SendAsync(request).Result.Content.ReadAsStringAsync();
                
                //NOTA: La respuesta despues de ser obtenida, debe ser deserializada por JSON, junto con la entidad en la que se debe guardar. EJEM: JsonConvert.DeserializeObject<entidadRes>(response.Result);
            }
            catch (Exception)
            {
                throw;
            }
        }//FIN: ConsultaHttpPost()
    }
}
