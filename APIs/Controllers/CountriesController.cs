using APIs.Models.ViewModel;
using APIs.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static APIs.Models.ViewModel.Paises;

namespace APIs.Controllers
{
    public class CountriesController : Controller
    {

        public ActionResult Index()
        {
            var ddlOpciones = new List<SelectListItem>
            {
                new SelectListItem { Text = "Por nombre", Value = "1" },
                new SelectListItem { Text = "Por codigo", Value = "2" },
                new SelectListItem { Text = "Por lenguaje", Value = "3" }
            };

            ViewBag.ddlOpciones = ddlOpciones;
            return View();
        }

        //DOCUMENTACION NombrePaises():
        //1. async indica que el metodo es asincrono
        //1.1 "asíncrono" se refiere a un modelo de ejecución en el que las tareas pueden iniciarse y ejecutarse independientemente del flujo principal del programa, sin bloquear su progreso.Esto permite que el programa continúe realizando otras operaciones mientras espera que una tarea de larga duración, como una solicitud de red o una consulta a una base de datos, se complete.
        //1.3. Task representa una operacion asincrona que devuelve un valor 
        //2. IEnumerable es una interfaz que define un metodo para obtener un enumerador que itera a traves de una coleccion
        //3. using asegura que el objeto HttpClient se elimine correctamente despues de su uso
        //3.1. HttpClient es una clase que permite enviar solicitudes HTTP y recibir respuestas HTTP desde un recurso identificado por un URI
        //4. ConfigurationManager es una clase que proporciona acceso a los archivos de configuracion de la aplicacion(Web.config)
        //5. BaseAddress establece la direccion base para las solicitudes HTTP enviadas por el cliente
        //6. DefaultRequestHeaders.Accept.Clear() limpia cualquier encabezado de aceptacion previamente configurado
        //7. DefaultRequestHeaders.Accept.Add agrega un encabezado de aceptacion para indicar que el cliente espera recibir respuestas en formato JSON
        //7.1. MediaTypeWithQualityHeaderValue representa un valor de encabezado de tipo de medio con una calidad asociada
        //8. httpresponsemessage representa la respuesta HTTP recibida despues de enviar una solicitud HTTP
        //8.1. GetAsync envia una solicitud GET asincrona al URI especificado (parametro)
        //9. IsSuccessStatusCode indica si la respuesta HTTP fue exitosa (codigo de estado 2xx)
        //10. await indica que el metodo debe esperar de manera asincrona hasta que la tarea se complete
        //10.1. readAsAsync lee el contenido HTTP y lo deserializa en el tipo especificado (parametro)
        //11. ModelState.AddModelError agrega un error de validacion al estado del modelo
        //12. Enumerable.Empty devuelve una secuencia vacia del tipo especificado (parametro)

        [HttpPost]
        public async Task<ActionResult> NombrePaises(string nombrePais, string codigoPais, string langPais)
        {

            IEnumerable<Paises.Country> pais = null;

            using (var client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(nombrePais))
                {
                    var baseUrl = ConfigurationManager.AppSettings["ApiCountries"];
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage resp = await client.GetAsync(nombrePais);

                    if (resp.IsSuccessStatusCode)
                    {
                        pais = await resp.Content.ReadAsAsync<IEnumerable<Paises.Country>>();
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Error al llamar la API.");
                        pais = Enumerable.Empty<Paises.Country>();
                    }
                }

                if (!string.IsNullOrEmpty(codigoPais))
                {
                    var baseUrl = ConfigurationManager.AppSettings["ApiCountriesCode"];
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage resp = await client.GetAsync(codigoPais);

                    if (resp.IsSuccessStatusCode)
                    {
                        pais = await resp.Content.ReadAsAsync<IEnumerable<Paises.Country>>();
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Error al llamar la API.");
                        pais = Enumerable.Empty<Paises.Country>();
                    }
                }

                if (!string.IsNullOrEmpty(langPais))
                {
                    var baseUrl = ConfigurationManager.AppSettings["ApiCountriesLang"];
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage resp = await client.GetAsync(langPais);

                    if (resp.IsSuccessStatusCode)
                    {
                        pais = await resp.Content.ReadAsAsync<IEnumerable<Paises.Country>>();
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Error al llamar la API.");
                        pais = Enumerable.Empty<Paises.Country>();
                    }
                }
            }

            return View(pais);
        }
    }
}

















