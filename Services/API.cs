using Pokedex_app.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pokedex_app.Services
{
    internal class API
    {
        public static HttpClient Client { get;  set; } = new();
        public List<Pokemon> Items { get; private set; } = new ();
        public static async Task<List<Pokemon>> GetPokemons()
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Alert", "vous etes offline", "OK");
                return null;
            }
            // Définit la durée d'attente avant l'expiration de la requête  à 30 secondes
            Client.Timeout=TimeSpan.FromSeconds(30);
            HttpResponseMessage responseMessage = null;
            try
            {
                 responseMessage = await Client.GetAsync(@"https://pokebuildapi.fr/api/v1/pokemon");
            }catch(Exception ex)
            {
                // Affiche une alerte en cas d'erreur et retourne null
                await Shell.Current.DisplayAlert("Error", "Error", "OK");
            }
            string data = await responseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Pokemon>>(data, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
        }

    }
}
