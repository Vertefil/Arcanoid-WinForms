using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsGame
{
    class Physics
    {
        public bool IsCollide(Player player, MapController map, Label scoreLabel)
        {
            bool isColliding = false;
            if (player.ballX + player.vecX > MapController.mapWidth - 1 || player.ballX + player.vecX < 0)
            {
                player.vecX *= -1;
                isColliding = true;
            }
            if (player.ballY + player.vecY < 0)
            {
                player.vecY *= -1;
                isColliding = true;
            }

            //Collising
            if (map.map[player.ballY + player.vecY, player.ballX] != 0)
            {
                bool addScore = false;

                isColliding = true;
                if (map.map[player.ballY + player.vecY, player.ballX] > 10 && map.map[player.ballY + player.vecY, player.ballX] < 99)
                {
                    map.map[player.ballY + player.vecY, player.ballX] = 0;
                    map.map[player.ballY + player.vecY, player.ballX - 1] = 0;
                    addScore = true;
                }
                else if (map.map[player.ballY + player.vecY, player.ballX] < 9)
                {
                    map.map[player.ballY + player.vecY, player.ballX] = 0;
                    map.map[player.ballY + player.vecY, player.ballX + 1] = 0;
                    addScore = true;
                }
                if (addScore)
                {
                    player.score += 50;
                    if (player.score % 300 == 0 && player.score > 0)
                    {
                        map.AddLineBricks();
                    }
                }
                player.vecY *= -1;
            }
            if (map.map[player.ballY, player.ballX + player.vecX] != 0)
            {
                bool addScore = false;
                isColliding = true;
                if (map.map[player.ballY, player.ballX + player.vecX] > 10 && map.map[player.ballY, player.ballX + player.vecX] < 99)
                {
                    map.map[player.ballY, player.ballX + player.vecX] = 0;
                    map.map[player.ballY, player.ballX + player.vecX - 1] = 0;
                    addScore = true;
                }
                else if (map.map[player.ballY, player.ballX + player.vecX] < 9)
                {
                    map.map[player.ballY, player.ballX + player.vecX] = 0;
                    map.map[player.ballY, player.ballX + player.vecX + 1] = 0;
                    addScore = true;
                }
                if (addScore)
                {
                    player.score += 50;
                    if (player.score % 300 == 0 && player.score > 0)
                    {
                        map.AddLineBricks();
                    }
                }
                player.vecX *= -1;
            }

            scoreLabel.Text = "Score: " + player.score;

            return isColliding;
        }

    }
}
