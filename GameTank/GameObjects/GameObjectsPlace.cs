using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTank
{
    class GameObjectsPlace
    {
        public int XCoordinates { get; set; }
        public int YCoordinates { get; set; }

        public override bool Equals(object obj)
        {
            GameObjectsPlace gameObjectsPlace = obj as GameObjectsPlace;
            if(gameObjectsPlace != null && gameObjectsPlace.XCoordinates == this.XCoordinates && gameObjectsPlace.YCoordinates==this.YCoordinates)
            {
                return true;
            }

            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
