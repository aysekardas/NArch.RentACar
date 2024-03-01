using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations;
public class TransmissionConfiguration : IEntityTypeConfiguration<Transmission>
{
        public void Configure(EntityTypeBuilder<Transmission> builder)
        {
            builder.HasKey(i => i.Id);
            builder.ToTable("Transmissions");
        }
    
}