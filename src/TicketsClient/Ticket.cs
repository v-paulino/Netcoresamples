namespace TicketsClient
{
    public class Ticket
    {
        public DateTime Date { get; set; }

        public string? Summary { get; set; }

        public string CreatedBy { get; set; }

        public string AssignedTo { get; set; }
    }
}