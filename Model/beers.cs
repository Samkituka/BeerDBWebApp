namespace BeerDBWebApplication.Model
{
    public class beers
    {
        public int id { get; set; }
        public int brewery_id { get; set; }
        public string name { get; set; }
        public int cat_id { get; set; }
        public int style_id { get; set; }
        public double abv { get; set; }
        public double ibu { get; set; }
        public double srm { get; set; }
        public int upc { get; set; }
        public string filepath { get; set; }
        public string descript { get; set; }
        public int add_user { get; set; }
        public DateTime last_mod { get; set; }
    }
}
