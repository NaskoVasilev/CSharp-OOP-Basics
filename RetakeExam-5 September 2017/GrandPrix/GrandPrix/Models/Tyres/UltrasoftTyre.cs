using System;
using System.Collections.Generic;
using System.Text;

public class UltrasoftTyre : Tyre
{
    private const string tyreName = "Ultrasoft";

    public UltrasoftTyre(double hardness, double grip) : base(tyreName, hardness)
    {
        this.Grip = grip;
    }

    public double Grip { get; }

    public override double Degradation
    {
        get => base.Degradation;
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException(ErrorMessages.BlownTyre);
            }
            base.Degradation = value;
        }
    }

    public override void ReduceDegradation()
    {
        this.Degradation -= this.Hardness + this.Grip;
    }
}


