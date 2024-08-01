using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.WebUI.Models.UsersResults
{
    public class UsersGetModel
    {
     
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string name { get; set; }
    }

}
