using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnGame
{
    class Harvester : Unit
    {
        internal Harvester() : base(20, 0) { }


        public override void Attack(Base targetBase, List<IUnit> enemyUnits)
        {
        }

        internal int Collect()
        {
            return 10;
        }
    }
}
