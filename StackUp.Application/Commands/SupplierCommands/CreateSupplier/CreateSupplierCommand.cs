using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Commands.SupplierCommands
{
    public class CreateSupplierCommand : IRequest<SupplierDTO>
    {
        public string SupplierName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public CreateSupplierCommand(string supplierName, string email, string phone)
        {
            SupplierName = supplierName;
            Email = email;
            Phone = phone;
        }
    }
}
