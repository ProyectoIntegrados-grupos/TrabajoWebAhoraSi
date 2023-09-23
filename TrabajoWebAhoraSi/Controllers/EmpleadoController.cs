using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TrabajoWebAhoraSi.Data;
using TrabajoWebAhoraSi.Models;
namespace TrabajoWebAhoraSi.Controllers
{
    public class EmpleadoController : Controller
    {
        public IActionResult MostrarEmpleados()
        {
            return View();
        }
    }
}
