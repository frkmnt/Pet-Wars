using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skirmish : MonoBehaviour {


	public Persister Persister;

	void Awake () 
	{
		DontDestroyOnLoad(this.gameObject);
		Persister = new Persister();
	}
	
}
