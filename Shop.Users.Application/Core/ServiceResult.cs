using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Users.Application.Core
{
    internal class ServiceResult
    {
        public ServiceResult()
        {
            Success = true;
        }
        public bool Success { get; set; }
        public string? Menssage { get; set; }
        public dynamic? Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
