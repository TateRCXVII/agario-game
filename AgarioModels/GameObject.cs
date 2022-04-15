using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AgarioModels
{
    public class GameObject
    {
        private long id;
        private Vector2 center;
        private float x;
        private float y;
        private int _ARGBColor;
        private float mass;

        public GameObject(long id, Vector2 center, float X, float Y, int ARGBColor, float mass)
        {
            this.id = id;
            this.center = center;
            this.x = X;
            this.y = Y;
            this._ARGBColor = ARGBColor;
            this.mass = mass;
        }

        public long ID
        {
            get { return id; }
            set { id = value; }
        }

        public Vector2 Center
        {
            get { return center; }
            set { center = value; }
        }

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public int ARGBColor
        {
            get { return _ARGBColor; }
            set { _ARGBColor = value; }
        }

        public float Mass
        {
            get { return mass; }
            set { mass = value; }
        }


    }
}
