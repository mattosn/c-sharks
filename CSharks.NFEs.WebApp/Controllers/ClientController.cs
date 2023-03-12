﻿using CSharks.NFEs.Domain.Interfaces.Repositories;
using CSharks.NFEs.Domain.Models;
using CSharks.NFEs.Services.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CSharks.NFEs.WebApp.Controllers
{
    public class ClientController : Controller
    {

        private readonly IClientRepository _clientRepo;

        public ClientController(IClientRepository clientRepo)
        {
            _clientRepo = clientRepo;
        }

        public IActionResult Index()
        {
            //recive list of clients to display
            //  List<clients> clients = _requestMySql and pass it on parameters
            return View("~/Views/Register/Clients/Index.cshtml");
        }

        [HttpPost]
        public IActionResult Create(Client client)
        {
            
            if (ModelState.IsValid)
            {
                _clientRepo.Save(client);
                TempData["Success"] = "Salvo com sucesso";
            }
            else
            {
                return View("~/Views/Register/Clients/Index.cshtml");
            }


            return View("~/Views/Register/Clients/Index.cshtml");
        }
    }
}
