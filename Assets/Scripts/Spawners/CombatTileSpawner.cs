using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTileSpawner : MonoBehaviour {

    public GameObject HexPrefab;





    public GameObject[,] GenerateMoveGrid (GameObject[,] grid)
    {
        GameObject[,] aux = new GameObject[11, 8];

        aux[0, 0] = null;
        aux[0, 1] = null;
        aux[0, 2] = null;
        aux[0, 3] = null;
        aux[0, 4] = null;
        aux[0, 5] = null;

        aux[1, 0] = null;
        aux[1, 1] = null;
        aux[1, 2] = null;
        aux[1, 3] = null;

        aux[2, 0] = null;
        aux[2, 1] = null;



        aux[10, 7] = null;
        aux[10, 6] = null;
        aux[10, 5] = null;
        aux[10, 4] = null;
        aux[10, 3] = null;
        aux[10, 2] = null;

        aux[9, 7] = null;
        aux[9, 6] = null;
        aux[9, 5] = null;
        aux[9, 4] = null;

        aux[8, 7] = null;
        aux[8, 6] = null;




        for (int i = 3; i < 11; i++)
        {
            GameObject o = grid[i - 3, 0];
            o.GetComponent<CombatTile>().MoveX = i;
            aux[i, 0] = o;
        }

        for (int i = 3; i < 11; i++)
        {
            GameObject o = grid[i - 3, 1];
            o.GetComponent<CombatTile>().MoveX = i;
            aux[i, 1] = o;
        }

        for (int i = 2; i < 10; i++)
        {
            GameObject o = grid[i - 2, 2];
            o.GetComponent<CombatTile>().MoveX = i;
            aux[i, 2] = o;
        }

        for (int i = 2; i < 10; i++)
        {
            GameObject o = grid[i - 2, 3];
            o.GetComponent<CombatTile>().MoveX = i;
            aux[i, 3] = o;
        }

        for (int i = 1; i < 9; i++)
        {
            GameObject o = grid[i - 1, 4];
            o.GetComponent<CombatTile>().MoveX = i;
            aux[i, 4] = o;
        }

        for (int i = 1; i < 9; i++)
        {
            GameObject o = grid[i - 1, 5];
            o.GetComponent<CombatTile>().MoveX = i;
            aux[i, 5] = o;
        }

        for (int i = 0; i < 8; i++)
        {
            GameObject o = grid[i, 6];
            o.GetComponent<CombatTile>().MoveX = i;
            aux[i, 6] = o;
        }

        for (int i = 0; i < 8; i++)
        {
            GameObject o = grid[i, 7];
            o.GetComponent<CombatTile>().MoveX = i;
            aux[i, 7] = o;
        }




        return aux;
    }



    
	public GameObject[,] GenerateMap()
    {
        GameObject[,] grid = new GameObject[8, 8];
        CombatTile tileaux;
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                grid[x,y] = Instantiate(HexPrefab, TilePosition(x,y), Quaternion.identity, this.transform);
                tileaux = grid[x, y].GetComponent<CombatTile>();
                tileaux.SetCoordinates(x, y);
            }
        }

        
        return grid;
    } 


    static readonly float WIDTH_MULTIPLIER = Mathf.Sqrt(3) / 2;
    public static Vector2 TilePosition(int X, int Y)
    {
        float radius = 1.1f; //change to match sprite radius
        float height = radius * 2;
        float width = WIDTH_MULTIPLIER * height;

        float h = height * 0.75f;
        float w = width;

        //offset to center hexes
        //width
        float wo = radius * 6;
        /*float wo = (Screen.width / 2) - ao*/
        //length 
        float lo = radius*-3.5f;

        if (Y % 2 != 0)
        {
            return new Vector2
            (
                w * (X + 0.5f) - wo,
                h * -Y - lo
            );
        }
        else
        {
            return new Vector2
            (
                w * (X) - wo,
                h * -Y - lo
            );
        }
    }

}
