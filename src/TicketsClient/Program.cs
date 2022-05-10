// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using TicketsClient;

Console.WriteLine("Hello, World!");



HttpClient client = new HttpClient();
client.BaseAddress = new Uri("https://localhost:7193/");
 

TicketsApiHandler handler = new TicketsApiHandler(client);

Console.WriteLine("Press any key to do request to service...");

Console.ReadLine();

IEnumerable<Ticket> tickets = await handler.GetAllTicketsAsyncV1(new CancellationToken());


Console.WriteLine("There Where retrieved {0} tickets", tickets.Count());

PrettyPrint(tickets);

void PrettyPrint(IEnumerable<Ticket> tickets) {

    var jsonString = System.Text.Json.JsonSerializer.Serialize<IEnumerable<Ticket>>(tickets,new JsonSerializerOptions() { WriteIndented = true } );

    Console.WriteLine(jsonString);
}

Console.ReadLine();