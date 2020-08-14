using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace FormSigmaDevelopers.Utils
{
    public class ConsumirApiRest
    {
        /// <summary>
        /// Permite consumir un servicio POST que devuelva un JObject
        /// </summary>
        /// <param name="url"></param>
        /// <param name="datosEntrada"></param>
        /// <returns>devuelve salida en Jobject</returns>
        public static async Task<JObject> ConsumirApiSalidaJObject(string url, JObject datosEntrada, string Metodo = "POST")
        {
            JObject result = new JObject();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = Metodo;

            if (Metodo.Equals("POST"))
            {
                using (var streamWriter = new StreamWriter(await httpWebRequest.GetRequestStreamAsync()))
                {
                    streamWriter.Write(datosEntrada.ToString());
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }
            var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
            if (httpResponse.StatusDescription == "OK" || httpResponse.StatusCode.ToString() == "OK")
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = JObject.Parse(await streamReader.ReadToEndAsync());

                }
            }

            return result;
        }

    }
}
