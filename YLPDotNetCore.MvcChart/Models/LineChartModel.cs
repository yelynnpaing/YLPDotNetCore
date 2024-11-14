namespace YLPDotNetCore.MvcChart.Models
{
    public class LineChartModel
    {
        public List<Series> SeriesList { get; set; }
        public List<int> Categories { get; set; }   
        public LineChartModel(List<Series> seriesList, List<int> categories) 
        {
            this.SeriesList = seriesList;
            this.Categories = categories;
        }

    }

    public class Series
    {
        public string name { get; set; }
        public List<double> data { get; set; }
        public Series(string name, List<double> data)
        {
            this.name = name;
            this.data = data;
        }
    }
}
