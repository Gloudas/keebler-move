using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Max_Keebler_s_Big_Move
{
    class Bullet
    {
        public const int bulletHeight = 5;
        public const int bulletWidth = 5;

        public const int bulletVelocity = 20;

        public Vector2 position;


        public Bullet(Player player)
        {
            position = new Vector2(player.playerPos.X+15, player.playerPos.Y);
        }

        public void Update()
        {
            position.X += bulletVelocity;
        }

    }
}
