using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Woof.BusinessLogic.Clinic;

namespace Woof.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicsController : ControllerBase
    {
        private readonly IClinicService _clinicService;

        public ClinicsController(IClinicService clinicService)
        {
            this._clinicService = clinicService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Domain.Entities.Clinic>> Get()
        {
            return Ok(_clinicService.GetAllClinics());
        }
    }
}
