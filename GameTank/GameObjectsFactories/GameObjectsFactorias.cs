using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTank
{
    abstract class GameObjectsFactorias
    {
        public GameSettings gameSettings { get; set; }

        public abstract GameObjects GetGameObjects(GameObjectsPlace gameObjectsPlace);

        public GameObjectsFactorias(GameSettings gameSettings)
        {
            this.gameSettings = gameSettings;
        }
    }
}
