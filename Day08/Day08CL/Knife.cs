using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08CL
{
    public class Knife : Weapon
    {
        public bool IsSerrated { get; set; }

        public Knife(int range, int damage, bool isSerrated) : base(range, damage)
        {
            IsSerrated = isSerrated;
        }
    }
}
