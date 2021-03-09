using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTank
{
    class UIControler
    {
        public GameEngine gameEngine;

        public UIControler(GameEngine gameEngine)
        {
            this.gameEngine = gameEngine;
        }
        public void StartMove()
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key.Equals(ConsoleKey.A))
                {
                    gameEngine.LeftMove();
                }
                else if (key.Key.Equals(ConsoleKey.D))
                {
                    
                    gameEngine.RightMove();
                }
                else if (key.Key.Equals(ConsoleKey.W))
                {
                    gameEngine.UpMove();
                }
                else if (key.Key.Equals(ConsoleKey.S))
                {

                    gameEngine.DownMove();
                }
                else if (key.Key.Equals(ConsoleKey.Spacebar))
                {
                    if (gameEngine._scene._tank.Figure == '^')
                    {
                        gameEngine.Shoot();
                    }
                    else if (gameEngine._scene._tank.Figure == '>')
                    {
                        gameEngine.ShootXRight();
                    }
                    else if (gameEngine._scene._tank.Figure == '<')
                    {
                        gameEngine.ShootXLeft();
                    }
                    else if (gameEngine._scene._tank.Figure == '!')
                    {
                        gameEngine.ShootYDown();
                    }
                }
            }
        }
    }
}
