using System;
using System.Collections.Generic;
using System.Text;

public abstract class Tyre
{
    private const double initialDegradation = 100;

    private double degradation;

    protected Tyre(string name, double hardness)
    {
        Name = name;
        Hardness = hardness;
        Degradation = initialDegradation;
    }

    public string Name { get; }

    public double Hardness { get;  }

    public virtual double Degradation
    {
        get => this.degradation;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(ErrorMessages.BlownTyre);
            }

            this.degradation = value;
        }
    }

    public virtual void ReduceDegradation()
    {
        this.Degradation -= this.Hardness;
    }
}

