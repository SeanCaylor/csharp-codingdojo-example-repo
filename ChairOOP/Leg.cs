namespace ChairOOP
{
    public class Leg
    {
        private string material;
        public string Material { get; set; }
        public string Color { get; set; }
        public int Durability { get; set; } = 100;
        public Wheel Wheel { get; set; }

        public Leg(string material, string color, Wheel wheel)
        {
            Material = material;
            Color = color;
            Wheel = wheel;
        }

        public bool NeedsReplacement()
        {
            return Durability <= 10;
        }
    }
}