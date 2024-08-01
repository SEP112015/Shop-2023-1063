using Newtonsoft.Json;
using Shop.WebUI.Models.CustomersResults;
using Shop.WebUI.Results.CustomersResult;
using Shop.WebUI.Services.ISerivices;
using System.Text;
namespace Shop.WebUI.Services.Services
{
    public class CustomersServices : ICustomersServices
    {
        private readonly HttpClientHandler _httpClientHandler;
        private const string Url = "http://localhost:5286/api/Customers/";
        public CustomersServices()
        {
            _httpClientHandler = new HttpClientHandler();
            _httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
        }
        public async Task<CustomersGetResult> GetById(int id)
        {
            using (var httpClient = new HttpClient(_httpClientHandler))
            {
                var url = $"{Url}GetCustomersById?id={id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<CustomersGetResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new CustomersGetResult { success = false, message = "Error al obtener el cliente." };
                    }
                }
            }
        }

        public async Task<CustomersGetListResult> GetList()
        {
            using (var httpClient = new HttpClient(_httpClientHandler))
            {
                var url = $"{Url}GetCustomers";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<CustomersGetListResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new CustomersGetListResult { success = false, message = "Error al obtener la lista de categorías." };
                    }
                }
            }
        }

        public async Task<CustomersGetResult> Save(CustomersSaveModel saveModel)
        {
            using (var httpClient = new HttpClient(_httpClientHandler))
            {
                var url = $"{Url}SaveCustomer";
                var content = new StringContent(JsonConvert.SerializeObject(saveModel), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(url, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<CustomersGetResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new CustomersGetResult { success = false, message = "Error al guardar el cliente." };
                    }
                }
            }

        }

        public async  Task<CustomersGetResult> Update(CustomersUpdateModel updateModel)
        {
            using (var httpClient = new HttpClient(_httpClientHandler))
            {
                var url = $"{Url}UpdateCustomers";
                var content = new StringContent(JsonConvert.SerializeObject(updateModel), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync(url, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<CustomersGetResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new CustomersGetResult { success = false, message = "Error al actualizar el cliente." };
                    }
                }
            }
        }
    }
}
