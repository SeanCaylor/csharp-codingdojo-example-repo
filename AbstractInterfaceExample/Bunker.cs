namespace AbstractInterfaceExample
{
    public class Bunker : Building, IDamageable
    {
        public int Health { get; set; }
        public override string Name { get; set; }
        public bool IsShielded = true;

        public Bunker(string name)
        {
            Name = name;
            Health = 300;
        }

        public int TakeDamage(int amnt)
        {

            if (IsShielded)
            {
                IsShielded = false;
            }
            else
            {
                Health -= amnt;
            }
            return Health;
        }
    }
}