using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTank
{
    class TankMissleFactory:GameObjectsFactorias
    {
        public TankMissleFactory(GameSettings gameSettings) : base(gameSettings)
        {

        }
        public override GameObjects GetGameObjects(GameObjectsPlace GameObjectsPlace)
        {
            GameObjectsPlace missleObj = new GameObjectsPlace() { XCoordinates = GameObjectsPlace.XCoordinates, YCoordinates = GameObjectsPlace.YCoordinates };
            GameObjects missle = new Tank() { Figure = gameSettings.Missle, gameObjectsPlace = missleObj, gameObjectType = GameObjectType.TankMissle };
            return missle;
        }
    }
}
