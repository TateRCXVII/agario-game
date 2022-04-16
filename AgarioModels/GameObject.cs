/// <summary> 
/// Author:    Tate Reynolds/Thatcher Geary
/// Partner:   each other
/// Date:      4/16/2022 
/// Course:    CS 3500, University of Utah, School of Computing 
/// Copyright: CS 3500 and Thatcher Geary - This work may not be copied for use in Academic Coursework. 
/// 
/// We, Thatcher Geary and Tate Reynolds, certify that I wrote this code from scratch and did not copy it in part or whole from  
/// another source.  All references used in the completion of the assignment are cited in my README file. 
/// 
/// File Contents 
/// The Food object 
/// </summary>
using System.Numerics;


/// <summary>
/// name space for the Agario models
/// </summary>
namespace AgarioModels
{
    /// <summary>
    /// The GameObject class. Defines what a Game OBject must be for the agario game
    /// </summary>
    public class GameObject
    {
        private long id;
        private Vector2 center;
        private float x;
        private float y;
        private int _ARGBColor;
        private float mass;

        /// <summary>
        /// constructor for the GameObject params are self explanatory
        /// </summary>
        /// <param name="id"></param>
        /// <param name="center"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="ARGBColor"></param>
        /// <param name="mass"></param>
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
