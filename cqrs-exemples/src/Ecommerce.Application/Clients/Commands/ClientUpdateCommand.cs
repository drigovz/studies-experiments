namespace Ecommerce.Application.Clients.Commands
{
    public class ClientUpdateCommand : ClientCommand
    {
        public int Id { get; set; }

        public ClientUpdateCommand(int id)
        {
            Id = id;
        }
    }
}
