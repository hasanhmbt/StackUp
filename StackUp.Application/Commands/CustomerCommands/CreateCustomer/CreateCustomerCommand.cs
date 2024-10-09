using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Commands.CustomerCommands
{
    public class CreateCustomerCommand : IRequest<CustomerDTO>
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public CreateCustomerCommand(string customerName, string address, string email, string phone)
        {
            CustomerName = customerName;
            Address = address;
            Email = email;
            Phone = phone;
        }
    }
}
