using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            string typeNameEnemy = enemyPlayer.GetType().Name;

            if (attackPlayer.GetType().Name == nameof(Beginner))
            {
                attackPlayer.Health += 40;

                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }

            if (enemyPlayer.GetType().Name == nameof(Beginner))
            {
                enemyPlayer.Health += 40;

                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }

            attackPlayer.Health += attackPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);

            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);

            int damagePowerAttacker = attackPlayer.CardRepository.Cards.Sum(x => x.DamagePoints);

            int damagePowerEnemy = enemyPlayer.CardRepository.Cards.Sum(x => x.DamagePoints);

            while (true)
            {
                enemyPlayer.TakeDamage(damagePowerAttacker);

                if (enemyPlayer.Health == 0)
                {
                    break;
                }

                attackPlayer.TakeDamage(damagePowerEnemy);

                if (attackPlayer.Health == 0)
                {
                    break;
                }
            }
        }
    }
}