using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TuringMachine.Exceptions;
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
        public IActionResult Index(string turingMachineJson, bool edit = false)
        {
            if (edit)
            {
                ViewBag.Json = turingMachineJson?.Replace("\"", "\\\"");
                return View("Index");
            }
            try
            {
                var turingMachineModel = JsonConvert.DeserializeObject<TuringMachineModel>(turingMachineJson);
                var executingSnapshots = TuringMachineRunner.Run(turingMachineModel);
                turingMachineModel.ExecutingSnapshots = executingSnapshots;
                ViewBag.Json = JsonConvert.SerializeObject(turingMachineModel).Replace("\"", "\\\"");
            }
            catch (Exception e)
            {
                ViewBag.Json = turingMachineJson?.Replace("\"", "\\\"");
                ViewBag.Error = (e as ITuringMachineException)?.Message ?? "Invalid Turing Machine configuration";
                return View("Index");
            }
            return View("Run");
        }
    }
}
