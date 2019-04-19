using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour
{



    private GameObject grid;
    private Sprite house;



    public GameObject HouseTileManagerPrefab;
    public GameObject HouseClickManager;


    private HouseTileManager tileManager;
    private HouseClickManager clickManager;




    void Awake()
    {
        grid = GameObject.Find("House/Grid");
        house = GameObject.Find("House").GetComponent<SpriteRenderer>().sprite;

        Vector2 v = new Vector2(house.rect.width, house.rect.height);
        grid.GetComponent<Grid>().CustomGrid(v);
        grid.transform.localScale = new Vector3(house.rect.width, house.rect.height, 1.0f);



    }

    public void StartUp()
    {

        GameObject tm = Instantiate(HouseTileManagerPrefab) as GameObject;
        tileManager = tm.GetComponent<HouseTileManager>();

        GameObject cm = Instantiate(HouseClickManager) as GameObject;
        clickManager = cm.GetComponent<HouseClickManager>();


        if (!GameObject.Find("Overseer").GetComponent<Overseer>().Persister.IsFirstTurn)
        {
            SubsequentTurns();
        }
        else
        {
            //spawn the pets in the rooms
            tileManager.SpawnPetsOnTiles();

            //start the first turn
            tileManager.FirstTurn();

            tileManager.SpawnHealthNodes();
        }



    }

    public void SubsequentTurns()
    {
        tileManager.SubsequentTurns();
        tileManager.FirstTurn();
    }




    public void OnClickMove(int x, int y)
    {
        tileManager.MoveToTile(x, y);
        tileManager.NextTurn();
    }

    public void OnClickPet(int x, int y, GameObject pet)
    {

        Overseer o = GameObject.Find("Overseer").GetComponent<Overseer>();
        if (o.Persister.IsTeam1)
        {
            if (o.Persister.Party2.Contains(pet))
            {
                o.LoadFinalBattle();

            }
            else
            {
                o.Persister.CombatPet = pet;
                o.LoadCombat();

            }

        }

        else
        {
            if (o.Persister.Party1.Contains(pet))
            {
                o.LoadFinalBattle();

            }
            else
            {
                o.Persister.CombatPet = pet;
                o.LoadCombat();

            }
        }



    }

    public void OnClickHealthNode(int x, int y)
    {
        Persister o = GameObject.Find("Overseer").GetComponent<Overseer>().Persister;
        o.OnTouchHealthNode();
        foreach (Coordinates item in o.HealthNodes)
        {
            if (item.X == x && item.Y == y)
            {
                item.IsUsed = false;
            }
        }

        tileManager.grid[x, y].GetComponent<SpriteRenderer>().enabled = false;

        tileManager.MoveToTile(x, y);
        tileManager.NextTurn();
    }






}
