using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTank
{
    abstract class GameObjects
    {
        public GameObjectsPlace gameObjectsPlace { get; set; }
        public char Figure { get; set; }

        public GameObjectType gameObjectType { get; set; }
    }
}
