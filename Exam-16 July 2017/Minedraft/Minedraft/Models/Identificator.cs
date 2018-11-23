using System;
using System.Collections.Generic;
using System.Text;

public abstract class Identificator
{
    public string Id { get; }

    protected Identificator(string id)
    {
        this.Id = id;
    }
}

