using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Numerics;

namespace AgarioModels
{
    public class World
    {
        private readonly int HEIGHT = 5000;
        private readonly int WIDTH = 5000;

        private ConcurrentBag<Player> players; //keep track of players
        private ConcurrentBag<Food> food; //keep track of food
        private ConcurrentDictionary<Food, Vector2> foodDict;
        private ConcurrentDictionary<long, string> playerDict;

        private int _playerCount;
        private ILogger _logger;

    }
}