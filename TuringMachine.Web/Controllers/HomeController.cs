using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TuringMachine.Web.Common;
using TuringMachine.Web.Models;

namespace TuringMachine.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Compile(string turingMachineJson)
        {
            var turingMachineModel = JsonConvert.DeserializeObject<TuringMachineModel>(turingMachineJson);
            var executingSnapshots = TuringMachineRunner.Run(turingMachineModel);
            return Index();
        }
    }
}
