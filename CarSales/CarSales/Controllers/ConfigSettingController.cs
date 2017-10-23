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
    public class ConfigSettingController : Controller
    {
        // GET: ConfigSetting
        public ActionResult Index()
        {
            var client = new WebClient();

            var data = client.DownloadString("http://localhost/CarSales/api/config");            
            var configSettings = JsonConvert.DeserializeObject<List<ConfigSetting>>(data);
            return View(configSettings);
        }

        // GET: ConfigSetting/Details/5
        public ActionResult Details(int id)
        {
            var client = new WebClient();

            var data = client.DownloadString(string.Format("http://localhost/CarSales/api/config?id={0}", id.ToString()));
            var configSettings = JsonConvert.DeserializeObject<ConfigSetting>(data);
            return View(configSettings);
        }

        // GET: ConfigSetting/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConfigSetting/Create
        [HttpPost]
        public ActionResult Create(ConfigSetting foo)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    HttpClient client = new HttpClient();
                    var result = client.PostAsJsonAsync(string.Format("http://localhost/CarSales/api/config/Post"), foo).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var emp = result.Content.ReadAsAsync<ConfigSetting>().Result;
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

        // GET: ConfigSetting/Edit/5
        public ActionResult Edit(int id)
        {
           var client = new WebClient();

            var data = client.DownloadString(string.Format("http://localhost/CarSales/api/config?id={0}", id.ToString()));
            var configSettings = JsonConvert.DeserializeObject<ConfigSetting>(data);
            return View(configSettings);
        }

        // POST: ConfigSetting/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ConfigSetting foo )
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {                   
                    HttpClient client = new HttpClient();
                    var result = client.PutAsJsonAsync(string.Format("http://localhost/CarSales/api/config/Put?id={0}", id.ToString()) , foo).Result;
                    if (result.IsSuccessStatusCode)
                    {
                       var emp = result.Content.ReadAsAsync<ConfigSetting>().Result;
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

        // GET: ConfigSetting/Delete/5
        public ActionResult Delete(int id)
        {
            var client = new WebClient();

            var data = client.DownloadString(string.Format("http://localhost/CarSales/api/config?id={0}", id.ToString()));
            var configSettings = JsonConvert.DeserializeObject<ConfigSetting>(data);
            return View(configSettings);
        }

        // POST: ConfigSetting/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ConfigSetting foo)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    HttpClient client = new HttpClient();
                    var result = client.DeleteAsync(string.Format("http://localhost/CarSales/api/config/Delete?id={0}", id.ToString())).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var emp = result.Content.ReadAsAsync<ConfigSetting>().Result;
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
