using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTank
{
    class TankMissleXRightFactory:GameObjectsFactorias
    {
        public TankMissleXRightFactory(GameSettings gameSettings) : base(gameSettings)
        {

        }

        public override GameObjects GetGameObjects(GameObjectsPlace gameObjectsPlace)
        {
            GameObjectsPlace missleobj = new GameObjectsPlace() { XCoordinates = gameObjectsPlace.XCoordinates + 1, YCoordinates = gameObjectsPlace.YCoordinates };
            GameObjects missle = new TankMissleXRight() { Figure = gameSettings.MissleX, gameObjectsPlace = missleobj, gameObjectType = GameObjectType.TankMissle2 };
            return missle;
        }
    }
}
