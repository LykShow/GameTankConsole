using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTank
{
    class TankMissleXAlienFactory:GameObjectsFactorias
    {
        public TankMissleXAlienFactory(GameSettings gameSettings) : base(gameSettings)
        {

        }

        public override GameObjects GetGameObjects(GameObjectsPlace gameObjectsPlace)
        {
            GameObjectsPlace missle = new GameObjectsPlace { XCoordinates = gameObjectsPlace.XCoordinates-1, YCoordinates = gameObjectsPlace.YCoordinates };
            GameObjects gameObjects = new TankMissleXAlien { Figure = gameSettings.MissleX, gameObjectsPlace = missle, gameObjectType = GameObjectType.TankMissleXAlien };
            return gameObjects;
        }
    }
}
