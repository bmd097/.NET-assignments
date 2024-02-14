using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using System.Xml.Linq;

namespace UseWebAPI {
    internal class Program {
        public static void Main(string[] args) {
            try {
                string url = "http://localhost:50466/";
                var client = new RestClient(url);
                var request = new RestRequest("api/Flight");
                var response = client.ExecuteGet(request);
                Console.WriteLine(response.StatusCode);
                if (response.IsSuccessful) {
                    var data = JsonSerializer.Deserialize<JsonNode>(response.Content);
                    Console.WriteLine(data.ToString());
                }

                request = new RestRequest("api/Flight/1");
                response = client.ExecuteGet(request);
                if (response.IsSuccessful) {
                    var data = JsonSerializer.Deserialize<JsonNode>(response.Content);
                    Console.WriteLine(data.ToString());
                }

                request = new RestRequest("api/Flight");
                request.AddBody(new Dictionary<string, object> {
                    { "name","Air Asia" },
                    { "description","Flight with nice ladies!" },
                    { "type","FEMALE" },
                    { "startTime",DateTime.Now },
                    { "duration","678" },
                    { "createdAt",DateTime.Now }
                }, ContentType.Json);
                response = client.ExecutePost(request);
                if (response.IsSuccessful) {
                    var data = JsonSerializer.Deserialize<JsonNode>(response.Content);
                    Console.WriteLine(data.ToString());
                }
            }catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }

            Console.Read();
        }
    }
}
