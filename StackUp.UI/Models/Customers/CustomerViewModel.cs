using StackUp.UI.Models.Orders;

namespace StackUp.UI.Models.Customers
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public ContactInfoViewModel ContactInfo { get; set; }

        public ICollection<OrderViewModel> Orders { get; set; }
    }

    public class ContactInfoViewModel
    {
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
