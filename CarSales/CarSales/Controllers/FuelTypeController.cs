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
    public class FuelTypeController : Controller
    {
        // GET: FuelType
        public ActionResult Index()
        {
            var client = new WebClient();

            var data = client.DownloadString("http://localhost/CarSales/api/VehicleFuels");
            var configSettings = JsonConvert.DeserializeObject<List<VehicleFuel>>(data);
            return View(configSettings);
        }

        // GET: FuelType/Details/5
        public ActionResult Details(int id)
        {
            var client = new WebClient();

            var data = client.DownloadString(string.Format("http://localhost/CarSales/api/VehicleFuels?id={0}", id.ToString()));
            var configSettings = JsonConvert.DeserializeObject<VehicleFuel>(data);
            return View(configSettings);
        }

        // GET: FuelType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FuelType/Create
        [HttpPost]
        public ActionResult Create(VehicleFuel foo)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    HttpClient client = new HttpClient();
                    var result = client.PostAsJsonAsync(string.Format("http://localhost/CarSales/api/VehicleFuels/Post"), foo).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var emp = result.Content.ReadAsAsync<VehicleFuel>().Result;
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

        // GET: FuelType/Edit/5
        public ActionResult Edit(int id)
        {
            var client = new WebClient();

            var data = client.DownloadString(string.Format("http://localhost/CarSales/api/VehicleFuels?id={0}", id.ToString()));
            var configSettings = JsonConvert.DeserializeObject<VehicleBody>(data);
            return View(configSettings);
        }

        // POST: FuelType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, VehicleFuel foo)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    HttpClient client = new HttpClient();
                    var result = client.PutAsJsonAsync(string.Format("http://localhost/CarSales/api/VehicleFuels/Put?id={0}", id.ToString()), foo).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var emp = result.Content.ReadAsAsync<VehicleFuel>().Result;
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

        // GET: FuelType/Delete/5
        public ActionResult Delete(int id)
        {
            var client = new WebClient();

            var data = client.DownloadString(string.Format("http://localhost/CarSales/api/VehicleFuels?id={0}", id.ToString()));
            var configSettings = JsonConvert.DeserializeObject<VehicleFuel>(data);
            return View(configSettings);
        }

        // POST: FuelType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, VehicleFuel foo)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    HttpClient client = new HttpClient();
                    var result = client.DeleteAsync(string.Format("http://localhost/CarSales/api/VehicleFuels/Delete?id={0}", id.ToString())).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var emp = result.Content.ReadAsAsync<VehicleFuel>().Result;
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
