
using StackUp.Application.DTOs;

namespace StackUp.UI.ViewModels
{
    public class HomeViewModel
    {
        public int UserCount { get; set; }
        public decimal TotalSoldProductsPrice { get; set; }
        public int SuppliersCount { get; set; }
        public int TotalOrdersCount { get; set; }

        public IEnumerable<MostSoldProductDTO> MostSoldProducts { get; set; }
        public IEnumerable<MonthlyProductSalesDTO> MonthlyProductSales { get; set; }

        public List<OrderDTO> RecentOrders { get; set; }
        public List<SupplierDTO> RecentSuppliers { get; set; }
    }

    public class MostSoldProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int QuantitySold { get; set; }
    }

    public class MonthlyProductSalesDTO
    {
        public string Month { get; set; }
        public int QuantitySold { get; set; }
    }
}
