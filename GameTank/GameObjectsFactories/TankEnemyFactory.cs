using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTank
{
    class TankEnemyFactory:GameObjectsFactorias
    {
      public TankEnemyFactory(GameSettings gameSettings) : base(gameSettings)
        {

        }

        public override GameObjects GetGameObjects(GameObjectsPlace GameObjectsPlace)
        {
            GameObjects tankenemy = new TankEnemy() { Figure = gameSettings.TankEnemyFig, gameObjectsPlace = GameObjectsPlace, gameObjectType = GameObjectType.TankEnemy };
            return tankenemy;
        }
        public List<GameObjects> GetTankEnemy()
        {
            List<GameObjects> tankenemy = new List<GameObjects>();
            int startX = gameSettings.TankEnemyX;
            int startY = gameSettings.TankEnemyY;
            for(int y = 0; y<gameSettings.TankEnemyNumberY; y++)
            {
                for(int x=0; x<gameSettings.TankEnemyNumberX; x++)
                {
                    GameObjectsPlace gameObjectsPlace = new GameObjectsPlace() { XCoordinates = startX+x, YCoordinates = startY+y };
                    GameObjects tank = GetGameObjects(gameObjectsPlace);
                    tankenemy.Add(tank);
                }
            }
            return tankenemy;
           
        }
    }
}
