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
/// the player class
/// </summary>

using System.Numerics;

/// <summary>
/// name space for agario models
/// </summary>
namespace AgarioModels
{
    /// <summary>
    /// class that defines what a player is it inherits from the GameObject
    /// </summary>
    public class Player : GameObject
    {
        private string _name;
        private bool _isConnected;
        private bool _isAlive;

        /// <summary>
        /// constructor for the player params are self explanatory
        /// </summary>
        /// <param name="id"></param>
        /// <param name="center"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="ARGBColor"></param>
        /// <param name="mass"></param>
        /// <param name="name"></param>
        public Player(long id, Vector2 center, float x, float y, int ARGBColor, float mass, string name) :
            base(id, center, x, y, ARGBColor, mass)
        {
            this._name = name;
            _isAlive = true;
            _isConnected = false;
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public bool IsAlive
        {
            get { return _isAlive; }
            set { _isAlive = value; }
        }

        public bool IsConnected
        {
            get { return _isConnected; }
            set { _isConnected = value; }
        }
    }
}
