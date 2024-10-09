using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Commands.CustomerCommands
{
    public class UpdateCustomerCommand : IRequest<CustomerDTO>
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public UpdateCustomerCommand(int id, string customerName, string address, string email, string phone)
        {
            Id = id;
            CustomerName = customerName;
            Address = address;
            Email = email;
            Phone = phone;
        }
    }
}
