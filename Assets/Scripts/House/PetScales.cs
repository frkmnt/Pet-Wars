using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetScales {

	private float scale;
        
	private Sprite sprite;

    public PetScales (float sc, Sprite sp)
    {
        this.scale = sc;
        this.sprite = sp;
    }

    public float ScaleValue()
    {
        return this.scale;
    }


    public Sprite SpriteValue()
    {
        return this.sprite;
    }

}
