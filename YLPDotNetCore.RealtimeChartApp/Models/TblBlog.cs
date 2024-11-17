using System;
using System.Collections.Generic;

namespace YLPDotNetCore.RealtimeChartApp.Models;

public partial class TblBlog
{
    public int BlogId { get; set; }

    public string? BlogTitle { get; set; }

    public string? BlogAuthor { get; set; }

    public string? BlogContent { get; set; }
}
