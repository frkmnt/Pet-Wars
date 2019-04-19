using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HouseTile : MonoBehaviour
{

    public Sprite SpriteWhite;
    public Sprite SpriteRed;

    public Sprite SpriteHealth;


    public int X; //positions in array
    public int Y;

    public GameObject Pet; //the pet or node
    public bool isMoveable;

    public bool hasHealNode;




    void Awake()
    {
        isMoveable = true;
        Pet = null;
        hasHealNode = false;
        SetTileWhite();
    }

    public void SetCoordinates(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void SetUnmoveable()
    {
        isMoveable = false;
    }



    //OBJECT MANAGEMENT

    public void RemoveObj()
    {
        this.Pet = null;
        isMoveable = true;
        //UPDATE SPRITE
    }

    public void SetObj(GameObject o)
    {
        this.Pet = o;
        isMoveable = true;
        //UPDATE SPRITE
    }






    //SPRITE MANAGEMENT

    public void SetTileRed()
    {
        //UPDATE SPRITE
        this.GetComponent<SpriteRenderer>().sprite = SpriteRed;
    }

    public void SetTileWhite()
    {
        //UPDATE SPRITE
        this.GetComponent<SpriteRenderer>().sprite = SpriteWhite;
    }

    public void SetTileHealthNode()
    {
        //UPDATE SPRITE
        hasHealNode = true;
        this.GetComponent<SpriteRenderer>().sprite = SpriteHealth;
        this.GetComponent<SpriteRenderer>().enabled = true;
    }








    public bool IsOccupied()
    {
        if (Pet == null)
        {
            return false;
        }
        else return true;
    }

    /**
         public bool IsSameTeam(GameObject p)
        {
            if (p.tag == Pet.tag)
            {
                return true;
            }
            else return false;
        }
     */



    public void OnClick()
    {
        if (isMoveable)
        {
            GameObject o = GameObject.Find("HouseManagerPrefab(Clone)");
            HouseManager p = o.GetComponent<HouseManager>();
            if (!IsOccupied())
            {
                if (!hasHealNode)
                {
                    p.OnClickMove(X, Y);
                }
                else
                {
                    SetTileWhite();
                    hasHealNode = false;
                    p.OnClickHealthNode(X, Y);
                }

            }
            else
            {
                p.OnClickPet(X, Y, Pet);
            }

        }
        else
        {
            Debug.Log("Unmoveable");
        }


    }

}
