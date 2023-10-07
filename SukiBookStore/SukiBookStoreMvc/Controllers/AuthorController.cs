using Microsoft.AspNetCore.Mvc;
using SukiBookStoreMvc.Models.Domain;
using SukiBookStoreMvc.Repositories.Abstrsct;

namespace SukiBookStoreMvc.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Author model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _authorService.Add(model);
            if (result)
            {
                TempData["message"] = "Author Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["message"] = "Error has occured on server side";
            return View(model);
        }



        public IActionResult Update(int id)
        {
            var record = _authorService.FindById(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(Author model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _authorService.Update(model);
            if (result)
            {
                TempData["message"] = "Updated successfully";
                return RedirectToAction("GetAll");
            }
            TempData["message"] = "Error has occured on server side";
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            _ = _authorService.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {

            var data = _authorService.GetAll();
            return View(data);
        }
    }
}
