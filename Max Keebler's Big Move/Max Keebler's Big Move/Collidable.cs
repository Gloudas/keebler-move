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
    interface Collidable
    {
        bool isCollidingLeft(Rectangle playerRect);

        void onCollisionLeft(Player player);

        bool isCollidingTop(Rectangle playerRect);

        void onCollisionTop(Player player);
    }
}
