using BeerDBWebApplication.Context;
using BeerDBWebApplication.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;

namespace BeerDBWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public readonly BeerDbContext _beerDbContext;

        public IndexModel(ILogger<IndexModel> logger , BeerDbContext beerDbContext )
        {
            _logger = logger;
            _beerDbContext = beerDbContext;
        }

        public List<beers> Models { get; set; }

        public void OnGet()
        {
            Models = new List<beers>();


            using (var connection = new SqliteConnection("Data Source=beer.db"))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT id, brewery_id, name,cat_id,style_id,abv,ibu,srm,upc," +
                        "filepath,descript, add_user,last_mod FROM beers";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Models.Add(new beers
                            {
                                id = Convert.ToInt32(reader["id"]),
                                brewery_id = Convert.ToInt32(reader["brewery_id"]),
                                name = reader.GetString(2),
                                cat_id = Convert.ToInt32(reader["cat_id"]),
                                style_id = Convert.ToInt32(reader["style_id"]),
                                abv = Convert.ToDouble(reader["abv"]),
                                ibu = Convert.ToDouble(reader["ibu"]),
                                srm = Convert.ToDouble(reader["srm"]),
                                upc = Convert.ToInt32(reader["upc"]),
                                filepath = reader.GetString(9),
                                descript = reader.GetString(10),
                                add_user = Convert.ToInt32(reader["add_user"]),
                                last_mod = Convert.ToDateTime(reader["last_mod"]),
                            });
                        }
                    }
                }
            }
        }
    }
}