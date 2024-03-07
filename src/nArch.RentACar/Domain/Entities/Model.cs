using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public class Model : Entity<Guid>
    {
        public Model() { }

        public short Year { get; set; }

        public decimal DailyPrice { get; set; }

        public Guid BrandId { get; set; }

        public Guid FuelId { get; set; }
        public Guid TransmissionId { get; set; }

        public virtual Brand? Brand { get; set; } = default!;

        public virtual Fuel? Fuel { get; set; } = default!;

        public  virtual Transmission? Transmission { get; set; } = default!; //one-to-one 

        public virtual ICollection<Car>? Cars { get; set; } = default!; //one-to many 

    }

}