using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkirmishCombatManager : MonoBehaviour {

    public GameObject TileManagerPrefab;
    public GameObject PetManagerPrefab;
	public GameObject ClickManagerPrefab;
    public GameObject PetSelectionPrefab;


    private CombatTileManager TileManager;
    private PetManager PetManager;
    private ClickManager ClickManager;
    private PetSelectionController PetSelectionManager;



    private bool HasMoved;



    void Awake ()
    {
        HasMoved = false;


        GameObject ctm = Instantiate(TileManagerPrefab) as GameObject;
		TileManager = ctm.GetComponent<CombatTileManager>(); //check

		GameObject petmanager = Instantiate(PetManagerPrefab) as GameObject;
		PetManager = petmanager.GetComponent<PetManager>();

        DamagePopupController.Initialize(); 



    }


	
	public void StartUp(List<GameObject> l1, List<GameObject> l2)
	{
		PetManager.StartUp (l1, l2);//change to gameobject

		GameObject clickmanager = Instantiate(ClickManagerPrefab) as GameObject;
		ClickManager = PetManager.GetComponent<ClickManager>();    
	}


    



    public void NextPet()
    {
        HasMoved = false;
        PetManager.NextPet();
    }




    public bool hasAdjacentPets ()
    {
        if (PetManager.HasAttackablePets()) 
        {
            return true;
        }

        return false;
    }



    public void OnClick (int x, int y)
    {
        if (!TileManager.IsOccupied(x,y)) 
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



    public void ReloadScene () 
    {

        SceneManager.LoadScene("CombatScene");

    }


    public void PetSkills () 
    {
        PetManager.SkillPet();
    }





}
