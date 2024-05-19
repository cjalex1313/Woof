using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Woof.Domain.DTOs;

namespace Woof.BusinessLogic.Clinic
{
    public interface IClinicService
    {
        IEnumerable<Domain.Entities.Clinic> GetAllClinics();

        int CreateClinic(ClinicDto clinicDto);
    }
}
