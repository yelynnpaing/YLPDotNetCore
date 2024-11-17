using System;
using System.Collections.Generic;

namespace YLPDotNetCore.RealtimeChartApp.Models;

public partial class TblPizzaOrderDetail
{
    public int PizzaOrderDetailId { get; set; }

    public string? PizzaOrderInvoiceNo { get; set; }

    public int? PizzaExtraId { get; set; }
}
