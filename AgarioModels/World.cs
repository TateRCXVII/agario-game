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
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Drawing;
using System.Numerics;

namespace AgarioModels
{
    public class World
    {
        private readonly int HEIGHT = 5000;
        private readonly int WIDTH = 5000;
        private readonly int SCREENWIDTH = 800;
        private readonly int SCREENHEIGHT = 800;
        private int X = 0;
        private int Y = 0;
        private Rectangle _rect;


        //Choose between these
        /*        public ConcurrentBag<Player> players; //keep track of players*/
        public ConcurrentBag<Food> food; //keep track of food
        //public ConcurrentDictionary<Food, Vector2> food;
        public ConcurrentDictionary<long, Player> players;

        public ConcurrentBag<long> deadPlayers;

        public ConcurrentBag<long> deadFood;

        public int playerCount;
        public int foodCount;
        private ILogger _logger;

        /// <summary>
        /// Default constructor that initializes a world rectangle and game environment
        /// </summary>
        /// <param name="logger">an ilogger</param>
        public World(ILogger logger)
        {
            //Represents the world
            _rect = new Rectangle(X, Y, SCREENWIDTH, SCREENHEIGHT);
            /*            players = new ConcurrentBag<Player>(); */
            food = new ConcurrentBag<Food>();
            players = new ConcurrentDictionary<long, Player>();
            deadPlayers = new ConcurrentBag<long>();
            deadFood = new ConcurrentBag<long>();
            //food = new ConcurrentDictionary<Food, Vector2>();
            _logger = logger;
        }

        /// <summary>
        /// Property for the World Background
        /// </summary>
        public Rectangle Rectangle
        {
            get { return _rect; }
        }

        public int Width
        {
            get { return _rect.Width; }
        }

        public int Height
        {
            get { return _rect.Height; }
        }
    }
}