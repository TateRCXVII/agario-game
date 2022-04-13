using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AgarioModels
{
    public class GameObject //TODO: Make this an interface?
    {
        private long id;
        private Vector2 center;
        private float x;
        private float y;
        private int ARGBColor;
        private float mass;
    }
}
