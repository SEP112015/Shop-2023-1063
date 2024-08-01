using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.WebUI.Models.UsersResults;
using Shop.WebUI.Results.UsersResult;
using Shop.WebUI.Services.ISerivices;
using System.Threading.Tasks;

namespace Shop.WebUI.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersServices _usersServices;
        public UsersController(IUsersServices usersServices)
        {
            _usersServices = usersServices;
        }

        // GET: UsersController
        public async Task<ActionResult> Index()
        {
            var usersGetList = await _usersServices.GetList();

            if (!usersGetList.success)
            {
                ViewBag.Message = usersGetList.message;
                return View();
            }

            return View(usersGetList.data);
        }

        // GET: UsersController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var usersGetResult = await _usersServices.GetById(id);

            if (!usersGetResult.success)
            {
                ViewBag.Message = usersGetResult.message;
                return View();
            }

            return View(usersGetResult.data);
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UsersSaveModel usersSave)
        {
            try
            {
                var saveResult = await _usersServices.Save(usersSave);

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

        // GET: UsersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var usersResult = await _usersServices.GetById(id);

            if (!usersResult.success)
            {
                ViewBag.Message = usersResult.message;
                return View();
            }

            return View(usersResult.data);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UsersUpdateModel usersUpdate)
        {
            try
            {
                var updateResult = await _usersServices.Update(usersUpdate);

                if (!updateResult.success)
                {
                    ViewBag.Message = updateResult.message;
                    return View(usersUpdate);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error inesperado: {ex.Message}";
                return View(usersUpdate);
            }
        }
    }
}


        // GET: UsersController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: UsersController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    

