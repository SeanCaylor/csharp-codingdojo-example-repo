namespace AbstractInterfaceExample
{
    public interface IDamageable
    {

        // Any classes that implement this interface MUST have health
        int Health { get; set; } // props are required, fields not allowed in interfaces.

        // Must have take damage FUNCTIONality
        // Method signature only, up to the child classes to define how it works
        int TakeDamage(int amnt);

        string Name { get; set; }

    }
}