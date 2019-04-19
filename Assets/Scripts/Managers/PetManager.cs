using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PetManager : MonoBehaviour
{

    public GameObject PetSpawnerPrefab;
    private PetSpawner PetSpawner;
    private CombatTileManager TileManager;


    private List<GameObject> team1;
    private List<GameObject> team2;


    private LinkedList<GameObject> PetList;
    private LinkedListNode<GameObject> CurPet;
    private List<CombatTile> MoveableTiles;
    private List<CombatTile> AttackableTiles;

    bool IsNormalBattle;





    void Awake()
    {
        PetList = new LinkedList<GameObject>();

        GameObject petspawner = Instantiate(PetSpawnerPrefab) as GameObject;
        PetSpawner = petspawner.GetComponent<PetSpawner>();

        GameObject tilemanager = GameObject.Find("CombatTileManagerPrefab(Clone)");
        TileManager = tilemanager.GetComponent<CombatTileManager>();


        GameObject g = GameObject.Find("Overseer");
        if (g != null)
        {
            Persister p = g.GetComponent<Overseer>().Persister;
            IsNormalBattle = p.IsNormalBattle;
        }
        else
        {
            IsNormalBattle = false;
        }




    }


    public void SetMainBattle()
    {
        IsNormalBattle = false;
    }



    public void StartUp(List<GameObject> l1, List<GameObject> l2)
    {

        PetSpawner.SpawnTeam1(l1);
        PetSpawner.SpawnTeam2(l2);

        team1 = l1;
        team2 = l2;



        OrderPetsBySpeed();

        CurPet = PetList.First;

        MoveableTiles = TileManager.MoveableTiles(CurPet.Value, CurPet.Value.GetComponent<Stats>().Speed);
        AttackableTiles = TileManager.AttackableTiles(CurPet.Value);

        SkillInterface cont = (SkillInterface)CurPet.Value.GetComponent(typeof(SkillInterface));
        cont.startTurn();

        foreach (CombatTile item in MoveableTiles)
        {
            item.SetTileBlue();
        }
        CurrentPetGreen();

    }





    public bool MovePet(int x, int y)
    {
        if (!TileManager.IsOccupied(x, y))
        {
            CombatTile t = TileManager.GetTile(x, y).GetComponent<CombatTile>();
            if (MoveableTiles.Contains(t))
            {
                CurrentPetWhite();
                SetTilesWhite();
                SetAdjacentFoesWhite();
                TileManager.MovePet(CurPet.Value, x, y);
                AttackableTiles = TileManager.AttackableTiles(CurPet.Value);
                CurrentPetGreen();
                SetAdjacentFoesRed();
                return true;
            }
        }

        return false;
    }


    public bool CombatPet(int x, int y)
    {
        CombatTile c = TileManager.GetTile(x, y).GetComponent<CombatTile>();

        if (AttackableTiles.Contains(c))
        {
            GameObject o = c.Pet;
            bool b;

            SkillInterface cont = (SkillInterface)CurPet.Value.GetComponent(typeof(SkillInterface));

            if (cont.Stats.TauntTarget == null || cont.Stats.TauntTarget == o)
            {
                b = cont.turnAttack(o);
                SkillInterface s = (SkillInterface)o.GetComponent(typeof(SkillInterface));

                if (s.Stats.IsDead)
                {
                    PetList.Remove(c.Pet);
                    //s.Stats.Delete();
                    c.RemovePet();
                    o.GetComponent<SpriteRenderer>().enabled = false;
                }

                return true;
            }

            else
            {
                PetLogger Tester = GameObject.Find("Logger").GetComponent<PetLogger>();
                Tester.Log("The pet is distracted, it can only select the Fly as a target!");
                return false;
            }
        }

        return false;
    }


    public void SkillPet()
    {
        SkillInterface cont = (SkillInterface)CurPet.Value.GetComponent(typeof(SkillInterface));

        if (cont.Type.Equals("self"))
        {
            bool b = cont.turnSkill();
            if (b) NextPet();

        }

        else if (cont.Type.Equals("enemy"))
        {
            cont.turnSkill();
        }

        else
        {
            cont.turnSkill();
        }
    }












    public void NextPet()
    {

        if (IsNormalBattle)
        {
            Overseer o = GameObject.Find("Overseer").GetComponent<Overseer>();
            if (o.Persister.IsPartyDead(team2))
            {
                o.Persister.AddCombatPetToParty();
                foreach (GameObject item in team1)
                {
                    item.GetComponent<SpriteRenderer>().enabled = false;
                }

                foreach (GameObject item in team2)
                {
                    item.GetComponent<SpriteRenderer>().enabled = false;
                }

                o.LoadHouseScene();
                return;

            }
            if (o.Persister.IsPartyDead(team1))
            {
                o.LoadEndScene();
                return;
            }

        }
        else
        {
            GameObject g = GameObject.Find("Overseer");
            if (g != null)
            {
                Persister p = g.GetComponent<Overseer>().Persister;
                if (p.IsPartyDead(team2) || p.IsPartyDead(team1))
                {
                    g.GetComponent<Overseer>().LoadEndScene();
                    return;
                }
            }
            else
            {
                g = GameObject.Find("Skirmish(Clone)");
                Persister p = g.GetComponent<Skirmish>().Persister;
                if (p.IsPartyDead(team2) || p.IsPartyDead(team1))
                {
                    Destroy(GameObject.Find("Skirmish(Clone)"));
                    Destroy(GameObject.Find("PetSelectionManager"));
                    SceneManager.LoadScene("MainMenuScene");
                }


            }


        }


        if (CurPet.Next != null)
        {
            SetTilesWhite();
            CurrentPetWhite();
            SetAdjacentFoesWhite();

            SkillInterface cont = (SkillInterface)CurPet.Value.GetComponent(typeof(SkillInterface));
            cont.endTurn();


            CurPet = CurPet.Next;

            MoveableTiles.Clear();
            MoveableTiles = TileManager.MoveableTiles(CurPet.Value, CurPet.Value.GetComponent<Stats>().Speed);
            AttackableTiles = TileManager.AttackableTiles(CurPet.Value);

            SetTilesBlue();
            CurrentPetGreen();
            SetAdjacentFoesRed();

            cont = (SkillInterface)CurPet.Value.GetComponent(typeof(SkillInterface));
            cont.startTurn();


        }
        else
        {
            SetTilesWhite();
            CurrentPetWhite();
            SetAdjacentFoesWhite();

            SkillInterface cont = (SkillInterface)CurPet.Value.GetComponent(typeof(SkillInterface));
            cont.endTurn();


            CurPet = PetList.First;

            MoveableTiles.Clear();
            MoveableTiles = TileManager.MoveableTiles(CurPet.Value, CurPet.Value.GetComponent<Stats>().Speed);
            AttackableTiles = TileManager.AttackableTiles(CurPet.Value);

            SetTilesBlue();
            CurrentPetGreen();
            SetAdjacentFoesRed();

            cont = (SkillInterface)CurPet.Value.GetComponent(typeof(SkillInterface));
            cont.startTurn();
        }



    }



    public void SetTilesWhite()
    {
        foreach (CombatTile item in MoveableTiles)
        {
            item.SetTileWhite();
        }
    }

    public void SetTilesBlue()
    {
        foreach (CombatTile item in MoveableTiles)
        {
            item.SetTileBlue();
        }
    }

    public void CurrentPetGreen()
    {
        CombatTile tt = TileManager.FindPet(CurPet.Value);
        tt.SetTileGreen();
    }

    public void CurrentPetWhite()
    {
        CombatTile tt = TileManager.FindPet(CurPet.Value);
        tt.SetTileWhite();
    }

    public void SetAdjacentFoesWhite()
    {
        foreach (CombatTile item in AttackableTiles)
        {
            item.SetTileWhite();
        }
    }

    public void SetAdjacentFoesRed()
    {
        foreach (CombatTile item in AttackableTiles)
        {
            item.SetTileRed();
        }
    }


    public bool HasAttackablePets()
    {
        if (AttackableTiles.Count > 0)
        {
            return true;
        }

        return false;
    }





    public void OrderPetsBySpeed()
    {
        GameObject[] pets = new GameObject[team1.Count + team2.Count];


        GameObject pet1, pet2, aux;

        if (team1.Count > 1)
        {
            for (int x = 0; x < team1.Count; x++)
            {
                for (int y = 0; y < team1.Count; y++)
                {
                    if (x != y)
                    {
                        pet1 = team1[x];
                        pet2 = team1[y];

                        if (pet1.GetComponent<Stats>().Speed > pet2.GetComponent<Stats>().Speed)
                        {
                            aux = team1[y];
                            team1[y] = team1[x];
                            team1[x] = aux;
                        }
                    }
                }
            }
        }

        if (team2.Count > 1)
        {
            for (int x = 0; x < team2.Count; x++)
            {
                for (int y = 0; y < team2.Count; y++)
                {
                    if (x != y)
                    {
                        pet1 = team2[x];
                        pet2 = team2[y];

                        if (pet1.GetComponent<Stats>().Speed > pet2.GetComponent<Stats>().Speed)
                        {
                            aux = team2[y];
                            team2[y] = team2[x];
                            team2[x] = aux;
                        }
                    }
                }
            }
        }







        float r = Random.value;

        if (r >= 0.5f)
        {
            for (int i = 0; i < team1.Count; i++)
            {
                pets[i] = team1[i];
            }

            for (int j = 0; j < team2.Count; j++)
            {
                pets[j + team1.Count] = team2[j];
            }
        }

        else
        {
            for (int j = 0; j < team2.Count; j++)
            {
                pets[j] = team2[j];
            }

            for (int i = 0; i < team1.Count; i++)
            {
                pets[i + team2.Count] = team1[i];
            }
        }




        for (int i = 0; i < pets.Length; i++)
        {
            PetList.AddLast(pets[i]);
        }

    }

}
