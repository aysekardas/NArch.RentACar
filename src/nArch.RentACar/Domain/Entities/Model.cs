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

        public Brand? Brand { get; set; } = null;

        public Fuel? Fuel { get; set; } = null;

        public Transmission? Transmission { get; set; } = null; //one-to-one 

        public ICollection<Car>? Cars { get; set; } = null; //one-to many 

    }

}