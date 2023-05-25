using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NOVASystemR.Controllers
{
    public class BaseControllerMethods
    {
        const string cookieId = "usuarioId";
        const string cookieName = "nombreUsuario";

        public static int GetUsuarioId(HttpRequestBase request)
        {
            int usuarioId = -1;

            if (request.Cookies[cookieId] != null)
            {
                var cookie = request.Cookies[cookieId];
                cookie.Expires = DateTime.MaxValue;
                int.TryParse(cookie.Value, out usuarioId);
            }

            return usuarioId;
        }

        public static void SetUsuarioId(HttpResponseBase response, int usuarioId)
        {
            response.Cookies.Remove(cookieId);

            HttpCookie usuarioIdCookie = new HttpCookie(cookieId);

            usuarioIdCookie.Value = usuarioId.ToString();
            usuarioIdCookie.Expires = DateTime.Now.AddHours(1);
            response.Cookies.Add(usuarioIdCookie);
        }

        public static string GetNombreUsuario(HttpRequestBase request)
        {
            string nombreUsuario = "";

            if (request.Cookies[cookieName] != null)
            {
                var cookie = request.Cookies[cookieName];
                cookie.Expires = DateTime.MaxValue;
                nombreUsuario = cookie.Value;
            }

            return nombreUsuario;
        }

        public static void SetNombreUsuario(HttpResponseBase response, string nombreUsuario)
        {
            response.Cookies.Remove(cookieName);

            HttpCookie usuarioNameCookie = new HttpCookie(cookieName);

            usuarioNameCookie.Value = nombreUsuario;
            usuarioNameCookie.Expires = DateTime.Now.AddHours(1);
            response.Cookies.Add(usuarioNameCookie);
        }
    }
}