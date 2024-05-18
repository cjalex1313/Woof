using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Woof.Domain.Entities;

namespace Woof.DataAccess.DbMappings
{
    public static class ClinicDbMapping
    {
        public static void MapClinic(EntityTypeBuilder<Clinic> entity)
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.Name).HasMaxLength(256);
        }
    }
}
