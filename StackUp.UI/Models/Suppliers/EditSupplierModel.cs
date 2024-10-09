using System.ComponentModel.DataAnnotations;

namespace StackUp.UI.Models.Suppliers
{
    public class EditSupplierModel
    {
        [Required(ErrorMessage = "Supplier ID is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Supplier name is required.")]
        [StringLength(100, ErrorMessage = "Supplier name must not exceed 100 characters.")]
        public string SupplierName { get; set; }

        [Required(ErrorMessage = "Contact information is required.")]
        public ContactInfoModel ContactInfo { get; set; }
    }
}
