using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Customer : Entity<Guid>
{
    public Guid UserId  { get; set; }

    public virtual User? User { get; set; } = default!;
}
