using UnityEngine;

/*
rarity reference

common = 0
rare = 1
epic = 2
legendary = 3

*/

public class Fish
{

    private string _name;
    private int _rarity;
    private float _value;
    private float _mass;

    public Fish(string n, int r, float v, float m)
    {
        _name = n;
        _rarity = r;
        _value = v;
        _mass = m;
    }

    ~Fish()
    {
        Debug.Log(_name + " of value " + _value + " destroyed");
    } 

    public string getName() { return _name; }
    public int getRarity() { return _rarity; }
    public float getValue() { return _value; }
    public float getMass() { return _mass; }
    public float getValuePerMass() { return _value / _mass; }

}
