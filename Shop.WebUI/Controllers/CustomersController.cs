using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Shop.WebUI.Models.CustomersResults;
using Shop.WebUI.Results.CustomersResult;
using Shop.WebUI.Services.ISerivices;
using System.Text;
using System.Text.Json.Serialization;

namespace Shop.WebUI.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomersServices _customersServices;
        public CustomersController(ICustomersServices customersServices)
        {
            _customersServices = customersServices;
        }
        // GET: CustomersController
        public async Task<ActionResult> Index()
        {
            var customersGetList = await _customersServices.GetList();

            if (!customersGetList.success)
            {
                ViewBag.Message = customersGetList.message;
                return View();
            }

            return View(customersGetList.data);
        }
        // GET: CustomersController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var customersGetResult = await _customersServices.GetById(id);

            if (!customersGetResult.success)
            {
                ViewBag.Message = customersGetResult.message;
                return View();
            }

            return View(customersGetResult.data);
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CustomersSaveModel customersSave)
        {
            try
            {
                var saveResult = await _customersServices.Save(customersSave);

                if (!saveResult.success)
                {
                    ViewBag.Message = saveResult.message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var customersResult = await _customersServices.GetById(id);

            if (!customersResult.success)
            {
                ViewBag.Message = customersResult.message;
                return View();
            }

            return View(customersResult.data);
        }


        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CustomersUpdateModel customersUpdate)
        {
            try
            {

                var updateResult = await _customersServices.Update(customersUpdate);

                if (!updateResult.success)
                {
                    ViewBag.Message = updateResult.message;
                    return View(customersUpdate);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error inesperado: {ex.Message}";
                return View(customersUpdate);
            }
        }

        //    // GET: CustomersController/Delete/5
        //    public async Task<ActionResult> Delete(int id)
        //    {
        //        CustomersRemoveResult customersGetResult = new CustomersRemoveResult();

        //        using (var httpClient = new HttpClient(_httpClientHandler))
        //        {
        //            var url = $"http://localhost:5286/api/Customers/RemoveCustomers";

        //            using (var response = await httpClient.GetAsync(url))
        //            {
        //                if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //                {
        //                    string apiResponse = await response.Content.ReadAsStringAsync();

        //                    customersGetResult = JsonConvert.DeserializeObject<CustomersRemoveResult>(apiResponse);

        //                    if (!customersGetResult.success)
        //                    {
        //                        ViewBag.Message = customersGetResult.message;
        //                        return View();
        //                    }
        //                }
        //            }
        //        }

        //        return View(customersGetResult.result);
        //    }
        //    // POST: CustomersController/Delete/5
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<ActionResult> Delete(int id, IFormCollection collection)
        //    {
        //        try
        //        {
        //            using (var httpClient = new HttpClient(_httpClientHandler))
        //            {
        //                var url = $"http://localhost:5286/api/Customers/DeleteCustomer?id={id}";

        //                using (var response = await httpClient.DeleteAsync(url))
        //                {
        //                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //                    {
        //                        string apiResponse = await response.Content.ReadAsStringAsync();
        //                        var result = JsonConvert.DeserializeObject<CustomersSaveResult>(apiResponse);

        //                        if (result.success)
        //                        {
        //                            return RedirectToAction(nameof(Index));
        //                        }
        //                        else
        //                        {
        //                            ViewBag.Message = result.message;
        //                            return View();
        //                        }
        //                    }
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }
        //}
    }
}