using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CombatTile : MonoBehaviour {

    public Sprite SpriteWhite;
    public Sprite SpriteRed;
    public Sprite SpriteGreen;

    public Sprite SpriteBlue;

    public int X; //positions in array
    public int Y;

    public int MoveX;

    public GameObject Pet;


    void Awake()
    {
        Pet = null;
        SetTileWhite();
    }

    public void SetCoordinates (int x, int y)
    {
        X = x;
        Y = y;
    }

    public void RemovePet()
    {
        Pet = null;
    }
	

    public void SetTileRed()
    {
        this.GetComponent<SpriteRenderer>().sprite = SpriteRed;
    }

    public void SetTileWhite()
    {
        this.GetComponent<SpriteRenderer>().sprite = SpriteWhite;
    }

    public void SetTileGreen()
    {
        this.GetComponent<SpriteRenderer>().sprite = SpriteGreen;
    }

    public void SetTileBlue()
    {
        this.GetComponent<SpriteRenderer>().sprite = SpriteBlue;
    }

    public bool IsOccupied()
    {
        if (Pet == null)
        {
            return false;
        }
        else return true;
    }


    public bool IsSameTeam(GameObject p)
    {
        if (p.tag == Pet.tag)
        {
            return true;
        }
        else return false;
    }


    public void OnClick ()
    {
		GameObject o = GameObject.Find("CombatManagerPrefab");
        CombatManager p = o.GetComponent<CombatManager>();

        p.OnClick(X, Y);

    }

}
