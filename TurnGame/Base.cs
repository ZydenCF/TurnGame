using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnGame
{
    class Base
    {
        private int health;

        internal Base()
        {
            health = 100;
        }

        internal void TakeDamage(int dmg)
        {
            health = health - dmg;
            if (health < 0)
            {
                health = 0;
            }
        }

        internal bool IsAlive()
        {
            return health > 0;
        }

        internal int GetHealth()
        {
            return health;
        }
    }
}
