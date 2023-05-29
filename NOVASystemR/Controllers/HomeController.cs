using AccesoDatos.Conexion;
using Entidades;
using LogicaNegocio;
using LogicaNegocio.Enum;
using NOVASystemR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SelectPdf;
using System.Collections.Specialized;
using System.Configuration;

namespace NOVASystemR.Controllers
{
    public class HomeController : BaseController
    {
        ConexionSQL conexion = new ConexionSQL();
        private readonly NameValueCollection SelectHtmlSettings = (NameValueCollection)ConfigurationManager.GetSection("appSettings");

        [AllowAnonymous]
        public ActionResult Index(MedicoModel model)
        {
            if (HttpContext.Session["Permisos"] == null || model.NombreMedico == null)
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


        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Entidades.SAI.Usuario oUsuario = new Entidades.SAI.Usuario();

                model.AutenticacionCorrecta = LogicaNegocio.WS_SAI.Seguridad.AutenticarUsuario(model.Dominio, model.CuentaRed, model.Contrasenia);
                model.AutenticacionCorrecta = true;
                if (model.AutenticacionCorrecta)
                {
                    if (Request.UrlReferrer.Query.Contains("red") && (Request.Url.AbsoluteUri.Contains("localhost") || Request.Url.AbsoluteUri.Contains("termxnvadb14/Nova/RRHH/SRH")))
                    {
                        var a = Request.UrlReferrer.Query.Split('&');
                        for (var i = 0; i < a.Length; i++)
                        {
                            if (a[i].ToString().Contains("red"))
                            {
                                var k = a[i].ToString().Split('=');
                                model.CuentaRed = k[1];
                            }
                        }
                    }
                    oUsuario = LogicaNegocio.WS_SAI.Seguridad.ObtenerPermisos(model.CuentaRed);
                    oUsuario.AutenticacionCorrecta = model.AutenticacionCorrecta;
                    Session["AutenticacionCorrecta"] = model.AutenticacionCorrecta;

                    List<PermisosModel> Permisos = Comun.ConvertToList<PermisosModel>(oUsuario.Permisos);
                    if (oUsuario.Permisos.Rows.Count > 0)
                        Session["Permisos"] = Permisos;

                    oUsuario.UsuarioId = (LogicaNegocio.NovaRH.Honorarios.Personal.Consultar(SqlOpciones.Actual, 0, string.Empty, 0, 0, model.CuentaRed).FirstOrDefault() ?? new Entidades.NovaRH.Honorarios.Personal() { PersonalId = oUsuario.UsuarioId }).PersonalId;
                    var Correo = LogicaNegocio.NovaRH.Honorarios.Medico.Consultar(SqlOpciones.Actual, model.CuentaRed);

                    if (Correo.Count <= 0)
                    {
                        return RedirectToAction("SinPermiso", "Home");
                    }

                    MedicoModel MedicoData = new MedicoModel()
                    {
                        IdPersonal = Correo[0].IdPersonal,
                        NombreMedico = Correo[0].NombreMedico,
                        Especialidad = Correo[0].Especialidad,
                        Universidad = Correo[0].Universidad,
                        CedulaProfesional = Correo[0].CedulaProfesional,
                        UniversidadEspecialidad = Correo[0].UniversidadEspecialidad,
                        CedulaEspecialidad = Correo[0].CedulaEspecialidad,
                        Estatus = Correo[0].Estatus
                    };


                    SetUsuarioId(oUsuario.UsuarioId);
                    SetNombreUsuario(oUsuario.NombreCompleto);

                    Session["Foto"] = oUsuario.Foto as byte[];

                    FormsAuthentication.SetAuthCookie(model.CuentaRed, false);
                    return View("Index", MedicoData);
                }
                else
                {
                    model.AutenticacionCorrecta = false;
                    return View(model);
                }
            }

            return View(model);
        }



        [AllowAnonymous]
        public ActionResult Logout()
        {
            foreach (var cookie in HttpContext.Request.Cookies.AllKeys)
            {
                HttpContext.Request.Cookies.Remove(cookie);
            }
            foreach (var cookie in HttpContext.Response.Cookies.AllKeys)
            {
                HttpContext.Response.Cookies.Remove(cookie);
            }

            HttpContext.Request.Cookies.Clear();
            HttpContext.Response.Cookies.Clear();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            SetNombreUsuario("");
            SetUsuarioId(-1);
            FormsAuthentication.SignOut();

            return Redirect("Login");
        }

        public ActionResult SinPermiso()
        {
            return View();
        }

        public ActionResult GeneratePdf(string nombrePaciente = "Nombre", string noSocio ="", string cveFamiliar="", string FechaNacimiento="", string nombreMedico="", string especialidad = "", string cedulaProfesional="", string uniCedProf="", string cedulaEspecialidad="", string uniCedEsp = "")
        {
            // Crear una instancia de HtmlToPdf
            var converter = new HtmlToPdf();

            //SelectPdf.GlobalProperties.LicenseKey = SelectHtmlSettings["LicenseKey"].ToString();

            // Configurar opciones del PDF
            converter.Options.PdfPageSize = PdfPageSize.A4;
            converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
            converter.Options.WebPageWidth = 1024; // Ancho de la página en píxeles
            converter.Options.WebPageHeight = 0; // Altura de la página en píxeles (0 para altura automática)

            // Crear el contenido HTML para el PDF
            string contenidoHtml = @"
    <!DOCTYPE html>
    <html>
    <head>
    </head>
    <body>
        <style>
            .nova-table {
                width: 100%;
                border-collapse: collapse;
                margin-bottom: 20px;
            }

            .nova-table th,
            .nova-table td {
                padding: 8px;
                border: 1px solid black;
                text-align: left;
            }

            .nova-table th {
                background-color: #f2f2f2;
            }
        </style>
        <div class='table-responsive'>
            <table class='nova-table table'>
                <tbody>
                    <tr>
                        <td colspan='4' class='nova-table-head bg-info text-white'>DATOS DEL PACIENTE</td>
                        <td colspan='4' class='nova-table-head bg-info text-white'>DATOS DEL MÉDICO</td>
                    </tr>
                    <tr>
                        <td colspan='2' rowspan='2'>Nombre:</td>
                        <td colspan='2' rowspan='2'>"+ nombrePaciente +  @"</td>
                        <td colspan='2'>Nombre:</td>
                        <td colspan='2'>"+ nombreMedico + @"</td>
                    </tr>
                    <tr>
                        <td colspan='2'>Especialidad</td>
                        <td colspan='2'>"+especialidad+@"</td>
                    </tr>
                    <tr>
                        <td>No. Socio:</td>
                        <td> "+noSocio+@"</td>
                        <td>Cve. Familiar:</td>
                        <td>"+cveFamiliar+@"</td>
                        <td>Cédula Profesional</td>
                        <td>"+cedulaProfesional+@"</td>
                        <td>Universidad</td>
                        <td>"+uniCedProf+@"</td>
                    </tr>
                    <tr>
                        <td colspan='2'>Fecha de nacimiento</td>
                        <td colspan='2'>"+FechaNacimiento+@"</td>
                        <td>Cédula Especialidad</td>
                        <td>"+cedulaEspecialidad+@"</td>
                        <td>Universidad</td>
                        <td>"+uniCedEsp+@"</td>
                    </tr>
                    <tr>
                        <td colspan='8'></td>
                    </tr>
                    <tr>
                        <td colspan='2'>CANTIDAD A SURTIR</td>
                        <td colspan='6'>PRESCRIPCIÓN</td>
                    </tr>
                    <tr>
                        <td colspan='2'></td>
                        <td colspan='6'></td>
                    </tr>
                    <tr>
                        <td colspan='2'></td>
                        <td colspan='6'></td>
                    </tr>
                    <tr>
                        <td colspan='2'></td>
                        <td colspan='6'></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </body>
    </html>";

            // Realizar la conversión del contenido HTML en PDF
            PdfDocument doc = converter.ConvertHtmlString(contenidoHtml);

            // Guardar el PDF en una ubicación específica
            string filePath = Server.MapPath("~/Content/GeneratedPdf.pdf");
            doc.Save(filePath);
            doc.Close();

            // Descargar el PDF generado
            return File(filePath, "application/pdf", "GeneratedPdf.pdf");
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