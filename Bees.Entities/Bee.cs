using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bees.Entities
{
    public class Bee
    {
        private readonly int _death;
        private double _health;

        public BeeEnum BeeType { get; }

        public double Health
        {
            get
            {
                return _health;
            }
        }

        public string Status
        {
            get
            {
                if (IsAlive())
                    return "Alive";
                else
                    return "Dead";
            }
        }

        public Bee(BeeEnum beeType)
        {
            _health = 100;
            BeeType = beeType;

            switch (BeeType)
            {
                case BeeEnum.Worker:
                    _death = 70;
                    break;

                case BeeEnum.Drone:
                    _death = 50;
                    break;

                case BeeEnum.Queen:
                    _death = 20;
                    break;
            }
        }

        public void Damage(int value)
        {
            if (value > 100 || value < 0)
                throw new ArgumentException("Value needs to be between 0 and 100");

            if (IsAlive())
                _health -= (_health / 100) * value;
        }

        private bool IsAlive()
        {
            if (_health < _death)
                return false;
            else
                return true;
        }
    }
}