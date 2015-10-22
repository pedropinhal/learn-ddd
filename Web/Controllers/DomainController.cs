using System.Web.Mvc;
using Web.ApplicationServices;

namespace Web.Controllers
{
    public class DomainController : Controller
    {
        private readonly IApplicationService _applicationService;

        public DomainController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

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