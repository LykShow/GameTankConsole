using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTank
{
    class SceneReading
    {
        int ConsoleWieght;
        int ConsoleHeight;
        char[,] _sceneMatrix;

        public SceneReading(GameSettings gameSettings)
        {
            ConsoleWieght = gameSettings.ConsoleWidth;
            ConsoleHeight = gameSettings.ConsoleHight;
            _sceneMatrix=new char[gameSettings.ConsoleHight, gameSettings.ConsoleWidth];
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }
        public void Render(Scene scene)
        {
            Console.SetCursorPosition(0, 0);

            AddListForRendering(scene.missleXLeft);
            AddListForRendering(scene._missle);
            AddListForRendering(scene.missleXright);
            AddGameObjectForRendering(scene._tank);
            AddListForRendering(scene.tankenemy);
            AddListForRendering(scene.missledown);
            AddGameObjectForRendering(scene.tankalien);
            AddListForRendering(scene.missleXAlien);
            AddListForRendering(scene.missleYUpAlien);

            StringBuilder stringBuilder = new StringBuilder();
            for (int y = 0; y < ConsoleHeight; y++)
            {
                for (int x = 0; x < ConsoleWieght; x++)
                {
                    stringBuilder.Append(_sceneMatrix[y, x]);
                }
                stringBuilder.Append(Environment.NewLine);
            }
            Console.WriteLine(stringBuilder.ToString());
            Console.SetCursorPosition(0, 0);
        }
        public void AddGameObjectForRendering(GameObjects gameObject)
        {
            if (gameObject.gameObjectsPlace.YCoordinates < _sceneMatrix.GetLength(0) && gameObject.gameObjectsPlace.XCoordinates < _sceneMatrix.GetLength(1))
            {
                _sceneMatrix[gameObject.gameObjectsPlace.YCoordinates, gameObject.gameObjectsPlace.XCoordinates] = gameObject.Figure;

            }
           
        }
        public void AddListForRendering(List<GameObjects> gameObjects)
        {
            foreach(GameObjects gameObjects1 in gameObjects)
            {
                AddGameObjectForRendering(gameObjects1);
            }
        }
        public void ClearConsole()
        {
            
            for (int y = 0; y < ConsoleHeight; y++)
            {
                for (int x = 0; x < ConsoleWieght; x++)
                {
                    _sceneMatrix[y, x] = ' ';
                }
               
            }
            
            Console.SetCursorPosition(0, 0);
        }
        

    }
}
