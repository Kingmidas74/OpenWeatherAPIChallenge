using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using Newtonsoft.Json.Serialization;

namespace DataAccess
{
    public class WeatherClient
    {
        private readonly HttpClient client;
        public WeatherClient(HttpClient httpClient)
        {
            client = httpClient;
        }

        public async Task<Temperatures> GetData(double Lattitude, double Longitude, CancellationToken cancellationToken)
        {
            var generator = new JSchemaGenerator();

            var schema = generator.Generate(typeof(Temperatures));

            using(var response = await client.GetAsync($"?lat={Lattitude}&lon={Longitude}&app2id={Environment.GetEnvironmentVariable (nameof (EnvironmentVariables.API_KEY))}",cancellationToken)) 
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return (!JObject.Parse(content).IsValid(schema))
                    ? Newtonsoft.Json.JsonConvert.DeserializeObject<Temperatures>(content)
                    : throw new InvalidCastException(nameof(GetData)); 
            }
        }

    }
}
