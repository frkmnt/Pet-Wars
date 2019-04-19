using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetLogger : MonoBehaviour {

	private int Rows;
	private readonly int MaxRows = 5;

	private int curChars = 45;

	private Text Helper;

	void Awake () 
	{
		Helper = this.gameObject.GetComponent<Text>();
	}


	public void Log(string s)
	{
		if (Rows > MaxRows) 
		{
			Helper.text = "";
			Rows = 0;
		}
		Helper.text += s + "\n";
		Rows++;
		
	}
	
	
}
