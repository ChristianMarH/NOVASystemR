using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NOVASystemR.Controllers
{
    public class BaseController : Controller
    {
        #region Protected Methods

        protected void SetUsuarioId(int usuarioId)
        {
            BaseControllerMethods.SetUsuarioId(Response, usuarioId);
        }

        protected int GetUsuarioId()
        {
            return BaseControllerMethods.GetUsuarioId(Request);
        }

        protected void SetNombreUsuario(string nombreUsuario)
        {
            BaseControllerMethods.SetNombreUsuario(Response, nombreUsuario);
        }

        protected string GetNombreUsuario()
        {
            return BaseControllerMethods.GetNombreUsuario(Request);
        }

        #endregion Protected Methods
    }
}
