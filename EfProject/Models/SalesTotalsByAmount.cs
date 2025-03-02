using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EfProject.Models;

public partial class SalesTotalsByAmount
{
    [Precision(14, 2)]
    public decimal? SaleAmount { get; set; }

    public int OrderId { get; set; }

    public string CompanyName { get; set; } = null!;

    public DateTime? ShippedDate { get; set; }
}
