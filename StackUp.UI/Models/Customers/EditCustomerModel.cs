using System.ComponentModel.DataAnnotations;

namespace StackUp.UI.Models.Customers
{
    public class EditCustomerModel
    {
        [Required(ErrorMessage = "Customer ID is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer name is required.")]
        [StringLength(100, ErrorMessage = "Customer name must not exceed 100 characters.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(200, ErrorMessage = "Address must not exceed 200 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Contact information is required.")]
        public ContactInfoModel ContactInfo { get; set; }
    }
}
