using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PetSelectionManager : MonoBehaviour
{
    public PetSprites Sprites;

    public List<string> team1;
    public int cost1;
    public Text s1;


    public List<string> team2;
    public int cost2;
    public Text s2;



    public List<GameObject> party1;
    public List<GameObject> party2;



    void Awake()
    {
        DontDestroyOnLoad(this);
        GameObject s;
        s = Instantiate(Resources.Load("Pets/PetSprites")) as GameObject;
        Sprites = s.GetComponent<PetSprites>();
        Sprites.Main1 = "Pets/DogLargePrefab";
        Sprites.Main2 = "Pets/DogLargePrefab";
        cost1 = 0;
        cost2 = 0;

        Destroy(GameObject.Find("Overseer"));
        UpdateCostTeam1();
        UpdateCostTeam2();
    }



    public void UpdateCostTeam1()
    {
        s1.text = cost1.ToString();
    }


    public void UpdateCostTeam2()
    {
        s2.text = cost2.ToString();
    }




    public void StartCombat()
    {
        SceneManager.LoadScene("HouseScene");
    }


    public void StartSkirmish()
    {
        GameObject sk = Instantiate(Resources.Load("Menus/Skirmish") as GameObject);
        List<GameObject> a1 = sk.GetComponent<Skirmish>().Persister.Party1, a2 = sk.GetComponent<Skirmish>().Persister.Party2;
        GameObject g;
        foreach (string s in team1)
        {
            g = GameObject.Instantiate(Resources.Load(s) as GameObject);
            a1.Add(g);
            g.transform.parent = sk.transform;

        }

        foreach (string s in team2)
        {
            g = GameObject.Instantiate(Resources.Load(s) as GameObject);
            a2.Add(g);
            g.transform.parent = sk.transform;
        }

        cost1 = 0;
        cost2 = 0;

        SceneManager.LoadScene("CombatScene");
    }



    public void SelectLargeDog1()
    {
        Sprites.Main1 = "Pets/DogLargePrefab";
    }

    public void SelectLargeDog2()
    {
        Sprites.Main2 = "Pets/DogLargePrefab";
    }





    public void SelectMediumDog1()
    {
        Sprites.Main1 = "Pets/DogMediumPrefab";
    }

    public void SelectMediumDog2()
    {
        Sprites.Main2 = "Pets/DogMediumPrefab";
    }




    public void SelectSmallDog1()
    {
        Sprites.Main1 = "Pets/DogSmallPrefab";
    }

    public void SelectSmallDog2()
    {
        Sprites.Main2 = "Pets/DogSmallPrefab";
    }






    public void SelectLargeCat1()
    {
        Sprites.Main1 = "Pets/CatFatPrefab";
    }

    public void SelectLargeCat2()
    {
        Sprites.Main2 = "Pets/CatFatPrefab";
    }








    public void SelectSmallCat1()
    {
        Sprites.Main1 = "Pets/CatSmallPrefab";
    }

    public void SelectSmallCat2()
    {
        Sprites.Main2 = "Pets/CatSmallPrefab";
    }


















    //skirmish



    public void SkirmishLargeDog1()
    {
        string s = "Pets/DogLargePrefab";
        if (!team1.Contains(s))
        {
            if (team1.Count < 6)
            {
                if (cost1 < 120)
                {
                    team1.Add(s);
                    cost1 += 20;
                    UpdateCostTeam1();
                }
            }

        }
        else
        {
            team1.Remove(s);
            cost1 -= 20;
            UpdateCostTeam1();
        }
    }

    public void SkirmishLargeDog2()
    {
        string s = "Pets/DogLargePrefab";
        if (!team2.Contains(s))
        {
            if (team2.Count < 6)
            {
                if (cost2 < 120)
                {
                    team2.Add(s);
                    cost2 += 20;
                    UpdateCostTeam2();
                }

            }

        }
        else
        {
            team2.Remove(s);
            cost2 -= 20;
            UpdateCostTeam2();
        }
    }





    public void SkirmishMediumDog1()
    {
        string s = "Pets/DogMediumPrefab";
        if (!team1.Contains(s))
        {
            if (team1.Count < 6)
            {
                if (cost1 < 120)
                {
                    team1.Add(s);
                    cost1 += 20;
                    UpdateCostTeam1();
                }

            }

        }
        else
        {
            team1.Remove(s);
            cost1 -= 20;
            UpdateCostTeam1();
        }
    }

    public void SkirmishMediumDog2()
    {
        string s = "Pets/DogMediumPrefab";
        if (!team2.Contains(s))
        {
            if (team2.Count < 6)
            {
                if (cost2 < 120)
                {
                    team2.Add(s);
                    cost2 += 20;
                    UpdateCostTeam2();
                }

            }

        }
        else
        {
            team2.Remove(s);
            cost2 -= 20;
            UpdateCostTeam2();
        }
    }




    public void SkirmishSmallDog1()
    {
        string s = "Pets/DogSmallPrefab";
        if (!team1.Contains(s))
        {
            if (team1.Count < 6)
            {
                if (cost1 < 120)
                {
                    team1.Add(s);
                    cost1 += 20;
                    UpdateCostTeam1();
                }

            }

        }
        else
        {
            team1.Remove(s);
            cost1 -= 20;
            UpdateCostTeam1();
        }
    }

    public void SkirmishSmallDog2()
    {
        string s = "Pets/DogSmallPrefab";
        if (!team2.Contains(s))
        {
            if (team2.Count < 6)
            {
                if (cost2 < 120)
                {
                    team2.Add(s);
                    cost2 += 20;
                    UpdateCostTeam2();
                }

            }

        }
        else
        {
            team2.Remove(s);
            cost2 -= 20;
            UpdateCostTeam2();
        }

    }






    public void SkirmishLargeCat1()
    {
        string s = "Pets/CatFatPrefab";
        if (!team1.Contains(s))
        {
            if (team1.Count < 6)
            {
                if (cost1 < 120)
                {
                    team1.Add(s);
                    cost1 += 20;
                    UpdateCostTeam1();
                }

            }

        }
        else
        {
            team1.Remove(s);
            cost1 -= 20;
            UpdateCostTeam1();
        }
    }

    public void SkirmishLargeCat2()
    {
        string s = "Pets/CatFatPrefab";
        if (!team2.Contains(s))
        {
            if (team2.Count < 6)
            {
                if (cost2 < 120)
                {
                    team2.Add(s);
                    cost2 += 20;
                    UpdateCostTeam2();
                }

            }

        }
        else
        {
            team2.Remove(s);
            cost2 -= 20;
            UpdateCostTeam2();
        }
    }








    public void SkirmishSmallCat1()
    {
        string s = "Pets/CatSmallPrefab";
        if (!team1.Contains(s))
        {
            if (team1.Count < 6)
            {
                if (cost1 < 120)
                {
                    team1.Add(s);
                    cost1 += 20;
                    UpdateCostTeam1();
                }

            }

        }
        else
        {
            team1.Remove(s);
            cost1 -= 20;
            UpdateCostTeam1();
        }
    }

    public void SkirmishSmallCat2()
    {
        string s = "Pets/CatSmallPrefab";
        if (!team2.Contains(s))
        {
            if (team2.Count < 6)
            {
                if (cost2 < 120)
                {
                    team2.Add(s);
                    cost2 += 20;
                    UpdateCostTeam2();
                }

            }

        }
        else
        {
            team2.Remove(s);
            cost2 -= 20;
            UpdateCostTeam2();
        }
    }


    public void SkirmishAnt1()
    {
        string s = "Pets/AntPrefab";
        if (!team1.Contains(s))
        {
            if (team1.Count < 6)
            {
                if (cost1 < 120)
                {
                    team1.Add(s);
                    cost1 += 25;
                    UpdateCostTeam1();
                }

            }

        }
        else
        {
            team1.Remove(s);
            cost1 -= 25;
            UpdateCostTeam1();
        }
    }

    public void SkirmishAnt2()
    {
        string s = "Pets/AntPrefab";
        if (!team2.Contains(s))
        {
            if (team2.Count < 6)
            {
                if (cost2 < 120)
                {
                    team2.Add(s);
                    cost2 += 25;
                    UpdateCostTeam2();
                }

            }

        }
        else
        {
            team2.Remove(s);
            cost2 -= 25;
            UpdateCostTeam2();
        }
    }


    public void SkirmishBear1()
    {
        string s = "Pets/BearPrefab";
        if (!team1.Contains(s))
        {
            if (team1.Count < 6)
            {
                if (cost1 < 120)
                {
                    team1.Add(s);
                    cost1 += 60;
                    UpdateCostTeam1();
                }

            }

        }
        else
        {
            team1.Remove(s);
            cost1 -= 60;
            UpdateCostTeam1();
        }
    }

    public void SkirmishBear2()
    {
        string s = "Pets/BearPrefab";
        if (!team2.Contains(s))
        {
            if (team2.Count < 6)
            {
                if (cost2 < 120)
                {
                    team2.Add(s);
                    cost2 += 60;
                    UpdateCostTeam2();
                }

            }

        }
        else
        {
            team2.Remove(s);
            cost2 -= 60;
            UpdateCostTeam2();
        }
    }


    public void SkirmishBird1()
    {
        string s = "Pets/BirdPrefab";
        if (!team1.Contains(s))
        {
            if (team1.Count < 6)
            {
                if (cost1 < 120)
                {
                    team1.Add(s);
                    cost1 += 15;
                    UpdateCostTeam1();
                }

            }

        }
        else
        {
            team1.Remove(s);
            cost1 -= 15;
            UpdateCostTeam1();
        }
    }

    public void SkirmishBird2()
    {
        string s = "Pets/BirdPrefab";
        if (!team2.Contains(s))
        {
            if (team2.Count < 6)
            {
                if (cost2 < 120)
                {
                    team2.Add(s);
                    cost2 += 15;
                    UpdateCostTeam2();
                }

            }

        }
        else
        {
            team2.Remove(s);
            cost2 -= 15;
            UpdateCostTeam2();
        }
    }

    public void SkirmishFly1()
    {
        string s = "Pets/FlyPrefab";
        if (!team1.Contains(s))
        {
            if (team1.Count < 6)
            {
                if (cost1 < 120)
                {
                    team1.Add(s);
                    cost1 += 10;
                    UpdateCostTeam1();
                }

            }

        }
        else
        {
            team1.Remove(s);
            cost1 -= 10;
            UpdateCostTeam1();
        }
    }

    public void SkirmishFly2()
    {
        string s = "Pets/FlyPrefab";
        if (!team2.Contains(s))
        {
            if (team2.Count < 6)
            {
                if (cost2 < 120)
                {
                    team2.Add(s);
                    cost2 += 10;
                    UpdateCostTeam2();
                }

            }

        }
        else
        {
            team2.Remove(s);
            cost2 -= 10;
            UpdateCostTeam2();
        }
    }



    public void SkirmishIguana1()
    {
        string s = "Pets/IguanaPrefab";
        if (!team1.Contains(s))
        {
            if (team1.Count < 6)
            {
                if (cost1 < 120)
                {
                    team1.Add(s);
                    cost1 += 20;
                    UpdateCostTeam1();
                }

            }

        }
        else
        {
            team1.Remove(s);
            cost1 -= 20;
            UpdateCostTeam1();
        }
    }

    public void SkirmishIguana2()
    {
        string s = "Pets/IguanaPrefab";
        if (!team2.Contains(s))
        {
            if (team2.Count < 6)
            {
                if (cost2 < 120)
                {
                    team2.Add(s);
                    cost2 += 20;
                    UpdateCostTeam2();
                }

            }

        }
        else
        {
            team2.Remove(s);
            cost2 -= 20;
            UpdateCostTeam2();
        }
    }



    public void SkirmishLizard1()
    {
        string s = "Pets/LizardPrefab";
        if (!team1.Contains(s))
        {
            if (team1.Count < 6)
            {
                if (cost1 < 120)
                {
                    team1.Add(s);
                    cost1 += 20;
                    UpdateCostTeam1();
                }

            }

        }
        else
        {
            team1.Remove(s);
            cost1 -= 20;
            UpdateCostTeam1();
        }
    }

    public void SkirmishLizard2()
    {
        string s = "Pets/LizardPrefab";
        if (!team2.Contains(s))
        {
            if (team2.Count < 6)
            {
                if (cost2 < 120)
                {
                    team2.Add(s);
                    cost2 += 20;
                    UpdateCostTeam2();
                }

            }

        }
        else
        {
            team2.Remove(s);
            cost2 -= 20;
            UpdateCostTeam2();
        }
    }


    public void SkirmishPossum1()
    {
        string s = "Pets/PossumPrefab";
        if (!team1.Contains(s))
        {
            if (team1.Count < 6)
            {
                if (cost1 < 120)
                {
                    team1.Add(s);
                    cost1 += 15;
                    UpdateCostTeam1();
                }

            }

        }
        else
        {
            team1.Remove(s);
            cost1 -= 15;
            UpdateCostTeam1();
        }
    }

    public void SkirmishPossum2()
    {
        string s = "Pets/PossumPrefab";
        if (!team2.Contains(s))
        {
            if (team2.Count < 6)
            {
                if (cost2 < 120)
                {
                    team2.Add(s);
                    cost2 += 15;
                    UpdateCostTeam2();
                }

            }

        }
        else
        {
            team2.Remove(s);
            cost2 -= 15;
            UpdateCostTeam2();
        }
    }




    public void SkirmishRacoon1()
    {
        string s = "Pets/RacoonPrefab";
        if (!team1.Contains(s))
        {
            if (team1.Count < 6)
            {
                if (cost1 < 120)
                {
                    team1.Add(s);
                    cost1 += 20;
                    UpdateCostTeam1();
                }

            }

        }
        else
        {
            team1.Remove(s);
            cost1 -= 20;
            UpdateCostTeam1();
        }
    }

    public void SkirmishRacoon2()
    {
        string s = "Pets/RacoonPrefab";
        if (!team2.Contains(s))
        {
            if (team2.Count < 6)
            {
                if (cost2 < 120)
                {
                    team2.Add(s);
                    cost2 += 20;
                    UpdateCostTeam2();
                }

            }

        }
        else
        {
            team2.Remove(s);
            cost2 -= 20;
            UpdateCostTeam2();
        }
    }




    public void SkirmishRat1()
    {
        string s = "Pets/RatPrefab";
        if (!team1.Contains(s))
        {
            if (team1.Count < 6)
            {
                if (cost1 < 120)
                {
                    team1.Add(s);
                    cost1 += 20;
                    UpdateCostTeam1();
                }

            }

        }
        else
        {
            team1.Remove(s);
            cost1 -= 20;
            UpdateCostTeam1();
        }
    }

    public void SkirmishRat2()
    {
        string s = "Pets/RatPrefab";
        if (!team2.Contains(s))
        {
            if (team2.Count < 6)
            {
                if (cost2 < 120)
                {
                    team2.Add(s);
                    cost2 += 20;
                    UpdateCostTeam2();
                }

            }

        }
        else
        {
            team2.Remove(s);
            cost2 -= 20;
            UpdateCostTeam2();
        }
    }





    public void SkirmishSpider1()
    {
        string s = "Pets/SpiderPrefab";
        if (!team1.Contains(s))
        {
            if (team1.Count < 6)
            {
                if (cost1 < 120)
                {
                    team1.Add(s);
                    cost1 += 15;
                    UpdateCostTeam1();
                }

            }

        }
        else
        {
            team1.Remove(s);
            cost1 -= 15;
            UpdateCostTeam1();
        }
    }

    public void SkirmishSpider2()
    {
        string s = "Pets/SpiderPrefab";
        if (!team2.Contains(s))
        {
            if (team2.Count < 6)
            {
                if (cost2 < 120)
                {
                    team2.Add(s);
                    cost2 += 15;
                    UpdateCostTeam2();
                }

            }

        }
        else
        {
            team2.Remove(s);
            cost2 -= 15;
            UpdateCostTeam2();
        }
    }



    public void SkirmishTarantula1()
    {
        string s = "Pets/TarantulaPrefab";
        if (!team1.Contains(s))
        {
            if (team1.Count < 6)
            {
                if (cost1 < 120)
                {
                    team1.Add(s);
                    cost1 += 25;
                    UpdateCostTeam1();
                }

            }

        }
        else
        {
            team1.Remove(s);
            cost1 -= 25;
            UpdateCostTeam1();
        }
    }

    public void SkirmishTarantula2()
    {
        string s = "Pets/TarantulaPrefab";
        if (!team2.Contains(s))
        {
            if (team2.Count < 6)
            {
                if (cost2 < 120)
                {
                    team2.Add(s);
                    cost2 += 25;
                    UpdateCostTeam2();
                }

            }

        }
        else
        {
            team2.Remove(s);
            cost2 -= 25;
            UpdateCostTeam2();
        }
    }





    public void SkirmishTiger1()
    {
        string s = "Pets/TigerPrefab";
        if (!team1.Contains(s))
        {
            if (team1.Count < 6)
            {
                if (cost1 < 120)
                {
                    team1.Add(s);
                    cost1 += 60;
                    UpdateCostTeam1();
                }

            }

        }
        else
        {
            team1.Remove(s);
            cost1 -= 60;
            UpdateCostTeam1();
        }
    }

    public void SkirmishTiger2()
    {
        string s = "Pets/TigerPrefab";
        if (!team2.Contains(s))
        {
            if (team2.Count < 6)
            {
                if (cost2 < 120)
                {
                    team2.Add(s);
                    cost2 += 60;
                    UpdateCostTeam2();
                }

            }

        }
        else
        {
            team2.Remove(s);
            cost2 -= 60;
            UpdateCostTeam2();
        }
    }





    public void SkirmishTurtle1()
    {
        string s = "Pets/TurtlePrefab";
        if (!team1.Contains(s))
        {
            if (team1.Count < 6)
            {
                if (cost1 < 120)
                {
                    team1.Add(s);
                    cost1 += 15;
                    UpdateCostTeam1();
                }

            }

        }
        else
        {
            team1.Remove(s);
            cost1 -= 15;
            UpdateCostTeam1();
        }
    }

    public void SkirmishTurtle2()
    {
        string s = "Pets/TurtlePrefab";
        if (!team2.Contains(s))
        {
            if (team2.Count < 6)
            {
                if (cost2 < 120)
                {
                    team2.Add(s);
                    cost2 += 15;
                    UpdateCostTeam2();
                }

            }

        }
        else
        {
            team2.Remove(s);
            cost2 -= 15;
            UpdateCostTeam2();
        }
    }















}
