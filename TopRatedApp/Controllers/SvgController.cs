using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TopRatedApp.Controllers
{
    public class SvgController : Controller
    {
        // GET: Svg
        public ActionResult GetBadge()
        {
            return PartialView("./../ConstSvg");
        }
    }
}