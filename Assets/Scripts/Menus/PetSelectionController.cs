using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSelectionController : MonoBehaviour {

    private List<string> team1;
	private int count1;

    private List<string> team2;
	private int count2;



    void Awake () 
	{
		team1 = new List<string> ();
		team2 = new List<string> ();
		count1 = 0;
		count2 = 0;
	}
	
   
    

    public void CheckAnt1 ()
    {
		if (!team1.Contains ("AntPrefab")) 
		{
			if (count1 <= 6) 
			{
				team1.Add ("AntPrefab");
				count1++;		
			}
		} 

		else 
		{
			team1.Remove ("AntPrefab");	
			count1--;
		}
	
    }

    public void CheckAnt2()
    {
		if (!team2.Contains ("AntPrefab")) 
		{
			if (count2 <= 6) 
			{
				team2.Add ("AntPrefab");
				count2++;		
			}
		} 

		else 
		{
			team2.Remove ("AntPrefab");	
			count2--;
		}
    }

    public void CheckBear1()
    {
		if (!team1.Contains ("BearPrefab")) 
		{
			if (count1 <= 6) 
			{
				team1.Add ("BearPrefab");
				count1++;
			}
		} 

		else 
		{
			team1.Remove ("BearPrefab");	
			count1--;
		}
    }

    public void CheckBear2()
    {
		if (!team2.Contains ("BearPrefab")) 
		{
			if (count2 <= 6) 
			{
				team2.Add ("BearPrefab");
				count2++;		
			}
		} 

		else 
		{
			team2.Remove ("BearPrefab");	
			count2--;
		}
    }

    public void CheckBird1()
    {
		if (!team1.Contains ("BirdPrefab")) 
		{
			if (count1 <= 6) 
			{
				team1.Add ("BirdPrefab");
				count1++;
			}
		} 

		else 
		{
			team1.Remove ("BirdPrefab");	
			count1--;
			Debug.Log (count1);
		}
    }

    public void CheckBird2()
    {
		if (!team2.Contains ("BirdPrefab")) 
		{
			if (count2 <= 6) 
			{
				team2.Add ("BirdPrefab");
				count2++;		
			}
		} 

		else 
		{
			team2.Remove ("BirdPrefab");	
			count2--;
		}
    }

    public void CheckCatFat1()
    {
		if (!team1.Contains ("CatFatPrefab")) 
		{
			if (count1 <= 6) 
			{
				team1.Add ("CatFatPrefab");
				count1++;
			}
		} 

		else 
		{
			team1.Remove ("CatFatPrefab");	
			count1--;
		}
    }

    public void CheckCatFat2()
    {
		if (!team2.Contains ("CatFatPrefab")) 
		{
			if (count2 <= 6) 
			{
				team2.Add ("CatFatPrefab");
				count2++;		
			}
		} 

		else 
		{
			team2.Remove ("CatFatPrefab");	
			count2--;
		}
    }

    public void CheckCatSmall1()
    {
		if (!team1.Contains ("CatSmallPrefab")) 
		{
			if (count1 <= 6) 
			{
				team1.Add ("CatSmallPrefab");
				count1++;
			}
		} 

		else 
		{
			team1.Remove ("CatSmallPrefab");	
			count1--;
		}
    }

    public void CheckCatSmall2()
    {
		if (!team2.Contains ("CatSmallPrefab")) 
		{
			if (count2 <= 6) 
			{
				team2.Add ("CatSmallPrefab");
				count2++;		
			}
		} 

		else 
		{
			team2.Remove ("CatSmallPrefab");	
			count2--;
		}
    }

    public void CheckDogLarge1()
    {
		if (!team1.Contains ("DogLargePrefab")) 
		{
			if (count1 <= 6) 
			{
				team1.Add ("DogLargePrefab");
				count1++;
			}
		} 

		else 
		{
			team1.Remove ("DogLargePrefab");	
			count1--;
		}
    }

    public void CheckDogLarge2()
    {
		if (!team2.Contains ("DogLargePrefab")) 
		{
			if (count2 <= 6) 
			{
				team2.Add ("DogLargePrefab");
				count2++;		
			}
		} 

		else 
		{
			team2.Remove ("DogLargePrefab");	
			count2--;
		}
    }

    public void CheckDogMedium1()
    {
		if (!team1.Contains ("DogMediumPrefab")) 
		{
			if (count1 <= 6) 
			{
				team1.Add ("DogMediumPrefab");
				count1++;
			}
		} 

		else 
		{
			team1.Remove ("DogMediumPrefab");	
			count1--;
		}
    }

    public void CheckDogMedium2()
    {
		if (!team2.Contains ("DogMediumPrefab")) 
		{
			if (count2 <= 6) 
			{
				team2.Add ("DogMediumPrefab");
				count2++;		
			}
		} 

		else 
		{
			team2.Remove ("DogMediumPrefab");	
			count2--;
		}
    }

    public void CheckDogSmall1()
    {
		if (!team1.Contains ("DogSmallPrefab")) 
		{
			if (count1 <= 6) 
			{
				team1.Add ("DogSmallPrefab");
				count1++;
			}
		} 

		else 
		{
			team1.Remove ("DogSmallPrefab");	
			count1--;
		}
    }

    public void CheckDogSmall2()
    {
		if (!team2.Contains ("DogSmallPrefab")) 
		{
			if (count2 <= 6) 
			{
				team2.Add ("DogSmallPrefab");
				count2++;		
			}
		} 

		else 
		{
			team2.Remove ("DogSmallPrefab");	
			count2--;
		}
    }


    public void CheckFly1()
    {
		if (!team1.Contains ("FlyPrefab")) 
		{
			if (count1 <= 6) 
			{
				team1.Add ("FlyPrefab");
				count1++;
			}
		} 

		else 
		{
			team1.Remove ("FlyPrefab");	
			count1--;
		}
    }

    public void CheckFly2()
    {
		if (!team2.Contains ("FlyPrefab")) 
		{
			if (count2 <= 6) 
			{
				team2.Add ("FlyPrefab");
				count2++;		
			}
		} 

		else 
		{
			team2.Remove ("FlyPrefab");	
			count2--;
		}
    }

    public void CheckIguana1()
    {
		if (!team1.Contains ("IguanaPrefab")) 
		{
			if (count1 <= 6) 
			{
				team1.Add ("IguanaPrefab");
				count1++;
			}
		} 

		else 
		{
			team1.Remove ("IguanaPrefab");	
			count1--;
		}
    }

    public void CheckIguana2()
    {
		if (!team2.Contains ("IguanaPrefab")) 
		{
			if (count2 <= 6) 
			{
				team2.Add ("IguanaPrefab");
				count2++;		
			}
		} 

		else 
		{
			team2.Remove ("IguanaPrefab");	
			count2--;
		}
    }

    public void CheckLizard1()
    {
		if (!team1.Contains ("LizardPrefab")) 
		{
			if (count1 <= 6) 
			{
				team1.Add ("LizardPrefab");
				count1++;
			}
		} 

		else 
		{
			team1.Remove ("LizardPrefab");	
			count1--;
		}
    }

    public void CheckLizard2()
    {
		if (!team2.Contains ("LizardPrefab")) 
		{
			if (count2 <= 6) 
			{
				team2.Add ("LizardPrefab");
				count2++;		
			}
		} 

		else 
		{
			team2.Remove ("LizardPrefab");	
			count2--;
		}
    }

    public void CheckPossum1()
    {
		if (!team1.Contains ("PossumPrefab")) 
		{
			if (count1 <= 6) 
			{
				team1.Add ("PossumPrefab");
				count1++;
			}
		} 

		else 
		{
			team1.Remove ("PossumPrefab");	
			count1--;
		}
    }

    public void CheckPossum2()
    {
		if (!team2.Contains ("PossumPrefab")) 
		{
			if (count2 <= 6) 
			{
				team2.Add ("PossumPrefab");
				count2++;		
			}
		} 

		else 
		{
			team2.Remove ("PossumPrefab");	
			count2--;
		}
    }

    public void CheckRacoon1()
    {
		if (!team1.Contains ("RacoonPrefab")) 
		{
			if (count1 <= 6) 
			{
				team1.Add ("RacoonPrefab");
				count1++;
			}
		} 

		else 
		{
			team1.Remove ("RacoonPrefab");	
			count1--;
		}
    }

    public void CheckRacoon2()
    {
		if (!team2.Contains ("RacoonPrefab")) 
		{
			if (count2 <= 6) 
			{
				team2.Add ("RacoonPrefab");
				count2++;		
			}
		} 

		else 
		{
			team2.Remove ("RacoonPrefab");	
			count2--;
		}
    }

    public void CheckRat1()
    {
		if (!team1.Contains ("RatPrefab")) 
		{
			if (count1 <= 6) 
			{
				team1.Add ("RatPrefab");
				count1++;
			}
		} 

		else 
		{
			team1.Remove ("RatPrefab");	
			count1--;
		}
    }

    public void CheckRat2()
    {
		if (!team2.Contains ("RatPrefab")) 
		{
			if (count2 <= 6) 
			{
				team2.Add ("RatPrefab");
				count2++;		
			}
		} 

		else 
		{
			team2.Remove ("RatPrefab");	
			count2--;
		}
    }

    public void CheckSpider1()
    {
        if (!team1.Contains("SpiderPrefab"))
        {
            if (count1 <= 6)
            {
                team1.Add("SpiderPrefab");
                count1++;
            }
        }

        else
        {
            team1.Remove("SpiderPrefab");
            count1--;
        }
    }

    public void CheckSpider2()
    {
        if (!team2.Contains("SpiderPrefab"))
        {
            if (count2 <= 6)
            {
                team2.Add("SpiderPrefab");
                count2++;
            }
        }

        else
        {
            team2.Remove("SpiderPrefab");
            count2--;
        }
    }

    public void CheckTarantula1()
    {
		if (!team1.Contains ("TarantulaPrefab")) 
		{
			if (count1 <= 6) 
			{
				team1.Add ("TarantulaPrefab");
				count1++;
			}
		} 

		else 
		{
			team1.Remove ("TarantulaPrefab");	
			count1--;
		}
    }

    public void CheckTarantula2()
    {
		if (!team2.Contains ("TarantulaPrefab")) 
		{
			if (count2 <= 6) 
			{
				team2.Add ("TarantulaPrefab");
				count2++;		
			}
		} 

		else 
		{
			team2.Remove ("TarantulaPrefab");	
			count2--;
		}
    }

    public void CheckTiger1()
    {
		if (!team1.Contains ("TigerPrefab")) 
		{
			if (count1 <= 6) 
			{
				team1.Add ("TigerPrefab");
				count1++;
			}
		} 

		else 
		{
			team1.Remove ("TigerPrefab");	
			count1--;
		}
    }

    public void CheckTiger2()
    {
		if (!team2.Contains ("TigerPrefab")) 
		{
			if (count2 <= 6) 
			{
				team2.Add ("TigerPrefab");
				count2++;		
			}
		} 

		else 
		{
			team2.Remove ("TigerPrefab");	
			count2--;
		}
    }

    public void CheckTurtle1()
    {
		if (!team1.Contains ("TurtlePrefab")) 
		{
			if (count1 <= 6) 
			{
				team1.Add ("TurtlePrefab");
				count1++;
			}
		} 

		else 
		{
			team1.Remove ("TurtlePrefab");	
			count1--;
		}
    }

    public void CheckTurtle2()
    {
		if (!team2.Contains ("TurtlePrefab")) 
		{
			if (count2 <= 6) 
			{
				team2.Add ("TurtlePrefab");
				count2++;		
			}
		} 

		else 
		{
			team2.Remove ("TurtlePrefab");	
			count2--;
		}
    }






    public bool IsTeam1Full ()
    {
        if (team1.Count <= 6) return false;

        return true;
    }


    public bool IsTeam2Full()
    {
        if (team2.Count <= 6) return false;

        return true;
    }



	public List<string> getTeam1 ()
	{
		return team1;
	}


	public List<string> getTeam2 ()
	{
		return team2;
	}




}
