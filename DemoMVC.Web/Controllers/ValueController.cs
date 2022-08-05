using DemoMVC.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.Web.Controllers
{
    public class ValueController : Controller
    {
        private Value value = new Value();

        public string Index()
        {
            return value.GetValue()?.ToString() ?? "";
        }
    }
}
