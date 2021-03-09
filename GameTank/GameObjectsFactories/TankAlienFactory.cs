using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTank
{
    class TankAlienFactory:GameObjectsFactorias
    {
        public TankAlienFactory(GameSettings gameSettings) : base(gameSettings)
        {

        }

        public override GameObjects GetGameObjects(GameObjectsPlace GameObjectsPlace)
        {
            GameObjects alien = new TankAlien { Figure = gameSettings.FigureTankAlien, gameObjectsPlace = GameObjectsPlace, gameObjectType = GameObjectType.TankAlien };
            return alien;
        }
        public GameObjects GetAlienTank()
        {
          
            int startX = gameSettings.TankAlienX;
            int startY = gameSettings.TankAienY;
            GameObjectsPlace gameObjectsPlace = new GameObjectsPlace { XCoordinates = startX, YCoordinates = startY };
            GameObjects gameObjects1 = GetGameObjects(gameObjectsPlace);
           
            return gameObjects1;
        }
    }
}
