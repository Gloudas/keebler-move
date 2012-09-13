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
    class Player
    {

        public bool collide;
        public bool inAir;
        const float JumpSpeed = 1.0f;
        public Vector2 playerPos;
        float x, y;
        int verticalVelocity;
        //int horizontalVelocity;
        Game1 game;
        public Rectangle playerRect;

        public Player(Vector2 position, Game1 game)
        {
            this.game = game;
            playerPos = position;
            //collide = true;
            x = playerPos.X;
            y = playerPos.Y;
            inAir = false;
            verticalVelocity = 20;
            playerRect = new Rectangle((int)playerPos.X, (int)playerPos.Y, 30, 60);
        }

        public void Update(GameTime gametime, KeyboardState keyboard)
        {
            if(keyboard.IsKeyDown(Keys.Space) && inAir == false) 
            {
                inAir = true;
                verticalVelocity = -20;
            }
            playerPos.Y += verticalVelocity;
            if (verticalVelocity < 20)
            {
                verticalVelocity++;
            }
            if (playerPos.Y >= game.canvasHeight-60)
            {
                playerPos.Y = game.canvasHeight - 60;
                inAir = false;
            }
            playerRect.X = (int)playerPos.X;
            playerRect.Y = (int)playerPos.Y;
        }
    }
}
