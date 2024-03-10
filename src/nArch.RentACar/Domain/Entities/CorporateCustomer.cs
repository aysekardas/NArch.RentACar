using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CorporateCustomer : Entity<Guid>
{
    public Guid CustomerId { get; set; }
    public string CompanyName { get; set; }
    public string TaxNo { get; set; }

    public virtual User? User { get; set; } = default!;
    public virtual Customer? Customer { get; set; } = default!;

}
