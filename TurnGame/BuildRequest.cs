using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnGame
{
    class BuildRequest
    {
        internal string UnitType { get; private set; }
        internal int TurnsRemaining { get; private set; }

        internal BuildRequest(string type, int turns)
        {
            UnitType = type;
            TurnsRemaining = turns;
        }

        internal void ProgressTurn()
        {
            TurnsRemaining = TurnsRemaining - 1;
        }

        internal bool IsReady()
        {
            return TurnsRemaining <= 0;
        }
    }
}
