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
        public override void ShowMe()
        {
            Console.WriteLine("This is a knife! ");
            base.ShowMe();
            Console.WriteLine($"\tIs Serrated? {IsSerrated}");
        }
    }
}
