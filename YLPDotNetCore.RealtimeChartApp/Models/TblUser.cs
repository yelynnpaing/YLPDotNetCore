using System;
using System.Collections.Generic;

namespace YLPDotNetCore.RealtimeChartApp.Models;

public partial class TblUser
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public bool? IsAdmin { get; set; }
}
