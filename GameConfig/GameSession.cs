﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConfig
{
    public class GameSession : INotifyPropertyChanged
    {
        private Player _player = new Player();
        private Pokemon _enemy = new Pokemon();
        private bool _isGameCreated;
        private int _losses;
        private double _winPercentage;
        private string _pokedexImage;
        public Player CurrentPlayer
        {
            get => _player;
            set
            {
                _player = value;
                OnPropertyChanged(nameof(CurrentPlayer));
            }
        }
        public Pokemon EnemyPokemon
        {
            get => _enemy;
            set
            {
                _enemy = value;
                OnPropertyChanged(nameof(EnemyPokemon));
            }
        }
        public bool IsGameCreated
        {
            get => _isGameCreated;
            set
            {
                _isGameCreated = value;
                OnPropertyChanged(nameof(IsGameCreated));
            }
        }
        public int Losses
        {
            get => _losses;
            set
            {
                _losses = value;
                OnPropertyChanged(nameof(Losses));
            }
        }
        public double WinPercentage
        {
            get => _winPercentage;
            set
            {
                _winPercentage = value;
                OnPropertyChanged(nameof(WinPercentage));
            }
        }
        public List<Pokemon> AllPokemon { get; set; }
        public string PokedexImage
        {
            get => _pokedexImage;
            set
            {
                _pokedexImage = value;
                OnPropertyChanged(nameof(PokedexImage));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<GameMessageEventArgs> Event;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void RaiseMessage(string message)
        {
            Event?.Invoke(this, new GameMessageEventArgs(message));
        }
    }
}
