using System;

namespace AbstractInterfaceExample
{
    public class Hero : IDamageable
    {
        public int Health { get; set; }
        public string Name { get; set; }
        public Building HomeBase { get; set; }

        public Hero(string name)
        {
            Name = name;
            Health = 100;
        }

        public Hero(string name, Building homeBase, int health = 100)
        {
            Name = name;
            Health = health;
            HomeBase = homeBase;
        }

        public void Attack(IDamageable target)
        {
            target.TakeDamage(10);
            Console.WriteLine($"{Name} attacked {target.Name} for 10 damage.");
        }

        public int TakeDamage(int amnt)
        {
            Health -= amnt;
            return Health;
        }
    }
}