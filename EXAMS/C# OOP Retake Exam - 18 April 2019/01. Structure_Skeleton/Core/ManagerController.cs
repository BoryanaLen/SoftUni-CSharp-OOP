namespace PlayersAndMonsters.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.Cards;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;

    public class ManagerController : IManagerController
    {
        private PlayerRepository playerRepository;
        private CardRepository cardRepository;
        private BattleField battleField;

        public ManagerController()
        {
            this.playerRepository = new PlayerRepository();
            this.cardRepository = new CardRepository();
            this.battleField = new BattleField();
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = null;

            if(type == "Beginner")
            {
                player = new Beginner(new CardRepository(), username);
            }
            else if(type == "Advanced")
            {
                player = new Advanced(new CardRepository(), username);
            }

            playerRepository.Add(player);

            return $"Successfully added player of type {type} with username: {username}";
        }

        public string AddCard(string type, string name)
        {
            ICard card = null;

            if(type == "Magic")
            {
                card = new MagicCard(name);
            }
            else if(type == "Trap")
            {
                card = new TrapCard(name);
            }
            this.cardRepository.Add(card);

            return $"Successfully added card of type {type}Card with name: {name}";
        }

        public string AddPlayerCard(string username, string cardName)
        {
            ICard card = this.cardRepository.Find(cardName);

            IPlayer player = this.playerRepository.Find(username);

            if(player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            player.CardRepository.Add(card);

            return $"Successfully added card: {cardName} to user: {username}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attacker = this.playerRepository.Find(attackUser);

            IPlayer enemy = this.playerRepository.Find(enemyUser);

            if (attacker == null || enemy == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            this.battleField.Fight(attacker, enemy);

            return $"Attack user health {attacker.Health} - Enemy user health {enemy.Health}";
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var player in playerRepository.Players)
            {
                sb.AppendLine($"Username: {player.Username} - Health: {player.Health} - Cards {player.CardRepository.Cards.Count}");

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
                }

                sb.AppendLine("###");
            }

            return sb.ToString().Trim();

 
            // sb.AppendLine($"Username: {player.Username} - Health: {player.Health} – Cards {player.CardRepository.Cards.Count}");
            // с този код гърмят два теста. Тирето преди кардс е различно
        }
    }
}
