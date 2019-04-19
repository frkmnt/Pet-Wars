using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Overseer : MonoBehaviour
{


    public GameObject HouseManagerPrefab;

    public Persister Persister;




    void Awake()
    {
        DontDestroyOnLoad(this);
        //create the persister
        Persister = new Persister();

        GameObject g = GameObject.Find("Overseer");
        if (g)
        {
            Debug.Log("wow");
            if (g.GetComponent<Overseer>() != this)
            {
                Debug.Log("wow2");
                Destroy(this.gameObject);
            }

        }

        GameObject sk = GameObject.Find("Skirmish(Clone)");
        if (sk == null)
        {
            GameObject hmp = Instantiate(HouseManagerPrefab) as GameObject;
            hmp.GetComponent<HouseManager>().StartUp();
        }
        else
        {
            Persister.Party1 = sk.GetComponent<Skirmish>().Persister.Party1;
            Persister.Party2 = sk.GetComponent<Skirmish>().Persister.Party2;
            Persister.IsNormalBattle = false;
            SceneManager.LoadScene("CombatScene");
        }

        //spawn the HouseManager


        //generate pets
        //hmp.GetComponent<HouseManager>().StartUp();
    }







    public void LoadCombat()
    {
        //if is team 1 active
        Persister.IsFirstTurn = false;
        SceneManager.LoadScene("CombatScene");
        Persister.TransitionToCombatTeam1();
    }

    public void LoadFinalBattle()
    {
        Persister.IsNormalBattle = false;
        SceneManager.LoadScene("CombatScene");
        Persister.TransitionToFinalCombat();

    }


    public void LoadHouseScene()
    {
        SceneManager.LoadScene("HouseScene");
        Persister.TransitionToHouse();
    }

    public void LoadEndScene()
    {

        foreach (GameObject item in Persister.HousePets)
        {
            Destroy(item);
        }

        foreach (GameObject item in Persister.Party2)
        {
            Destroy(item);
        }

        foreach (GameObject item in Persister.Party1)
        {
            Destroy(item);
        }
        Persister.TransitionToEnd();

        Destroy(GameObject.Find("PetSelectionManager"));

        SceneManager.LoadScene("MainMenuScene");

        

    }






}