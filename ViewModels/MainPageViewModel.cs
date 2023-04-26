using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pokedex_app.Models;
using Pokedex_app.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_app.ViewModels
{
    public partial class MainPageViewModel:ObservableObject
    {
        [ObservableProperty]
        bool isBusy;
        public ObservableCollection<Pokemon> Pokemons { get; set; } = new();

        public MainPageViewModel()
        {
            Inisialize();
        }
        public async Task Inisialize()
        {
            this.IsBusy = true;
            List<Pokemon> pokemons = await API.GetPokemons();
            this.IsBusy=false;
            foreach (Pokemon pokemon in pokemons)
            {
                this.Pokemons.Add(pokemon);
            }
           
        }
        [RelayCommand]
        public async Task Sauvgarder(Pokemon pokemon)
        {
            if(!await DatabaseService.SauvgarderPokemon(pokemon))
            {
                await Shell.Current.DisplayAlert("Message", "Deja Sauvgarder", "OK");
                return;
            }
            await Shell.Current.DisplayAlert("Message", "Sauvgard Effectue", "OK");
        }
    }
}
