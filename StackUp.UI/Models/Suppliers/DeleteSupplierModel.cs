using System.ComponentModel.DataAnnotations;

namespace StackUp.UI.Models.Suppliers
{
    public class DeleteSupplierModel
    {
        [Required(ErrorMessage = "Supplier ID is required.")]
        public int Id { get; set; }
    }
}
