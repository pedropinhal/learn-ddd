using System.Web.Mvc;
using Web.ApplicationServices;

namespace Web.Controllers
{
    public class DomainController : Controller
    {
        readonly ApplicationService _applicationService = new ApplicationService();
        // GET: Domain
        public ActionResult Index()
        {
            var model = _applicationService.GetFixtures();
            return View(model);
        }

        [HttpPost]
        public ActionResult Post()
        {
            _applicationService.CreateFixture();
            return RedirectToAction("Index");
        }
    }
}