using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTank
{
    class Scene
    {
       public GameObjects _tank { get; set; }
        public List<GameObjects> _missle { get; set; }
        public List<GameObjects> missleXright { get; set; }
        public List<GameObjects> missleXLeft { get; set; }
        public List<GameObjects> tankenemy { get; set; }
        public List<GameObjects> missledown { get; set; }
        public List<GameObjects> missleXAlien { get; set; }
        public List<GameObjects> missleYUpAlien { get; set; }
        public GameObjects tankalien { get; set; }

        private static Scene _scene;
        private Scene() { }

        private Scene(GameSettings gameSettings)
        {
            _tank = new TankFactorias(gameSettings).GetObjects();
            _missle = new List<GameObjects>();
            missleXright = new List<GameObjects>();
            missleXLeft = new List<GameObjects>();
            missledown = new List<GameObjects>();
            missleXAlien = new List<GameObjects>();
            missleYUpAlien = new List<GameObjects>();
            tankenemy = new TankEnemyFactory(gameSettings).GetTankEnemy();
            tankalien = new TankAlienFactory(gameSettings).GetAlienTank();
        }
        public static Scene GetScene(GameSettings gameSettings)
        {
            if (_scene == null)
            {
                _scene = new Scene(gameSettings);
            }
            return _scene;
        }
        
    }
}
