using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TicketsClient
{
    /// <summary>
    /// HAving one client handler for each base address we want to reach it will help to maintain rest api evolution with less effort and keeps domains separated in diferent handlers
    /// </summary>
    public class TicketsApiHandler
    {
        private HttpClient httpClient;
        JsonSerializerOptions options = new System.Text.Json.JsonSerializerOptions();

        public TicketsApiHandler(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            options.NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.Strict;
            options.PropertyNameCaseInsensitive = true;
        } 

        /// <summary>
        /// If json options configuration is something that is to be the same between diferent services handlers, it can be part of the composition of this instance instead of being coupled
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="options"></param>
        public TicketsApiHandler(HttpClient httpClient, JsonSerializerOptions options)
        {
            this.httpClient = httpClient;
            this.options = options;
        }

        /// <summary>
        /// Implement one method for each API method available on the service and abstracts the http response message 
        /// </summary>
        /// <param name="token">enable the client to cancel the request at any given time</param>
        /// <returns>list of all strong typed tickets information. json was all managed in the extension method implementation GetFromJsonAsync </returns>
        /// <exception cref="ArgumentNullException"> if httpClient is null </exception>
        public async Task<IEnumerable<Ticket>> GetAllTicketsAsyncV1(CancellationToken token) 
        {

            if(this.httpClient == null) 
                throw new ArgumentNullException(nameof(httpClient));

            List<Ticket> tickets = await httpClient.GetFromJsonAsync<List<Ticket>>("/tickets");
            
            return tickets;
        }

        /// <summary>
        /// Implement one method for each API method available on the service and gives the ability to get work with the http response message ( status code and headers for example ) 
        /// </summary>
        /// <param name="token">enable the client to cancel the request at any given time</param>
        /// <returns>list of all strong typed tickets information. json was all managed in the extension method implementation GetFromJsonAsync </returns>
        /// <exception cref="ArgumentNullException"> if httpClient is null </exception>
        public async Task<IEnumerable<Ticket>> GetAllTicketsAsyncV2(CancellationToken token)
        {

            if (this.httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));

            HttpResponseMessage  response = await httpClient.GetAsync("tickets", token);

            response.EnsureSuccessStatusCode();

            List<Ticket> tickets = await response.Content.ReadFromJsonAsync<List<Ticket>>(options, token);

            return tickets;
        }
    }
}
