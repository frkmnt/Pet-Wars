using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinates  
{

	public int X;
	public int Y;
	public GameObject Pet;

	public bool IsUsed;

	public Coordinates (int x, int y, GameObject pet)
	{
		this.X = x;
		this.Y = y;
		this.Pet = pet;
		IsUsed = true;
	}

}
