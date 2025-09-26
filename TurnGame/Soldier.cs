using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnGame
{
    class Soldier : Unit
    {
        internal Soldier() : base(30, 15) { } 

        public override void Attack(Base targetBase, List<IUnit> enemyUnits)
        {
            var aliveEnemies = enemyUnits.Where(u => u.IsAlive()).ToList();
            if (aliveEnemies.Count > 0)
            {
                aliveEnemies[0].TakeDamage(damage);
                Console.WriteLine($"Soldier attacks enemy unit for {damage} damage!");
            }
            else
            {
                targetBase.TakeDamage(damage);
                Console.WriteLine($"Soldier attacks enemy base for {damage} damage! Base health: {targetBase.GetHealth()}");
            }
        }
    }
}
