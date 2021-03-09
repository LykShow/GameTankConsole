using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTank
{
    class GameSettings
    {
        public int ConsoleWidth { get; set; } = 80;
        public int ConsoleHight { get; set; } = 30;

        public int TankstartXcoordinates { get; set; } = 10;
        public int TankstartYcoordinates { get; set; } = 10;
        public char TankFigure { get; set; } = '^';

        public int TankEnemyX { get; set; } = 50;
        public int TankEnemyY { get; set; } = 10;
        public int TankEnemyNumberY { get; set; } = 3;
        public int TankEnemyNumberX { get; set; } = 3;
        public char TankEnemyFig { get; set; } = '*';
        public char Missle { get; set; } = '|';
        public char MissleX { get; set; } = '-';
        public char MissleDown { get; set; } = '|';
        public int MissleSpeed { get; set; } = 5;
        public int GameSpeed { get; set; } = 100;
        public int TankAlienX { get; set; } = 60;
        public int TankAienY { get; set; } = 10;
        public char FigureTankAlien { get; set; } = '>';
        public int SpeedAlien { get; set; } = 4;
    }
}
