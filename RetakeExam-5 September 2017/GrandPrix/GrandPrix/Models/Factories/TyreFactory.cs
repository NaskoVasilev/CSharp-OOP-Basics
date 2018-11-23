
using System;

public class TyreFactory
{
    public Tyre CreateTyre(string type, double hardness, double grip)
    {
        switch (type)
        {
            case "Ultrasoft":
                return new UltrasoftTyre(hardness, grip);
            case "Hard":
                return new HardTyre(hardness);
            default:
                throw new ArgumentException(ErrorMessages.InvalidTyreType);
        }
    }
}

