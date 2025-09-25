using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnGame
{
    interface IAttacker
    {
        void Attack(Base targetBase, List<IUnit> enemyUnits);
    }
}
