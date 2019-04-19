using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSpawner : MonoBehaviour {

    private CombatTileManager tm;


    void Awake ()
    {
        GameObject tilemanager = GameObject.Find("CombatTileManagerPrefab(Clone)");
        tm = tilemanager.GetComponent<CombatTileManager>();
    }







    //initialize lists first
    public void SpawnTeam1(List<GameObject> aux)
    {
        int count = 0;
        int r;

        ////team 1
        while (count < aux.Count)
        {
            r = Random.Range(0, 8);
            if (!tm.IsOccupied(0, r))
            {
                aux[count].GetComponent<SpriteRenderer>().enabled = true;
                aux[count].transform.position = tm.GetTilePosition(0, r);
                aux[count].tag = "Team1";
                aux[count].name += "Team1";
                float f = aux[count].GetComponent<Stats>().HouseScale;
                aux[count].transform.localScale = new Vector3(f/2.7f, f/2.7f, 1);

                tm.SetPetOnTile(aux[count], 0, r);
                count++;
            }
        }

    }

    public List<GameObject> SpawnTeam2 (List<GameObject> aux)
    {
        int count = 0, r;

        ////team 2
        while (count < aux.Count)
        {
            r = Random.Range(0, 8);
            if (!tm.IsOccupied(7, r))
            {
                aux[count].GetComponent<SpriteRenderer>().enabled = true;
                aux[count].transform.position = tm.GetTilePosition(7, r);
                aux[count].tag = "Team2";
                aux[count].name += "Team2";

                float f = aux[count].GetComponent<Stats>().HouseScale;
                aux[count].transform.localScale = new Vector3(-f/2.7f, f/2.7f, 1);
                
                tm.SetPetOnTile(aux[count], 7, r);
                
                count++;
            }
        }

        return aux;
    }
		
}
