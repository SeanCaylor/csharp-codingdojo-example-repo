namespace ChairOOP
{
    public class Wheel
    {

        public string Material { get; set; }
        public string Color { get; set; }
        public bool IsLocked { get; set; }
        public bool CanSwivel { get; set; }

        public Wheel (string material, string color, bool isLocked = false, bool canSwivel = true)
        {
            Material = material;
            Color = color;
            IsLocked = isLocked;
            CanSwivel = canSwivel;
        }
    }
}