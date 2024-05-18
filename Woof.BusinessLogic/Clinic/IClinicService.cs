using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Woof.BusinessLogic.Clinic
{
    public interface IClinicService
    {
        IEnumerable<Woof.Domain.Entities.Clinic> GetAllClinics();
    }
}
