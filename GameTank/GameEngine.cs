using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameTank
{
    class GameEngine
    {
        public Scene _scene;
        private SceneReading sceneReading;
        private GameSettings _gameSettings;
        private static GameEngine _gameEngine;
        private bool _isNotOwner;
        private GameEngine()
        {

        }
        private GameEngine(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            _scene = Scene.GetScene(gameSettings);
            sceneReading = new SceneReading(gameSettings);
            _isNotOwner = true;
        }
        public static GameEngine GetGameEngine(GameSettings gameSettings)
        {
            if(_gameEngine == null)
            {
                _gameEngine = new GameEngine(gameSettings);
            }
            return _gameEngine;
        }
        public void Run()
        {
            
            int missleMove = 0;
            int alienmove = 0;
            do
            {
                
                sceneReading.Render(_scene);

                Thread.Sleep(_gameSettings.GameSpeed);
                sceneReading.ClearConsole();
                
                if(alienmove == _gameSettings.SpeedAlien)
                {
                    Move();
                    alienmove = 0;
                }
                alienmove++;
                if(missleMove == _gameSettings.MissleSpeed)
                {
                    ShootMove();
                    ShootMoveXRight();
                    ShootMoveXLeft();
                    ShootMoveYDown();
                    ShootYUpAlienMissle();
                    ShootXLeftAlien();
                    
                    
                    missleMove = 0;
                }
                missleMove++;
                

            } while (_isNotOwner);
        }
        public void RightMove()
        {
            if (_scene._tank.gameObjectsPlace.XCoordinates < _gameSettings.ConsoleWidth)
            {
                _scene._tank.Figure = '>';
                
                _scene._tank.gameObjectsPlace.XCoordinates++;
            }
        }
        public void LeftMove()
        {
            if (_scene._tank.gameObjectsPlace.XCoordinates >1)
            {
                _scene._tank.Figure = '<';
                _scene._tank.gameObjectsPlace.XCoordinates--;
            }
        }
        public void UpMove()
        {
            if (_scene._tank.gameObjectsPlace.YCoordinates < _gameSettings.ConsoleHight)
            {
                _scene._tank.Figure = '^';
                
                _scene._tank.gameObjectsPlace.YCoordinates--;
            }
        }
        public void DownMove()
        {
            
            if (_scene._tank.gameObjectsPlace.YCoordinates >1)
            {
                _scene._tank.Figure = '!';
                _scene._tank.gameObjectsPlace.YCoordinates++;
            }
        }
        public void Move()
        {
            Random ran = new Random();
            int val = ran.Next(1, 5);
            int bal = ran.Next(0, 3);
            
            if (val == 1)
            {
                _scene.tankalien.Figure = '>';
                _scene.tankalien.gameObjectsPlace.XCoordinates++;
                if(bal == 2)
                {
                    ShootYUpAlien();
                }
                if(_scene.tankalien.gameObjectsPlace.XCoordinates == 1 || _scene.tankalien.gameObjectsPlace.XCoordinates == _gameSettings.ConsoleWidth || _scene.tankalien.gameObjectsPlace.YCoordinates == 1 || _scene.tankalien.gameObjectsPlace.YCoordinates == _gameSettings.ConsoleHight)
                {
                    _scene.tankalien.gameObjectsPlace.XCoordinates--;
                }
               
            }
            else if (val == 2)
            {
                
                _scene.tankalien.Figure = '<';
                _scene.tankalien.gameObjectsPlace.XCoordinates--;
                if(bal == 2) { 
                 ShootXAlienLeft();
                 }
                
                if (_scene.tankalien.gameObjectsPlace.XCoordinates == 1 || _scene.tankalien.gameObjectsPlace.XCoordinates == _gameSettings.ConsoleWidth || _scene.tankalien.gameObjectsPlace.YCoordinates == 1 || _scene.tankalien.gameObjectsPlace.YCoordinates == _gameSettings.ConsoleHight)
                {
                    _scene.tankalien.gameObjectsPlace.XCoordinates++;
                   
                }
            }
            else if (val == 3)
            {
                _scene.tankalien.Figure = '^';
                _scene.tankalien.gameObjectsPlace.YCoordinates--;
                if (_scene.tankalien.gameObjectsPlace.XCoordinates == 1 || _scene.tankalien.gameObjectsPlace.XCoordinates == _gameSettings.ConsoleWidth || _scene.tankalien.gameObjectsPlace.YCoordinates == 1 || _scene.tankalien.gameObjectsPlace.YCoordinates == _gameSettings.ConsoleHight)
                {
                    _scene.tankalien.gameObjectsPlace.YCoordinates++;
                }
            }
            else if(val == 4)
            {
                _scene.tankalien.Figure = '!';
                _scene.tankalien.gameObjectsPlace.YCoordinates++;
                if (_scene.tankalien.gameObjectsPlace.XCoordinates == 1 || _scene.tankalien.gameObjectsPlace.XCoordinates == _gameSettings.ConsoleWidth || _scene.tankalien.gameObjectsPlace.YCoordinates == 1 || _scene.tankalien.gameObjectsPlace.YCoordinates == _gameSettings.ConsoleHight)
                {
                    _scene.tankalien.gameObjectsPlace.YCoordinates--;
                }
            }
        }
        public void Shoot()
        {
            TankMissleFactory missleFactory = new TankMissleFactory(_gameSettings);
            GameObjects gameObjects = missleFactory.GetGameObjects(_scene._tank.gameObjectsPlace);
            _scene._missle.Add(gameObjects);
            


        }
        public void ShootXRight()
        {
            TankMissleXRightFactory missleFactory = new TankMissleXRightFactory(_gameSettings);
            GameObjects gameObjects = missleFactory.GetGameObjects(_scene._tank.gameObjectsPlace);
            _scene.missleXright.Add(gameObjects);
            


        }
        public void ShootXLeft()
        {
            TankMissleXLeftFactory missleFactory = new TankMissleXLeftFactory(_gameSettings);
            GameObjects gameObjects = missleFactory.GetGameObjects(_scene._tank.gameObjectsPlace);
            _scene.missleXLeft.Add(gameObjects);
            


        }
        public void ShootYDown()
        {
            TankMissleYDownFactory missleFactory = new TankMissleYDownFactory(_gameSettings);
            GameObjects gameObjects = missleFactory.GetGameObjects(_scene._tank.gameObjectsPlace);
            _scene.missledown.Add(gameObjects);
            


        }
        public void ShootXAlienLeft()
        {
           
                TankMissleXAlienFactory miss = new TankMissleXAlienFactory(_gameSettings);
                GameObjects gameObjects = miss.GetGameObjects(_scene.tankalien.gameObjectsPlace);
                _scene.missleXAlien.Add(gameObjects);
            
        }
        public void ShootYUpAlien()
        {

            TankMissleYUpAlienFactory miss = new TankMissleYUpAlienFactory(_gameSettings);
            GameObjects gameObjects = miss.GetGameObjects(_scene.tankalien.gameObjectsPlace);
            _scene.missleYUpAlien.Add(gameObjects);

        }
        public void ShootXLeftAlien()
        {
           
            if (_scene.missleXAlien.Count == 0)
            {
                return;
            }
           
                for (int x = 0; x < _scene.missleXAlien.Count; x++)
                {

                    GameObjects gameObjects = _scene.missleXAlien[x];

                    if (gameObjects.gameObjectsPlace.XCoordinates == 1 || gameObjects.gameObjectsPlace.XCoordinates == _gameSettings.ConsoleWidth - 1 || gameObjects.gameObjectsPlace.YCoordinates == 1 || gameObjects.gameObjectsPlace.YCoordinates == _gameSettings.ConsoleHight - 1)
                    {
                        _scene.missleXAlien.RemoveAt(x);
                    }

                    gameObjects.gameObjectsPlace.XCoordinates--;

                    if (_scene._tank.gameObjectsPlace.XCoordinates == gameObjects.gameObjectsPlace.XCoordinates && _scene._tank.gameObjectsPlace.YCoordinates == gameObjects.gameObjectsPlace.YCoordinates)
                    {
                        _scene.missleXAlien.RemoveAt(x);

                    Display();
                        Console.WriteLine("You PIDOR");
                        break;
                    }
                }
                
            
            

        }
        public void ShootYUpAlienMissle()
        {

            if (_scene.missleYUpAlien.Count == 0)
            {
                return;
            }

            for (int x = 0; x < _scene.missleYUpAlien.Count; x++)
            {

                GameObjects gameObjects = _scene.missleYUpAlien[x];

                if (gameObjects.gameObjectsPlace.XCoordinates == 1 || gameObjects.gameObjectsPlace.XCoordinates == _gameSettings.ConsoleWidth - 1 || gameObjects.gameObjectsPlace.YCoordinates == 1 || gameObjects.gameObjectsPlace.YCoordinates == _gameSettings.ConsoleHight - 1)
                {
                    _scene.missleYUpAlien.RemoveAt(x);
                }

                gameObjects.gameObjectsPlace.YCoordinates--;

                if (_scene._tank.gameObjectsPlace.XCoordinates == gameObjects.gameObjectsPlace.XCoordinates && _scene._tank.gameObjectsPlace.YCoordinates == gameObjects.gameObjectsPlace.YCoordinates)
                {
                    _scene.missleYUpAlien.RemoveAt(x);

                    Display();
                    Console.WriteLine("You PIDOR");
                    break;
                }
            }


        }
        public void ShootMove()
            {
            if(_scene._missle.Count == 0)
            {
                return;
            }
            for(int x = 0; x<_scene._missle.Count; x++)
            {
                
                    GameObjects gameObjects = _scene._missle[x];

                    if (gameObjects.gameObjectsPlace.XCoordinates == 1 || gameObjects.gameObjectsPlace.XCoordinates == _gameSettings.ConsoleWidth - 1 || gameObjects.gameObjectsPlace.YCoordinates == 1 || gameObjects.gameObjectsPlace.YCoordinates == _gameSettings.ConsoleHight - 1)
                    {
                        _scene._missle.RemoveAt(x);
                    }
                              
                    gameObjects.gameObjectsPlace.YCoordinates--;                
                for(int i = 0; i<_scene.tankenemy.Count; i++)
                {
                    GameObjects enemy = _scene.tankenemy[i];
                    if(enemy.gameObjectsPlace.XCoordinates==gameObjects.gameObjectsPlace.XCoordinates&& enemy.gameObjectsPlace.YCoordinates == gameObjects.gameObjectsPlace.YCoordinates)
                    {
                        _scene.tankenemy.RemoveAt(i);
                        _scene._missle.RemoveAt(x);
                        break;
                    }
                }
                if (_scene.tankalien.gameObjectsPlace.XCoordinates == gameObjects.gameObjectsPlace.XCoordinates && _scene.tankalien.gameObjectsPlace.YCoordinates == gameObjects.gameObjectsPlace.YCoordinates)
                {
                    _scene._missle.RemoveAt(x);
                    Display();
                    Console.WriteLine("You Winner");
                    break;
                }
            }
        }
        public void ShootMoveXRight()
        {
            if (_scene.missleXright.Count == 0)
            {
                return;
            }
            for (int x = 0; x < _scene.missleXright.Count; x++)
            {

                GameObjects gameObjects = _scene.missleXright[x];

                if (gameObjects.gameObjectsPlace.XCoordinates == 1 || gameObjects.gameObjectsPlace.XCoordinates == _gameSettings.ConsoleWidth - 1 || gameObjects.gameObjectsPlace.YCoordinates == 1 || gameObjects.gameObjectsPlace.YCoordinates == _gameSettings.ConsoleHight - 1)
                {
                    _scene.missleXright.RemoveAt(x);
                }
                   gameObjects.gameObjectsPlace.XCoordinates++;
                for (int i = 0; i < _scene.tankenemy.Count; i++)
                {
                    GameObjects enemy = _scene.tankenemy[i];
                    if (enemy.gameObjectsPlace.XCoordinates == gameObjects.gameObjectsPlace.XCoordinates && enemy.gameObjectsPlace.YCoordinates == gameObjects.gameObjectsPlace.YCoordinates)
                    {
                        _scene.tankenemy.RemoveAt(i);
                        _scene.missleXright.RemoveAt(x);
                        break;
                    }

                }
                if (_scene.tankalien.gameObjectsPlace.XCoordinates==gameObjects.gameObjectsPlace.XCoordinates&& _scene.tankalien.gameObjectsPlace.YCoordinates == gameObjects.gameObjectsPlace.YCoordinates)              
                {
                    _scene.missleXright.RemoveAt(x);
                    Display();
                    Console.WriteLine("You Winner");
                    break;
                }
            }
        }
        public void ShootMoveXLeft()
        {
            if (_scene.missleXLeft.Count == 0)
            {
                return;
            }
            for (int x = 0; x < _scene.missleXLeft.Count; x++)
            {

                GameObjects gameObjects = _scene.missleXLeft[x];

                if (gameObjects.gameObjectsPlace.XCoordinates == 1 || gameObjects.gameObjectsPlace.XCoordinates == _gameSettings.ConsoleWidth - 1 || gameObjects.gameObjectsPlace.YCoordinates == 1 || gameObjects.gameObjectsPlace.YCoordinates == _gameSettings.ConsoleHight - 1)
                {
                    _scene.missleXLeft.RemoveAt(x);
                }
                gameObjects.gameObjectsPlace.XCoordinates--;
                for (int i = 0; i < _scene.tankenemy.Count; i++)
                {
                    GameObjects enemy = _scene.tankenemy[i];
                    if (enemy.gameObjectsPlace.XCoordinates == gameObjects.gameObjectsPlace.XCoordinates && enemy.gameObjectsPlace.YCoordinates == gameObjects.gameObjectsPlace.YCoordinates)
                    {
                        _scene.tankenemy.RemoveAt(i);
                        _scene.missleXLeft.RemoveAt(x);
                        break;
                    }
                }
                if (_scene.tankalien.gameObjectsPlace.XCoordinates == gameObjects.gameObjectsPlace.XCoordinates && _scene.tankalien.gameObjectsPlace.YCoordinates == gameObjects.gameObjectsPlace.YCoordinates)
                {
                    _scene.missleXLeft.RemoveAt(x);
                    Display();
                    Console.WriteLine("You Winner");
                    break;
                }

            }
        }
        public void ShootMoveYDown()
        {
            if (_scene.missledown.Count == 0)
            {
                return;
            }
            for (int x = 0; x < _scene.missledown.Count; x++)
            {

                GameObjects gameObjects = _scene.missledown[x];

                if (gameObjects.gameObjectsPlace.XCoordinates == 1 || gameObjects.gameObjectsPlace.XCoordinates == _gameSettings.ConsoleWidth - 1 || gameObjects.gameObjectsPlace.YCoordinates == 1 || gameObjects.gameObjectsPlace.YCoordinates == _gameSettings.ConsoleHight - 1)
                {
                    _scene.missledown.RemoveAt(x);
                }
                gameObjects.gameObjectsPlace.YCoordinates++;
                for (int i = 0; i < _scene.tankenemy.Count; i++)
                {
                    GameObjects enemy = _scene.tankenemy[i];
                    if (enemy.gameObjectsPlace.XCoordinates == gameObjects.gameObjectsPlace.XCoordinates && enemy.gameObjectsPlace.YCoordinates == gameObjects.gameObjectsPlace.YCoordinates)
                    {
                        _scene.tankenemy.RemoveAt(i);
                        _scene.missledown.RemoveAt(x);
                        break;
                    }
                }
                if (_scene.tankalien.gameObjectsPlace.XCoordinates == gameObjects.gameObjectsPlace.XCoordinates && _scene.tankalien.gameObjectsPlace.YCoordinates == gameObjects.gameObjectsPlace.YCoordinates)
                {
                    _scene.missledown.RemoveAt(x);
                    Display();
                    Console.WriteLine("You Winner");
                    break;
                }

            }
        }
        public void Display()
        {
            _isNotOwner = false;
            Console.WriteLine("Game Over");

        }

    }

}




