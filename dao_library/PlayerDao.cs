using System.Collections.Generic;
using System.Linq;
using entity_library; 

namespace dao_library
{
    public class PlayerDao
    {
        //busca un jugador especifico en la lista por su Id
        public Player? GetPlayer(Player player)
        {
            return MockDatabase.Players.Find(p => p.Id == player.Id);
        }

        //agrega un nuevo jugador y se le asigna un id autonumérico
        public Player? PostPlayer(Player player) 
        {
            if (player != null)
            {
                player.Id = MockDatabase.Players.Count + 1;
                MockDatabase.Players.Add(player);
                return player;
            }
            return null;
        }

        //modifica los datos de un jugador existente en la lista
        public Player? PutPlayer(Player player)
        {
            var existingPlayer = MockDatabase.Players.Find(p => p.Id == player.Id);
            if (existingPlayer != null)
            {
                //actualiza campos de la persona
                existingPlayer.Name = player.Name;
                existingPlayer.Age = player.Age;
                existingPlayer.Dni = player.Dni;

                //actualiza campos de Player
                existingPlayer.Number = player.Number;
                existingPlayer.TeamList = player.TeamList; 

                return existingPlayer;
            }
            return null;
        }

        //devuelve la lista completa de jugadores
        public List<Player> GetPlayer()
        {
            return MockDatabase.Players;
        }

        //elimina un jugador de la lista si existe
        public bool DeletePlayer(Player player)
        {
            var existingPlayer = MockDatabase.Players.Find(p => p.Id == player.Id);
            if (existingPlayer != null)
            {
                MockDatabase.Players.Remove(existingPlayer);
                return true;
            }
            return false;
        }
    }
}