﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyBattleship
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.DisplayWelcome();
            Game game = new Game();
            game.PlayGame();
        }
    }
}
