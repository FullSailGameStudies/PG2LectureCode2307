using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08CL
{
    public class Pistol : Weapon
    {
        public int Rounds { get; set; }
        public int MagCapacity { get; set; }
        public Pistol(int range, int damage, int magCapacity, int rounds) 
            : base(range, damage)
        {
            MagCapacity = magCapacity;
            Rounds = rounds;
        }
    }
}
