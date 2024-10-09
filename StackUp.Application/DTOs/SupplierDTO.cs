using StackUp.Application.DTOs.Common;

namespace StackUp.Application.DTOs
{
    public class SupplierDTO : BaseDto
    {

        public string SupplierName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
