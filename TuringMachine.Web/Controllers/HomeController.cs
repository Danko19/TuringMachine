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
            return View("Index");
        }

        [HttpPost]
        public IActionResult Build(string turingMachineJson)
        {
            var turingMachineModel = JsonConvert.DeserializeObject<TuringMachineModel>(turingMachineJson);
            var executingSnapshots = TuringMachineRunner.Run(turingMachineModel);
            turingMachineModel.ExecutingSnapshots = executingSnapshots;
            ViewBag.Json = JsonConvert.SerializeObject(turingMachineModel).Replace("\"", "\\\"");
            return View("Run");
        }
    }
}
