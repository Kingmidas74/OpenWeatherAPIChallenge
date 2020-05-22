using System.Collections.Generic;

namespace Domain
{
    public partial class Temperatures
    {
        public Coord Coord { get; set; }
        public List<Weather> Weather { get; set; }
        public string Base { get; set; }
        public Main Main { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public long Dt { get; set; }
        public Sys Sys { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public long Cod { get; set; }
    }

    public partial class Clouds
    {
        public long All { get; set; }
    }

    public partial class Coord
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }

    public partial class Main
    {
        public double Temp { get; set; }
        public double Pressure { get; set; }
        public long Humidity { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public double SeaLevel { get; set; }
        public double GrndLevel { get; set; }
    }

    public partial class Sys
    {
        public double Message { get; set; }
        public string Country { get; set; }
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
    }

    public partial class Weather
    {
        public long Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public partial class Wind
    {
        public double Speed { get; set; }
        public long Deg { get; set; }
    }
}