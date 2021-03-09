using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTank
{
    class TankMissleYDownFactory:GameObjectsFactorias
    {
        public TankMissleYDownFactory(GameSettings gameSettings) : base(gameSettings)
        {

        }

        public override GameObjects GetGameObjects(GameObjectsPlace GameObjectsPlace)
        {
            GameObjectsPlace missleobj = new GameObjectsPlace() { XCoordinates = GameObjectsPlace.XCoordinates, YCoordinates = GameObjectsPlace.YCoordinates+1 };
            GameObjects down = new TankMissleYDown { Figure = gameSettings.MissleDown, gameObjectsPlace = missleobj, gameObjectType = GameObjectType.TankMissle4 };
            return down;
        }
    }
}
