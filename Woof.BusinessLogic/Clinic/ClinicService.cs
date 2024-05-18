using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Woof.DataAccess;

namespace Woof.BusinessLogic.Clinic
{
    internal class ClinicService : IClinicService
    {
        private readonly WoofDbContext _dbContext;

        public ClinicService(WoofDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IEnumerable<Domain.Entities.Clinic> GetAllClinics()
        {
           return _dbContext.Clinics.ToList();
        }
    }
}
