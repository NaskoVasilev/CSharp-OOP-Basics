using System;
using System.Collections.Generic;
using System.Text;

public class HardTyre : Tyre
{
    private const string tyreName = "Hard";

    public HardTyre(double hardness) : base(tyreName, hardness)
    {
    }
}

