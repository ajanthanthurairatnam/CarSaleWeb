using CarSales.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CarSales.Controllers
{
    public class VehicleBodyController : Controller
    {
        // GET: VehicleBody
        public ActionResult Index()
        {
            var client = new WebClient();

            var data = client.DownloadString("http://localhost/CarSales/api/VehicleBodies");
            var configSettings = JsonConvert.DeserializeObject<List<VehicleBody>>(data);
            return View(configSettings);
        }

        // GET: VehicleBody/Details/5
        public ActionResult Details(int id)
        {
            var client = new WebClient();

            var data = client.DownloadString(string.Format("http://localhost/CarSales/api/VehicleBodies?id={0}", id.ToString()));
            var configSettings = JsonConvert.DeserializeObject<VehicleBody>(data);
            return View(configSettings);
        }

        // GET: VehicleBody/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleBody/Create
        [HttpPost]
        public ActionResult Create(VehicleBody foo)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    HttpClient client = new HttpClient();
                    var result = client.PostAsJsonAsync(string.Format("http://localhost/CarSales/api/VehicleBodies/Post"), foo).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var emp = result.Content.ReadAsAsync<VehicleBody>().Result;
                        ViewBag.Result = "Successfully saved!";

                    }
                    else
                    {
                        ViewBag.Result = "Error! Please try with valid data.";
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleBody/Edit/5
        public ActionResult Edit(int id)
        {
            var client = new WebClient();

            var data = client.DownloadString(string.Format("http://localhost/CarSales/api/VehicleBodies?id={0}", id.ToString()));
            var configSettings = JsonConvert.DeserializeObject<VehicleBody>(data);
            return View(configSettings);
        }

        // POST: VehicleBody/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, VehicleBody foo)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    HttpClient client = new HttpClient();
                    var result = client.PutAsJsonAsync(string.Format("http://localhost/CarSales/api/VehicleBodies/Put?id={0}", id.ToString()), foo).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var emp = result.Content.ReadAsAsync<VehicleBody>().Result;
                        ViewBag.Result = "Successfully saved!";

                    }
                    else
                    {
                        ViewBag.Result = "Error! Please try with valid data.";
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleBody/Delete/5
        public ActionResult Delete(int id)
        {
            var client = new WebClient();

            var data = client.DownloadString(string.Format("http://localhost/CarSales/api/VehicleBodies?id={0}", id.ToString()));
            var configSettings = JsonConvert.DeserializeObject<VehicleAdvertisement>(data);
            return View(configSettings);
        }

        // POST: VehicleBody/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, VehicleBody foo)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    HttpClient client = new HttpClient();
                    var result = client.DeleteAsync(string.Format("http://localhost/CarSales/api/VehicleBodies/Delete?id={0}", id.ToString())).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var emp = result.Content.ReadAsAsync<VehicleAdvertisement>().Result;
                        ViewBag.Result = "Successfully saved!";

                    }
                    else
                    {
                        ViewBag.Result = "Error! Please try with valid data.";
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
