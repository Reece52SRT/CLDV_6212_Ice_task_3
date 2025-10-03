using Microsoft.AspNetCore.Mvc;
using CLDV_6212_Ice_task_3.Models;
using CLDV_6212_Ice_task_3.Services;

namespace CLDV_6212_Ice_task_3.Controllers
{
    

    public class PersonsController : Controller
    {
        private readonly QueueService _queueService;
        public IActionResult Index()
        {
            return View();
        }

        public PersonsController(QueueService queueService)
        {
            _queueService = queueService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonMessage person)
        {
            if (ModelState.IsValid)
            {
                await _queueService.EnqueuePersonAsync(person);
                ViewBag.Message = "Message added to queue!";
            }

            return View();
        }
    }
}
