using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTank
{
    class TankMissleYUpAlienFactory:GameObjectsFactorias
    {
        public TankMissleYUpAlienFactory(GameSettings gameSettings) : base(gameSettings)
        {

        }

        public override GameObjects GetGameObjects(GameObjectsPlace gameObjectsPlace)
        {
            GameObjectsPlace m = new GameObjectsPlace { XCoordinates = gameObjectsPlace.XCoordinates, YCoordinates = gameObjectsPlace.YCoordinates - 1 };
            GameObjects miss = new TankMissleYUpAlien { Figure = gameSettings.Missle, gameObjectsPlace = m, gameObjectType = GameObjectType.TankMissleYUpAlien };
            return miss;
        }
    }
}
