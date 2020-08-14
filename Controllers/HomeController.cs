using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FormSigmaDevelopers.Models;
using Microsoft.AspNetCore.Http;
using FormSigmaDevelopers.Interfaces;
using Microsoft.Extensions.Configuration;
using FormSigmaDevelopers.Utils;
using Newtonsoft.Json.Linq;

namespace FormSigmaDevelopers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFormService _formService;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IFormService formService, IConfiguration configuration)
        {
            _logger = logger;
            _formService = formService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ResultResponse> GetDetpCity()
        {
            ResultResponse result = await _formService.GetCatalog();

            return result;
        }

        [HttpPost]
        public async Task<IActionResult> FormAdmin(Contacts datos)
        {
            ResultResponse result = new ResultResponse();
            if (ModelState.IsValid)
            {


                var res = await _formService.SaveForm(datos);

                if (res.Codigo.Equals("01"))
                {
                    result.Codigo = "01";
                    result.Descripcion = "Tu información ha sido recibida satisfactoriamente";
                }
                else
                {
                    result.Codigo = "02";
                    result.Descripcion = res.Codigo == "03" ? res.Descripcion : "¡Oops Algo salió mal, intenta de nuevo!";
                    result.DetalleError = res.DetalleError ?? "";
                }

                ModelState.Clear();


            }
            else
            {
                result.Codigo = "02";
                result.Descripcion = "¡Oops Algo salió mal, intenta de nuevo!";

            }

            return new JsonResult(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
