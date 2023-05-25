using AccesoDatos.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NOVASystemR.Controllers
{
    public class HomeController : Controller
    {
        ConexionSQL conexion = new ConexionSQL();


        public ActionResult Index()
        {

            bool conexionExitosa = conexion.Conectar();
            if (conexionExitosa)
            {
                ViewBag.Mensaje = "Conexión exitosa a la base de datos";
            }
            else
            {
                ViewBag.Mensaje = "Error al conectar a la base de datos";
            }

            conexion.Desconectar();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}