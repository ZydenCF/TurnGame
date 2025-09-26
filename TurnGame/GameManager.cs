using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnGame
{
    class GameManager
    {
        private List<IUnit> playerUnits;
        private List<IUnit> enemyUnits;
        private Base[] bases;
        private int playerResources;
        private Queue<BuildRequest> buildQueue;
        private Stack<string> history;
        private Dictionary<string, int> unitCosts;
        private int turnCounter;

        internal GameManager()
        {
            playerUnits = new List<IUnit>();
            enemyUnits = new List<IUnit>();
            bases = new Base[2];
            bases[0] = new Base(); 
            bases[1] = new Base(); 
            playerResources = 100; 
            buildQueue = new Queue<BuildRequest>();
            history = new Stack<string>();
            unitCosts = new Dictionary<string, int>();
            unitCosts["Soldier"] = 15; 
            unitCosts["Harvester"] = 10; 
            turnCounter = 0;
        }

        internal void Run()
        {
          
            Console.WriteLine("The soldier costs 15 resources, the harvester costs 10 resources.");
            Console.WriteLine();

            while (bases[0].IsAlive() && bases[1].IsAlive())
            {
                turnCounter = turnCounter + 1;
                Console.WriteLine("=== Turn " + turnCounter + " ===");
                Console.WriteLine($"Player Base Health: {bases[0].GetHealth()}, Enemy Base Health: {bases[1].GetHealth()}");

                PlayerTurn();
                if (!bases[1].IsAlive())
                {
                    Console.WriteLine("WINNER");
                    break;
                }

                EnemyTurn();
                if (!bases[0].IsAlive())
                {
                    Console.WriteLine("LOSER");
                    break;
                }

                Console.WriteLine();
            }
        }

        private void PlayerTurn()
        {
            
            foreach (IUnit u in playerUnits)
            {
                Harvester h = u as Harvester;
                if (h != null && h.IsAlive())
                {
                    playerResources = playerResources + h.Collect();
                }
            }

            
            int alivePlayers = playerUnits.Count(u => u.IsAlive());
            int aliveEnemies = enemyUnits.Count(u => u.IsAlive());
            Console.WriteLine($"Player resources: {playerResources}");
            Console.WriteLine($"Your alive units: {alivePlayers}, Enemy alive units: {aliveEnemies}");

            
            if (buildQueue.Count > 0)
            {
                BuildRequest req = buildQueue.Peek();
                req.ProgressTurn();
                if (req.IsReady())
                {
                    buildQueue.Dequeue();
                    if (req.UnitType == "Soldier")
                    {
                        playerUnits.Add(new Soldier());
                        Console.WriteLine("¡Soldier filled!");
                    }
                    else if (req.UnitType == "Harvester")
                    {
                        playerUnits.Add(new Harvester());
                        Console.WriteLine("¡Harvester filled!");
                    }
                }
            }

            
            Console.WriteLine("Choose unit to build (1 = Soldier, 2 = Harvester, other = skip):");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    TryBuildUnit("Soldier");
                    break;
                case "2":
                    TryBuildUnit("Harvester");
                    break;
                default:
                    Console.WriteLine("No unit built.");
                    break;
            }

            
            foreach (IUnit u in playerUnits.ToList())
            {
                if (u.IsAlive())
                {
                    u.Attack(bases[1], enemyUnits);
                }
            }

            
            playerUnits.RemoveAll(u => !u.IsAlive());
            enemyUnits.RemoveAll(u => !u.IsAlive());

            history.Push("Player turn completed");
        }

        private void TryBuildUnit(string type)
        {
            if (unitCosts.ContainsKey(type) && playerResources >= unitCosts[type])
            {
                playerResources = playerResources - unitCosts[type];
                buildQueue.Enqueue(new BuildRequest(type, 1));
                Console.WriteLine(type + " added to build queue.");
            }
            else
            {
                Console.WriteLine("Not enough resources.");
            }
        }

        private void EnemyTurn()
        {
            int unitsToBuild = Fibonacci(turnCounter);
            for (int i = 0; i < unitsToBuild; i++)
            {
                enemyUnits.Add(new Soldier());
            }
            Console.WriteLine("Enemy builds " + unitsToBuild + " soldiers.");

            
            foreach (IUnit u in enemyUnits.ToList())
            {
                if (u.IsAlive())
                {
                    u.Attack(bases[0], playerUnits);
                }
            }

            
            playerUnits.RemoveAll(u => !u.IsAlive());
            enemyUnits.RemoveAll(u => !u.IsAlive());

            history.Push("Enemy turn completed");
        }

        private int Fibonacci(int n)
        {
            if (n <= 0) return 0;
            if (n == 1) return 0;
            if (n == 2) return 1;

            int a = 0;
            int b = 1;
            for (int i = 3; i <= n; i++)
            {
                int c = a + b;
                a = b;
                b = c;
            }
            return b;
        }
    }
}
