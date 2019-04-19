using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet {

    public string Name { get; private set; } 
    public Sprite Sprite { get; private set; }
    public Stats Stats { get; private set; }
    

    public Pet(string n, Sprite s, Stats st)
    {
        Name = n;
        Sprite = s;
        Stats = st;
    }
}
