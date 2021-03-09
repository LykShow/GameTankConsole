using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameTank
{
    class Program
    {
        static GameEngine gameEngine;
        static GameSettings gameSettings;
        static UIControler uIControler;
        static void Main(string[] args)
        {
            Initialize();
            gameEngine.Run();
            Console.ReadLine();
        }
        public static void Initialize()
        {
            gameSettings = new GameSettings();
            gameEngine = GameEngine.GetGameEngine(gameSettings);
            uIControler = new UIControler(gameEngine);
            Thread thread = new Thread(uIControler.StartMove);
            thread.Start();

        }
    }
}
