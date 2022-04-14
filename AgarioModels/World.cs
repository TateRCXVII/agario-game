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
        private int X = 0;
        private int Y = 150;
        private Rectangle _rect;


        //Choose between these
        private ConcurrentBag<Player> players; //keep track of players
        private ConcurrentBag<Food> food; //keep track of food
        private ConcurrentDictionary<Food, Vector2> foodDict;
        private ConcurrentDictionary<long, string> playerDict;

        private int _playerCount;
        private ILogger _logger;

        /// <summary>
        /// Default constructor that initializes a world rectangle and game environment
        /// </summary>
        /// <param name="logger">an ilogger</param>
        public World(ILogger logger)
        {
            _playerCount = 0;
            //Represents the world
            _rect = new Rectangle(X, Y, WIDTH, HEIGHT);
            players = new ConcurrentBag<Player>();
            food = new ConcurrentBag<Food>();
            playerDict = new ConcurrentDictionary<long, string>();
            foodDict = new ConcurrentDictionary<Food, Vector2>();
            _logger = logger;
        }

        /// <summary>
        /// Property for the World Background
        /// </summary>
        public Rectangle Rectangle
        {
            get { return _rect; }
        }

    }
}