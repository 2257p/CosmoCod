using UnityEngine;

/*
COMMON
cod: $5/kg
salmon: $10/kg
pike: $15/kg
bluey: $20/kg

RARE
redfin: $25/kg
sparklefin: $30/kg
starfin: $35/kg
bubblefin: $40/kg

EPIC
clownfish: $45/kg
firefish: $50/kg
anglerfish: $55/kg
beefish: $60/kg

LEGENDARY
frostking: $65/kg
goldking: $70/kg
rainbowking: $75/kg
sunking: $80/kg
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

    public string getName() { return _name; }
    public int getRarity() { return _rarity; }
    public float getValue() { return _value; }
    public float getMass() { return _mass; }
    public float getValuePerMass() { return _value / _mass; }
}
