using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueba.Cliente.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Clients";

            return View();
        }

        [ActionName("_sgh54ii")]
        [HttpPost]
        public JsonResult ObtenerTodos()
        {
            Resultado Res;
            try
            {
                var datos = new SvcClient.ClientClient().ObtenerTodos();
                Res = new Resultado((object)datos);
            }
            catch (Exception ex) {
                Res = new Resultado(ex);
            }
            return Json(Res);
        }

        [ActionName("_dihbaisg")]
        [HttpPost]
        public JsonResult ObtenerUno(string SharedKey)
        {
            Resultado Res;
            try
            {
                var datos = new SvcClient.ClientClient().ObtenerUno(SharedKey);
                Res = new Resultado((object)datos);
            }
            catch (Exception ex)
            {
                Res = new Resultado(ex);
            }
            return Json(Res);
        }

        [ActionName("_hisgdbai")]
        [HttpPost]
        public JsonResult Guardar(SvcClient.M_Clients Client)
        {
            Resultado Res;
            try
            {
                var datos = new SvcClient.ClientClient().Guardar(Client);
                Res = new Resultado((object)datos);
            }
            catch (Exception ex)
            {
                Res = new Resultado(ex);
            }
            return Json(Res);
        }

        [ActionName("_hb111gdi")]
        [HttpPost]
        public JsonResult Eliminar(string SharedKey)
        {
            Resultado Res;
            try
            {
                var datos = new SvcClient.ClientClient().Eliminar(SharedKey);
                Res = new Resultado((object)datos);
            }
            catch (Exception ex)
            {
                Res = new Resultado(ex);
            }
            return Json(Res);
        }

        [ActionName("_hbaisgdi")]
        [HttpPost]
        public JsonResult Actualizar(SvcClient.M_Clients Client)
        {
            Resultado Res;
            try
            {
                var datos = new SvcClient.ClientClient().Actualizar(Client);
                Res = new Resultado((object)datos);
            }
            catch (Exception ex)
            {
                Res = new Resultado(ex);
            }
            return Json(Res);
        }
    }

    public class Resultado {
        public Resultado(object Json) {
            this.Json = Json;
            state = true;
        }
        public Resultado(Exception ex) {
            this.Message = ex.Message;
        }

        public bool state = false;
        public object Json =null;
        public string Message = "";
    }
}
