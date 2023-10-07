using Microsoft.AspNetCore.Mvc;
using SukiBookStoreMvc.Models.Domain;
using SukiBookStoreMvc.Repositories.Abstrsct;

namespace SukiBookStoreMvc.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Genre model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _genreService.Add(model);
            if (result)
            {
                TempData["message"] = "Genre Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["message"] = "Error has occured on server side";
            return View(model);
        }



        public IActionResult Update(int id)
        {
            var record = _genreService.FindById(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(Genre model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _genreService.Update(model);
            if (result)
            {
                return RedirectToAction("GetAll");
            }
            TempData["message"] = "Error has occured on server side";
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            _ = _genreService.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {

            var data = _genreService.GetAll();
            return View(data);
        }


    }
}
