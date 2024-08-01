
using Shop.WebUI.Results.UsersResult;
using Shop.WebUI.Models.UsersResults;

namespace Shop.WebUI.Services.ISerivices
{
    public interface IUsersServices
    {
        Task<UsersGetListResult> GetList();
        Task<UsersGetResult> GetById(int id);
        Task<UsersGetResult> Save(UsersSaveModel saveModel);
        Task<UsersGetResult> Update(UsersUpdateModel updateModel);


    }
}
