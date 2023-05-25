using AccesoDatos.Conexion;
using LogicaNegocio.Enum;
using NOVASystemR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NOVASystemR.Controllers
{
    public class HomeController : BaseController
    {
        ConexionSQL conexion = new ConexionSQL();


        public ActionResult Index()
        {
            if (HttpContext.Session["Permisos"] == null)
            {
                if (HttpContext.Session["AutenticacionCorrecta"] != null && (bool)HttpContext.Session["AutenticacionCorrecta"])
                    return RedirectToAction("SinPermiso", "Home");
                return RedirectToAction("Logout", "Home");
            }

            bool esmedico = false;

            if (HttpContext.Session["Permisos"] != null)
            {
                var res = LogicaNegocio.NovaRH.Honorarios.Configuracion.Consultar(SqlOpciones.Seleccionar, "Perfil");

                HttpContext.Session["Perfiles"] = res;

                esmedico = (from i in ((IList<PermisosModel>)HttpContext.Session["Permisos"]).ToList()
                            join r in res on i.PerfilId.ToString().Trim() equals r.Valor.Trim()
                            where r.Nombre == "PerfilMedico"
                            select i.PerfilId).FirstOrDefault() != 0;
            }

            if (esmedico)
            {
                TempData["RedireccionMedico"] = true;
                DateTime fecha = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                return RedirectToAction("Index", "ReporteMensual", new { Area = "ReporteMensual", pPersonalId = GetUsuarioId(), pPeriodoMes = DateTime.Today, pFechaDesde = fecha, pFechaHasta = fecha.AddMonths(1).AddDays(-1) });
            }

            #region VARIABLES DE MENU
            TempData["lblNombre"] = GetNombreUsuario();
            if (HttpContext.Session["Foto"] != null)
                TempData["imgFoto"] = "data:image/jpg;base64," + Convert.ToBase64String((byte[])HttpContext.Session["Foto"]);
            #endregion

            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (HttpContext.Session["AutenticacionCorrecta"] != null && (bool)HttpContext.Session["AutenticacionCorrecta"])
            {
                return RedirectToAction("SinPermiso", "Home");
            }
            LoginModel model = new LoginModel();
            var strDominioAlt = System.Configuration.ConfigurationManager.AppSettings["Dominio"];

            if (strDominioAlt == "TERNIUM")
            {
                model.Dominio = Environment.UserDomainName;
            }
            else
            {
                model.Dominio = strDominioAlt;
            }
            //model.CuentaRed = Environment.UserName;
            model.AutenticacionCorrecta = true;

            return View(model);
        }

        //public ActionResult Index()
        //{

        //    bool conexionExitosa = conexion.Conectar();
        //    if (conexionExitosa)
        //    {
        //        ViewBag.Mensaje = "Conexión exitosa a la base de datos";
        //    }
        //    else
        //    {
        //        ViewBag.Mensaje = "Error al conectar a la base de datos";
        //    }

        //    conexion.Desconectar();

        //    return View();
        //}


    }
}