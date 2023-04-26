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
    public partial class MyListViewModel
    {
        public ObservableCollection<Pokemon> Pokemons => DatabaseService.LocalPokemons;
        public MyListViewModel()
        {
            Initialize();
        }
        private Task Initialize()
        {
            return Task.CompletedTask;
        }
        [RelayCommand]
        public async Task Supprimer(Pokemon pokemon)
        {
            await DatabaseService.SupprimerPokemon(pokemon);
            await Shell.Current.DisplayAlert("Supprission", "Suppession Effectue", "OK");
        }
    }
}
