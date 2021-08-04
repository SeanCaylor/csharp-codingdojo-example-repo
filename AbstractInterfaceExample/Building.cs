namespace AbstractInterfaceExample
{
    // Not all buildings can be damaged.
    public abstract class Building
    {
        // abstract prop means it be implemented or overriden on the child class.
        public abstract string Name { get; set; }

        // virtual means it CAN be overriden but doesn't need to be.
        public virtual int Floors { get; set; }

        public Building()
        {
            // Shared default to all children that inherit from Building, but it can be overriden.
            Floors = 1;
        }
    }
}