using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persister
{
    //HOUSE
    public GameObject[,] grid;
    public List<GameObject> HousePets;
    public List<GameObject> Party1, Party2;
    public GameObject CombatPet;
    public GameObject MainPet1, MainPet2;

    public bool IsFirstTurn;
    public bool IsTeam1;
    public bool IsNormalBattle;
    public List<Coordinates> Coordinates;
    public List<Coordinates> HealthNodes;











    public Persister()
    {
        grid = new GameObject[34, 34];
        HousePets = new List<GameObject>();
        Party1 = new List<GameObject>();
        Party2 = new List<GameObject>();
        Coordinates = new List<Coordinates>();
        HealthNodes = new List<Coordinates>();
        IsFirstTurn = true;
        IsTeam1 = true;
        IsNormalBattle = true;
    }


    public void TransitionToCombatTeam1()
    {
        if (IsTeam1)
        {
            foreach (GameObject item in HousePets)
            {
                item.GetComponent<SpriteRenderer>().enabled = false;
            }

            foreach (GameObject item in Party2)
            {
                item.GetComponent<SpriteRenderer>().enabled = false;
            }

            foreach (GameObject item in Party1)
            {
                if (!item.GetComponent<Stats>().IsDead)
                {
                    item.GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    item.GetComponent<SpriteRenderer>().enabled = false;
                }


            }

            if (CombatPet) CombatPet.GetComponent<SpriteRenderer>().enabled = true;
        }

        else
        {
            foreach (GameObject item in HousePets)
            {
                item.GetComponent<SpriteRenderer>().enabled = false;
            }

            foreach (GameObject item in Party1)
            {
                item.GetComponent<SpriteRenderer>().enabled = false;
            }

            foreach (GameObject item in Party2)
            {
                if (!item.GetComponent<Stats>().IsDead)
                {
                    item.GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    item.GetComponent<SpriteRenderer>().enabled = false;
                }
            }

            if (CombatPet) CombatPet.GetComponent<SpriteRenderer>().enabled = true;
        }

        IsFirstTurn = false;
    }


    public void TransitionToFinalCombat()
    {
        foreach (GameObject item in HousePets)
        {
            item.GetComponent<SpriteRenderer>().enabled = false;
        }

        foreach (GameObject item in Party2)
        {
            if (!item.GetComponent<Stats>().IsDead)
            {
                item.GetComponent<SpriteRenderer>().enabled = true;
            }
        }

        foreach (GameObject item in Party1)
        {
            if (!item.GetComponent<Stats>().IsDead)
            {
                item.GetComponent<SpriteRenderer>().enabled = true;
            }
        }

        if (CombatPet) CombatPet.GetComponent<SpriteRenderer>().enabled = false;


    }


    public void TransitionToHouse()
    {


        foreach (GameObject item in Party1)
        {
            item.GetComponent<Stats>().fillHealth();
            if (item.GetComponent<Stats>().IsMainPet) item.GetComponent<SpriteRenderer>().enabled = true;
            else
            {
                item.GetComponent<SpriteRenderer>().enabled = false;
            }
        }

        foreach (GameObject item in Party2)
        {
            item.GetComponent<Stats>().fillHealth();
            if (item.GetComponent<Stats>().IsMainPet) item.GetComponent<SpriteRenderer>().enabled = true;
            else
            {
                item.GetComponent<SpriteRenderer>().enabled = false;
            }
        }

        foreach (GameObject item in HousePets)
        {
            item.GetComponent<SpriteRenderer>().enabled = true;
        }



    }


    public void TransitionToEnd()
    {
        grid = new GameObject[34, 34];
        HousePets = new List<GameObject>();
        Party1 = new List<GameObject>();
        Party2 = new List<GameObject>();
        Coordinates = new List<Coordinates>();
        HealthNodes = new List<Coordinates>();
        IsFirstTurn = true;
        IsTeam1 = true;
        IsNormalBattle = true;
    }


    public void AddCombatPetToParty()
    {
        CombatPet.GetComponent<SpriteRenderer>().enabled = false;
        CombatPet.GetComponent<Stats>().Clearbuffs();

        if (IsTeam1)
        {
            Party1.Add(CombatPet);
        }
        else
        {
            Party2.Add(CombatPet);
        }

        foreach (Coordinates item in Coordinates)
        {
            if (item.Pet == CombatPet)
            {
                item.IsUsed = false;
            }
        }
        CombatPet = null;
    }




    public bool IsPartyDead(List<GameObject> team)
    {
        foreach (GameObject item in team)
        {
            if (!item.GetComponent<Stats>().IsDead)
            {
                return false;
            }
        }

        return true;
    }


    public GameObject MainPet(List<GameObject> team)
    {
        foreach (GameObject item in team)
        {
            if (item.GetComponent<Stats>().IsMainPet) return item;
        }

        return null;
    }



    public void OnTouchHealthNode()
    {
        if (IsTeam1)
        {
            foreach (GameObject item in Party1)
            {
                item.GetComponent<Stats>().BuffHero();
            }
        }
        else
        {
            foreach (GameObject item in Party2)
            {
                item.GetComponent<Stats>().BuffHero();
            }
        }
    }



    //playerList.Sort((p1,p2)=>p1.score.CompareTo(p2.score));





















}
