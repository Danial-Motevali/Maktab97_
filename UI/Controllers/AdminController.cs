using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.Models.Dto;
using App.Domain.Services.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IShopService _shopService;
        private readonly IMapper _mapper;
        public AdminController(IShopService shopServices, IMapper mapper)
        {
            _shopService = shopServices;
            _mapper = mapper;
        }

        // GET: AdminController
        public ActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ShowTheShop(CancellationToken cancellation)
        {
            var shops = await _shopService.GetAll(cancellation);

            List<ShopDtoOutput> result = new List<ShopDtoOutput>();

            foreach (var shopDto in shops)
            {
                result.Add(_mapper.Map<ShopDtoOutput>(shopDto));
            }

            return View(shops);
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
