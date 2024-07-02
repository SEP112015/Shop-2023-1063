using Shop.Common.Data.Respository;
using Shop.Modules.Domain.Entities;

namespace Shop.Modules.Domain.Interfaces
{
    public interface IUsersRepository : IBaseRepository<Users, int>
    {
        List<Users> GetUsersByUsersId(int UserId);
    }
}