using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Commands.SupplierCommands
{
    public class UpdateSupplierCommand : IRequest<SupplierDTO>
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public UpdateSupplierCommand(int id, string supplierName, string email, string phone)
        {
            Id = id;
            SupplierName = supplierName;
            Email = email;
            Phone = phone;
        }
    }
}
