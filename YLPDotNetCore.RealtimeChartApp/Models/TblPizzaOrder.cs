using System;
using System.Collections.Generic;

namespace YLPDotNetCore.RealtimeChartApp.Models;

public partial class TblPizzaOrder
{
    public int PizzaOrderId { get; set; }

    public string? PizzaOrderInvoiceNo { get; set; }

    public int? PizzaId { get; set; }

    public decimal? TotalAmount { get; set; }
}
