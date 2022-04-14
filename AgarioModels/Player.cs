using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgarioModels
{
    public class Player : GameObject
    {
        private string _name;
        private bool _isConnected;
        private bool _isAlive;

        public Player(string name)
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
