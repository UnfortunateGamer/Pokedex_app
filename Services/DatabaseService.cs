using Pokedex_app.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_app.Services
{
    public class DatabaseService
    {
        public static SQLiteAsyncConnection Database;
        public static string DatabasePath=string.Concat(FileSystem.AppDataDirectory,"Pokemons.db3");
        public static ObservableCollection<Pokemon> LocalPokemons { get; set; } = new();
        private DatabaseService(){}

        public static async Task Init()
        {
            Database = new SQLiteAsyncConnection(DatabasePath, SQLiteOpenFlags.Create|SQLiteOpenFlags.ReadWrite|SQLiteOpenFlags.SharedCache);
            var result=await Database.CreateTableAsync<Pokemon>();
            List<Pokemon> list = await Database.Table<Pokemon>().ToListAsync();
            list.ForEach(pokemon=>LocalPokemons.Add(pokemon));
        }
        public static async Task<bool> SauvgarderPokemon(Pokemon pokemon)
        {
            try
            {
                var result = await Database.GetAsync<Pokemon>(pokemon.Id);
                return false;
            }catch (Exception ex){}
            await Database.InsertAsync(pokemon);
            LocalPokemons.Add(pokemon);
            return true;
        }
        public static async Task SupprimerPokemon(Pokemon pokemon)
        {
            await Database.DeleteAsync(pokemon);
            LocalPokemons.Remove(pokemon);
        }
    }
}
