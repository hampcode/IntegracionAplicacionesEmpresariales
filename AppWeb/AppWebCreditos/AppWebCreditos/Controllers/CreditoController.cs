using AppWebCreditos.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AppWebCreditos.Controllers
{
    public class CreditoController : Controller
    {
        // GET: Credito
        public async Task<ActionResult> Index()
        {
            using (var client=new HttpClient())
            {
                client.BaseAddress = new Uri(" http://localhost:49954/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new 
                    MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.
                    GetAsync("CreditoService.svc/rest/ListarCredito");

                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStreamAsync().Result;

                    DataContractJsonSerializer obj = new DataContractJsonSerializer
                            (typeof(List<CreditoViewModel>));
                    List<CreditoViewModel> response = obj.ReadObject(result) 
                                as List<CreditoViewModel>;

                    return View(response);
                }
                return View();
            }
        }

        // GET: Credito/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Credito/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Credito/Create
        [HttpPost]
        public async Task<ActionResult> Create(CreditoViewModel credito)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(" http://localhost:49954/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new
                    MediaTypeWithQualityHeaderValue("application/json"));

                DataContractJsonSerializer obj = new DataContractJsonSerializer
                            (typeof(CreditoViewModel));
                MemoryStream men = new MemoryStream();

                obj.WriteObject(men, credito);
                string data = Encoding.UTF8.GetString(men.ToArray(), 0, (int)men.Length);

                HttpResponseMessage res =
                    await
                        client.PostAsync("CreditoService.svc/rest/RegistrarCredito",
                            new StringContent(data, Encoding.UTF8, "application/json"));

                if (res.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                else
                    return View();

            }
        }

        // GET: Credito/Edit/5
        public async Task<ActionResult> Edit(int idCredito)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49954/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res =
                    await client.GetAsync("CreditoService.svc/rest/ObtenerCredito/" + idCredito);

                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStreamAsync().Result;
                    DataContractJsonSerializer obj = new DataContractJsonSerializer
                        (typeof(CreditoViewModel));
                    CreditoViewModel response = obj.ReadObject(result) as CreditoViewModel;
                    return View(response);
                }
                return View();
            }
        }

        // POST: Credito/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(CreditoViewModel credito)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49954/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(CreditoViewModel));
                MemoryStream men = new MemoryStream();
                ser.WriteObject(men, credito);
                string data = Encoding.UTF8.GetString(men.ToArray(), 0, (int)men.Length);

                HttpResponseMessage res =
                    await
                        client.PutAsync("CreditoService.svc/rest/ActualizarCredito",
                            new StringContent(data, Encoding.UTF8, "application/json"));

                if (res.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                else
                    return View();
            }
        }

        // GET: Credito/Delete/5
        public async Task<ActionResult> Delete(int idCredito)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49954/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res =
                    await client.GetAsync("CreditoService.svc/rest/ObtenerCredito/"
                    + idCredito);

                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStreamAsync().Result;
                    DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(CreditoViewModel));
                    CreditoViewModel response = obj.ReadObject(result) as CreditoViewModel;
                    return View(response);
                }
                return View();
            }
        }

        // POST: Credito/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(CreditoViewModel credito)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49954/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res =
                    await client.DeleteAsync("CreditoService.svc/rest/EliminarCredito/" + credito.IdCredito);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
        }
    }
}
