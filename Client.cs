using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;


namespace PhoneBookClient
{
    class Client
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly String baseURI = "http://localhost:2737/api/phonebook/";

        static async Task RunAsync()
        {
            try
            {
                // GET /api/phonebook/all
                var serializer = new DataContractJsonSerializer(typeof(List<PhoneBookEntry>));

                var streamTask = client.GetStreamAsync(baseURI + "all");

                var entries = serializer.ReadObject(await streamTask) as List<PhoneBookEntry>;

                foreach( var e in entries)
                {
                    Console.WriteLine(e.ToString());
                }

                // GET /api/phonebook/name/{name}

                streamTask = client.GetStreamAsync(baseURI + "name/Joe Soap");

                entries = serializer.ReadObject(await streamTask) as List<PhoneBookEntry>;

                foreach(var e in entries)
                {
                    Console.WriteLine(e.ToString());
                }


                // GET /api/phonebook/number/{number}
                serializer = new DataContractJsonSerializer(typeof(PhoneBookEntry));

                streamTask = client.GetStreamAsync(baseURI + "number/0239305383");

                var entry = serializer.ReadObject(await streamTask) as PhoneBookEntry;

                Console.WriteLine(entry);
        
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        // Kick off
        static void Main()
        {
            RunAsync();
            client.Dispose();
            Console.ReadLine();
        }
    
    }
}
