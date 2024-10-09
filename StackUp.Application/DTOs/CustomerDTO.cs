using StackUp.Application.DTOs.Common;

namespace StackUp.Application.DTOs
{
    public class CustomerDTO : BaseDto
    {

        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
