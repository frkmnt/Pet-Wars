using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousePet : MonoBehaviour {

	public int x, y;

	public int Team;

	public string spawnType = ""; //inside, outside, both

	private void SetCoordinates(int x, int y)
	{
		this.x = x;
		this.y = y;
	}


	private void SetTeam(int x)
	{
		if (x == 1 || x == 2) Team = x;
	}



	private void SetSpriteDog(Sprite ss)
	{
		SpriteRenderer s = GetComponent<SpriteRenderer>();
		s.sprite = ss;
	}


	private void SetSpriteCat(Sprite ss)
	{
		SpriteRenderer s = GetComponent<SpriteRenderer>();
		s.sprite = ss;	
	}
}
