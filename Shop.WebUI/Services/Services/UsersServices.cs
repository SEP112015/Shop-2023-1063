using Newtonsoft.Json;
using Shop.WebUI.Models.UsersResults;
using Shop.WebUI.Results.UsersResult;
using Shop.WebUI.Services.ISerivices;
using System.Text;

namespace Shop.WebUI.Services.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly HttpClientHandler _httpClientHandler;
        private const string Url = "http://localhost:5286/api/Users/";
        public UsersServices()
        {
            _httpClientHandler = new HttpClientHandler();
            _httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
        }

        public async Task<UsersGetResult> GetById(int id)
        {
            using (var httpClient = new HttpClient(_httpClientHandler))
            {
                var url = $"{Url}GetUsersBy{id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<UsersGetResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new UsersGetResult { success = false, message = "Error al obtener el usuario." };
                    }
                }
            }
        }

        public async Task<UsersGetListResult> GetList()
        {
            using (var httpClient = new HttpClient(_httpClientHandler))
            {
                var url = $"{Url}GetUser";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<UsersGetListResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new UsersGetListResult { success = false, message = "Error al obtener la lista de usuarios." };
                    }
                }
            }
        }

        public async Task<UsersGetResult> Save(UsersSaveModel saveModel)
        {
            using (var httpClient = new HttpClient(_httpClientHandler))
            {
                var url = $"{Url}SaveUser";
                var content = new StringContent(JsonConvert.SerializeObject(saveModel), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(url, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<UsersGetResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new UsersGetResult { success = false, message = "Error al guardar el usuario." };
                    }
                }
            }
        }

        public async Task<UsersGetResult> Update(UsersUpdateModel updateModel)
        {
            using (var httpClient = new HttpClient(_httpClientHandler))
            {
                var url = $"{Url}UpdateUser";
                var content = new StringContent(JsonConvert.SerializeObject(updateModel), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync(url, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<UsersGetResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new UsersGetResult { success = false, message = "Error al actualizar el usuario." };
                    }
                }
            }
        }
    }
}
