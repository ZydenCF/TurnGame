using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnGame
{
    abstract class Unit : IUnit
    {
        protected int health;
        protected int damage;

        protected Unit(int hp, int dmg)
        {
            health = hp;
            damage = dmg;
        }

        public bool IsAlive()
        {
            return health > 0;
        }

        public void TakeDamage(int amount)
        {
            health = health - amount;
            if (health < 0)
            {
                health = 0;
            }
        }

        public abstract void Attack(Base targetBase, List<IUnit> enemyUnits);
    }
}
