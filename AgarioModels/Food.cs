using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AgarioModels
{

    public class Food : GameObject
    {

        public Food(long ID, Vector2 center, float x, float y, int ARGBColor, float mass) :
            base(ID, center, x, y, ARGBColor, mass)
        {

        }
    }
}
