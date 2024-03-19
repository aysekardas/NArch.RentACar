using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Rental : Entity<Guid>
{
    public Guid CustomerID { get; set; }

    public Guid CarID { get; set; }
    public string TotalCost { get; set; }

    public DateTime RentStartDate { get; set; }
    public DateTime RentEndDate { get; set; }

    public virtual Car Car { get; set; } = null!;
    public virtual Customer Customer { get; set; } = null!;


}
