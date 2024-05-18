using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Woof.Domain.Entities
{
    public class Clinic
    {
        public int ID { get; set; }
        public required string Name { get; set; }
    }
}
