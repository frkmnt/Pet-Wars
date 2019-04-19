using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public void PlayCampaign()
    {
        SceneManager.LoadScene("StarterSelectionScene");      
        Debug.Log("Campaign");
    }

    public void PlayBattle()
    {
        //load the combat scene
        Debug.Log("Battle");
    }

    public void PlaySkirmish()
    {
        SceneManager.LoadScene("SkirmishScene"); 
        Debug.Log("Skirmish");
    }

    public void OpenStore()
    {
        Debug.Log("Store");
    }
}
