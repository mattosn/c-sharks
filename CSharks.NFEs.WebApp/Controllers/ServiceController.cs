﻿using CSharks.NFEs.Domain.Interfaces.Repositories;
using CSharks.NFEs.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSharks.NFEs.WebApp.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServicesRepository _serviceRepo; 

        public ServiceController(
            IServicesRepository servicesRepository)
        {
            _serviceRepo = servicesRepository;
        }
        public IActionResult Index()
        {
            ViewBag.services = _serviceRepo.GetAll().ToList();
            return View("~/Views/Register/Services/Index.cshtml");
        }

        [HttpPost]
        public IActionResult Create(Service service)
        {
            if (ModelState.IsValid)
            {
                _serviceRepo.Save(service); 
                TempData["Success"] = "Salvo com sucesso";
                return RedirectToAction("Index");
            }
            else
            {
                return View("~/Views/Register/Services/Index.cshtml");
            }


            return View("~/Views/Register/Services/Index.cshtml");
        }
    }
}
