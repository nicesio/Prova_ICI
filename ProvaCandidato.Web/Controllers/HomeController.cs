using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProvaCandidato.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }
    public ActionResult ValidarData([Bind(Prefix = "model.DataNascimento")] DateTime? DataNascimento)
    {
        // validate your date here and return True if validated
        if (Convert.ToDateTime(DataNascimento) >= DateTime.Now)
        {
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        return Json(true, JsonRequestBehavior.AllowGet);
    }
    }
}