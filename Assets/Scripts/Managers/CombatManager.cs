using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{

    public GameObject TileManagerPrefab;
    public GameObject PetManagerPrefab;
    public GameObject ClickManagerPrefab;
    public GameObject PetSelectionPrefab;


    private CombatTileManager TileManager;
    private PetManager PetManager;
    private ClickManager ClickManager;
    private PetSelectionController PetSelectionManager;



    private bool HasMoved;



    void Awake()
    {
        HasMoved = false;


        GameObject ctm = Instantiate(TileManagerPrefab) as GameObject;
        TileManager = ctm.GetComponent<CombatTileManager>(); //check

        GameObject petmanager = Instantiate(PetManagerPrefab) as GameObject;
        PetManager = petmanager.GetComponent<PetManager>();

        GameObject po = GameObject.Find("Overseer");
        Persister o = new Persister();
        List<GameObject> oaux1 = new List<GameObject>(), oaux2 = new List<GameObject>();


        if (po != null)
        {
            o = po.GetComponent<Overseer>().Persister;
            if (o.IsNormalBattle)
            {
                if (o.IsTeam1)
                {
                    if (o.CombatPet != null)
                    {
                        oaux2.Add(o.CombatPet);
                    }

                    foreach (GameObject item in o.Party1)
                    {
                        if (!item.GetComponent<Stats>().IsDead)
                        {
                            oaux1.Add(item);
                        }
                    }
                }
                else
                {
                    if (o.CombatPet != null)
                    {
                        oaux2.Add(o.CombatPet);
                    }

                    foreach (GameObject item in o.Party2)
                    {
                        if (!item.GetComponent<Stats>().IsDead)
                        {
                            oaux1.Add(item);
                        }
                    }
                }
            }
            else
            {
                foreach (GameObject item in o.Party1)
                {
                    if (!item.GetComponent<Stats>().IsDead) oaux1.Add(item);
                }

                foreach (GameObject item in o.Party2)
                {
                    if (!item.GetComponent<Stats>().IsDead) oaux2.Add(item);
                }
            }
        }
        else
        {
            o = GameObject.Find("Skirmish(Clone)").GetComponent<Skirmish>().Persister;
            foreach (GameObject item in o.Party1)
            {
                oaux1.Add(item);
            }

            foreach (GameObject item in o.Party2)
            {
                oaux2.Add(item);
            }
        }












        foreach (GameObject item in oaux1)
        {
            SkillInterface cont = (SkillInterface)item.GetComponent(typeof(SkillInterface));
            cont.FindTester();
        }

        foreach (GameObject item in oaux2)
        {
            SkillInterface cont = (SkillInterface)item.GetComponent(typeof(SkillInterface));
            cont.FindTester();
        }

        PetManager.StartUp(oaux1, oaux2);


        GameObject clickmanager = Instantiate(ClickManagerPrefab) as GameObject;
        ClickManager = petmanager.GetComponent<ClickManager>();

        DamagePopupController.Initialize();

    }









    public bool hasAdjacentPets()
    {
        if (PetManager.HasAttackablePets())
        {
            return true;
        }

        return false;
    }



    public void OnClick(int x, int y)
    {
        if (!TileManager.IsOccupied(x, y))
        {
            if (!HasMoved) //move
            {
                bool a = PetManager.MovePet(x, y);
                if (a)
                {
                    if (hasAdjacentPets())
                    {
                        HasMoved = true;
                    }
                    else
                    {
                        NextPet();
                    }

                }
            }
        }


        else //attack
        {
            bool b = PetManager.CombatPet(x, y);
            if (b)
            {
                NextPet();
            }
        }
    }



    public void NextPet()
    {
        HasMoved = false;
        PetManager.NextPet();
    }


    public void ReloadScene()
    {
        SceneManager.LoadScene("CombatScene");
    }


    public void PetSkills()
    {
        PetManager.SkillPet();
    }





}
