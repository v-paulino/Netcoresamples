
namespace TicketsApi.Services
{
    public interface ITicketsQueryService
    {
        ValueTask<IEnumerable<Ticket>> GetAllAsync();
    }
}