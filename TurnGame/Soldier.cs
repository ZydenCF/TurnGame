using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnGame
{
    class Soldier : Unit
    {
        internal Soldier() : base(30, 10) { }


        public override void Attack(Base targetBase, List<IUnit> enemyUnits)
        {
            if (enemyUnits.Count > 0)
            {
                enemyUnits[0].TakeDamage(damage);
            }
            else
            {
                targetBase.TakeDamage(damage);
            }
        }
    }
}
