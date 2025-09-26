using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnGame
{
    interface IUnit : IAttacker
    {
        bool IsAlive();
        void TakeDamage(int amount);
    }
}
