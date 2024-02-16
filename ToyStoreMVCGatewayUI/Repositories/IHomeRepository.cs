using ToyStoreMVCGatewayUI.Models;

namespace ToyStoreMVCGatewayUI
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Category>> Categories();
        Task<IEnumerable<Product>> GetProducts(string sTerm = "", int categoryid = 0);
    }
}