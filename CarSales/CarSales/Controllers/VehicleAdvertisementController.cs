using CarSales.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CarSales.Controllers
{
    public class VehicleAdvertisementController : Controller
    {
        string url = ConfigurationManager.AppSettings["Url"];

        // GET: VehicleAdvertisement
        public ActionResult Index()
        {

           
            var client = new WebClient();

            var data = client.DownloadString(url+"VehicleAdvertisement");
            var configSettings = JsonConvert.DeserializeObject<List<VehicleAdvertisement>>(data);
            return View(configSettings);
          
        }


        // GET: VehicleAdvertisement
        [HttpPost]
        public ActionResult Index(string SearchText)
        {


            var client = new WebClient();

            var data = client.DownloadString(url + String.Format("VehicleAdvertisement?SearchText={0}", SearchText));
            var configSettings = JsonConvert.DeserializeObject<List<VehicleAdvertisement>>(data);
            return View(configSettings);

        }

        // GET: VehicleAdvertisement/Details/5
        public ActionResult Details(int id)
        {
            var client = new WebClient();

            var data = client.DownloadString(string.Format("{0}VehicleAdvertisement?id={1}", url, id.ToString()));
            var configSettings = JsonConvert.DeserializeObject<VehicleAdvertisement>(data);
            return View(configSettings);
           
        }

        // GET: VehicleAdvertisement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleAdvertisement/Create
        [HttpPost]
        public ActionResult Create(VehicleAdvertisement foo,string BodyType)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    HttpClient client = new HttpClient();
                    var result = client.PostAsJsonAsync(string.Format("{0}VehicleAdvertisement/Post", url), foo).Result;
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

        // GET: VehicleAdvertisement/Edit/5
        public ActionResult Edit(int id)
        {
            var client = new WebClient();

            var data = client.DownloadString(string.Format("{0}VehicleAdvertisement?id={1}", url, id.ToString()));
            var configSettings = JsonConvert.DeserializeObject<VehicleAdvertisement>(data);
            return View(configSettings);
        }

        // POST: VehicleAdvertisement/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, VehicleAdvertisement foo)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    HttpClient client = new HttpClient();
                    var result = client.PutAsJsonAsync(string.Format("{0}VehicleAdvertisement/Put?id={1}", url, id.ToString()), foo).Result;
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

        // GET: VehicleAdvertisement/Delete/5
        public ActionResult Delete(int id)
        {
            var client = new WebClient();

            var data = client.DownloadString(string.Format("{0}VehicleAdvertisement?id={1}", url, id.ToString()));
            var configSettings = JsonConvert.DeserializeObject<VehicleAdvertisement>(data);
            return View(configSettings);
        }

        // POST: VehicleAdvertisement/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    HttpClient client = new HttpClient();
                    var result = client.DeleteAsync(string.Format("{0}VehicleAdvertisement/Delete?id={1}", url, id.ToString())).Result;
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
