using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTank
{
    class TankFactorias:GameObjectsFactorias
    {
        public TankFactorias(GameSettings gameSettings) : base(gameSettings)
        {

        }

        public override GameObjects GetGameObjects(GameObjectsPlace GameObjectsPlace)
        {
            GameObjects tank = new Tank() { Figure = gameSettings.TankFigure, gameObjectsPlace = GameObjectsPlace, gameObjectType = GameObjectType.Tank };
            return tank;
        }
        public GameObjects GetObjects()
        {
            int startX = gameSettings.TankstartXcoordinates;
            int startY = gameSettings.TankstartYcoordinates;
            GameObjectsPlace gameObjectsPlace = new GameObjectsPlace() { XCoordinates = startX, YCoordinates = startY };
            GameObjects tank = GetGameObjects(gameObjectsPlace);
            return tank;
        }
    }
}
