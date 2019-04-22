using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BacNetTool.Models;

namespace BacNetTool.Controllers
{
    public class HomeController : Controller
    {
        private BACNet_dbContext _context;
        public HomeController(BACNet_dbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public ActionResult GetNav()
        {
            var devices = _context.Device.ToList();
            return Json(devices);
        }

        [HttpPost]
        public ActionResult SubmitDevice()
        {
            var id = Request.Form["id"];
            var device = new Device
            {
                Id = int.Parse(id),
                VendorName = Request.Form["vendorName"],
                ObjectName = Request.Form["objectName"]
            };
            var existing = _context.Device.FirstOrDefault(d => d.Id == int.Parse(id));
            if (existing != null)
            {
                existing.VendorName = device.VendorName;
                existing.ObjectName = device.ObjectName;
                var updated = _context.Device.Update(existing);
                _context.SaveChanges();
                return Json(updated);
            }

            var devices = _context.Device.Add(device);
            _context.SaveChanges();
            return Json(devices);
        }
    }
}
