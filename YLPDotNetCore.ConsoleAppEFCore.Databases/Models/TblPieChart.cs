﻿using System;
using System.Collections.Generic;

namespace YLPDotNetCore.ConsoleAppEFCore.Databases.Models;

public partial class TblPieChart
{
    public int PieChartId { get; set; }

    public string PieChartName { get; set; } = null!;

    public decimal PieChartValue { get; set; }
}
