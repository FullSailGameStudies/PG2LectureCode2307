using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07CL
{
    public class FantasyWeapon
    {
        public FantasyWeapon(WeaponRarity rarity, int level, int maxDamage, int cost)
        {
            Rarity = rarity;
            Level = level;
            MaxDamage = maxDamage;
            Cost = cost;
        }

        public WeaponRarity Rarity { get; set; } = WeaponRarity.Legendary;
        public int Level { get; set; }
        public int MaxDamage { get; set; }
        public int Cost { get; set; }

        public int DoDamage()
        {
            Random randy = new Random();
            return (int)(randy.NextDouble() * MaxDamage);
        }

    }
}
