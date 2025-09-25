using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnGame
{
    abstract class Unit : IAttacker
    {
        protected int health;
        protected int damage;


        protected Unit(int hp, int dmg)
        {
            health = hp;
            damage = dmg;
        }


        internal bool IsAlive()
        {
            return health > 0;
        }


        internal void TakeDamage(int amount)
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
