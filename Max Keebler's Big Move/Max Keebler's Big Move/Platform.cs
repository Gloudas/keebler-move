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
    class Platform : Collidable
    {

        public const int platformWidth = 200;
        public const int platformHeight = 10;
        public Vector2 position;
        const int horizontalVelocity = -2;
        private Rectangle leftSide;
        private Rectangle topSide;

        public Platform(int startingX, int startingY)
        {
            position = new Vector2(startingX, startingY);
           
        }

        public void Update()
        {
            position.X += horizontalVelocity;
            leftSide = new Rectangle( (int)position.X, ((int)position.Y + 3), 2, (platformHeight - 2));
            topSide = new Rectangle( (int)position.X, (int)position.Y, (platformWidth-2), 2);   // possible have a dead pixel at the topleft?
        }

        public bool isCollidingLeft(Rectangle playerRect)
        {
             return leftSide.Intersects(playerRect);
        }

        public void onCollisionLeft(Player player)
        {
            player.playerPos.X = (position.X - 30);
        }

        public bool isCollidingTop(Rectangle playerRect)
        {
            return topSide.Intersects(playerRect);
        }

        public void onCollisionTop(Player player)
        {
            player.playerPos.Y = (position.Y - 60);
            player.inAir = false;
        }

        public bool outOfBounds()
        {
            return (position.X + 200 < 0);
        }

    }
}
