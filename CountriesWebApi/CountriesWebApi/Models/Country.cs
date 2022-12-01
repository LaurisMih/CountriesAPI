namespace CountriesWebApi.Models
{
    public class Country
    {
        public string name { get; set; }
        public List<string> topLevelDomain { get; set; }
        public double area { get; set; }
        public int population { get; set; }
        public string nativeName { get; set; }
        public bool independent { get; init; }
    }
}