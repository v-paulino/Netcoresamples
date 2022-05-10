namespace TicketsApi.Services
{
    public class InMemoryTicketsQueryService : ITicketsQueryService
    {
        private static readonly string[] Summaries = new[]
      {
                "Car does not start",
                "Car is making a strange noise",
                "Tire loose air everytime i fill",
                "The lights are not blinking"
        };


        private static readonly string[] Names = new[]
        {
                "John",
                "Mary",
                "Antonio",
                "Joanne",
                "Jose"
        };

        public ValueTask<IEnumerable<Ticket>> GetAllAsync()
        {
            var tickets = Enumerable.Range(1, 5).Select(index => new Ticket
            {
                Date = DateTime.Now.AddDays(index),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                CreatedBy = Names[Random.Shared.Next(Names.Length)],
                AssignedTo = Names[Random.Shared.Next(Names.Length)]
            })
          .ToArray();

            return new ValueTask<IEnumerable<Ticket>>(tickets);
        }
    }
}
