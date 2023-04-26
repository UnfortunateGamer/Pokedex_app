using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_app.Models
{
    public class Pokemon
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
