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
/// Namespace for the AgarioModels 
/// </summary>
namespace AgarioModels
{

    /// <summary>
    /// The food class contains information for a food is 
    /// This class inherits from the GameObject
    /// </summary>
    public class Food : GameObject
    {

        /// <summary>
        /// constructor for the food object the params are self explanatory
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="center"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="ARGBColor"></param>
        /// <param name="mass"></param>
        public Food(long ID, Vector2 center, float x, float y, int ARGBColor, float mass) :
            base(ID, center, x, y, ARGBColor, mass)
        {

        }
    }
}
