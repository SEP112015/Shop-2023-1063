using Shop.WebUI.Models.CustomersResults;
using Shop.WebUI.Results.CustomersResult;

namespace Shop.WebUI.Services.ISerivices
{
    public interface ICustomersServices
    {
        Task<CustomersGetListResult> GetList();
        Task<CustomersGetResult> GetById(int id);
        Task<CustomersGetResult> Save(CustomersSaveModel saveModel);
        Task<CustomersGetResult> Update(CustomersUpdateModel updateModel);




    }
}
