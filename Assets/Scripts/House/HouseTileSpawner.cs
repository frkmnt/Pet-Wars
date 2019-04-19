using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseTileSpawner : MonoBehaviour
{

    public GameObject HouseTilePrefab;
    private Sprite House;


    void Awake()
    {
        House = GameObject.Find("House").GetComponent<SpriteRenderer>().sprite;
    }



    /*Generate the tile map */
    public void GenerateMap(GameObject[,] grid)
    {
        //find the position of the first tile
        float hw = House.bounds.size.x, hh = House.bounds.size.y; //house width and house height


        //calculate the size of a square tile in a 34x34 grid, dont forget to divide by 2 again because of the position of the center of the square tile
        float tw = House.bounds.size.x / 34, th = House.bounds.size.y / 34;


        //first square position
        Vector2 v = new Vector2
        (
            -(hw / 2) + (tw / 2),
            (hh / 2) - (th / 2)
        );

        Sprite t = HouseTilePrefab.GetComponent<SpriteRenderer>().sprite;

        float w = t.bounds.size.x;
        w = tw / w;


        HouseTilePrefab.transform.localScale = new Vector2(w, w);






        HouseTile tileaux;

        for (int x = 0; x < 34; x++)
        {
            for (int y = 0; y < 34; y++)
            {

                grid[x, y] = Instantiate(HouseTilePrefab, TilePosition(x, y, v, th, tw), Quaternion.identity, this.transform);
                tileaux = grid[x, y].GetComponent<HouseTile>();
                tileaux.SetCoordinates(x, y);

            }
        }

    }






    public Vector3 TilePosition(int X, int Y, Vector2 v, float vo, float ho)
    {
        return new Vector3
        (
            v.x + ((X * vo)),
            (v.y - ((Y * ho))),
            -0.5f
        );
    }

}
