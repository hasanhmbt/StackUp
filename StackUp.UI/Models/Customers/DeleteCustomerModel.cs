using System.ComponentModel.DataAnnotations;

namespace StackUp.UI.Models.Customers
{
    public class DeleteCustomerModel
    {
        [Required(ErrorMessage = "Customer ID is required.")]
        public int Id { get; set; }
    }
}
