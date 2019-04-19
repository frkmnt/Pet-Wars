using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTest : MonoBehaviour {

    Stats s;


	void Start () {
        //start pet
        s = new Stats(150, 20, 3, true);
        Pet pet = new Pet("test", null, s);

        //test pet
        Debug.Log("Pet Test");
        Debug.Log(pet.Stats.ToString());
        Debug.Log("\n\n");


        //Test Remove Health
        Debug.Log("Full Health");
        Debug.Log(pet.Stats.CurHealth);
        Debug.Log("-10 Health");
        pet.Stats.subHealth(10);
        Debug.Log(pet.Stats.CurHealth);
        Debug.Log("-20 Health");
        pet.Stats.subHealth(20);
        Debug.Log(pet.Stats.CurHealth);
        Debug.Log("-80 Health");
        pet.Stats.subHealth(80);
        Debug.Log(pet.Stats.CurHealth);
        Debug.Log("\n\n");

        //Test Add Health
        Debug.Log("Full Health");
        Debug.Log(pet.Stats.CurHealth);
        Debug.Log("+10 Health");
        pet.Stats.addHealth(10);
        Debug.Log(pet.Stats.CurHealth);
        Debug.Log("+20 Health");
        pet.Stats.addHealth(20);
        Debug.Log(pet.Stats.CurHealth);
        Debug.Log("+80 Health");
        pet.Stats.addHealth(80);
        Debug.Log(pet.Stats.CurHealth);
        Debug.Log("\n\n");


        //Test Special Attacks
        Debug.Log("Special Attacks");
        for (int i = 0; i < 10; i++)
        {
            Debug.Log(pet.Stats.Growl()); 
        }

        //Regrow Limb
        pet.Stats.subHealth(1000);
        Debug.Log(pet.Stats.CurHealth);
        pet.Stats.RegrowLimb();
        Debug.Log(pet.Stats.CurHealth);



    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
