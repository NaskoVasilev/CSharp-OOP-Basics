using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private string birthday;
    private HashSet<Person> parents;
    private HashSet<Person> children;

    public Person(string name, string birthday)
    {
        this.Name = name;
        this.Birthday = birthday;
        this.Children = new HashSet<Person>();
        this.Parents = new HashSet<Person>();
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Birthday
    {
        get { return birthday; }
        set { birthday = value; }
    }

    public HashSet<Person> Parents
    {
        get { return parents; }
        set { parents = value; }
    }

    public HashSet<Person> Children
    {
        get { return children; }
        set { children = value; }
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Birthday}";
    }
}
