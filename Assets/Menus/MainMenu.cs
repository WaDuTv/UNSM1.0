using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public SaveLoadManager saveLoadManager;

    private void Start()
    {
        //saveLoadManager.ShowLoadScreen();
    }
    public void PlayGame()
    {
        GameManager.instance.LoadGame();
        Debug.Log("Starting Game");
        /*GameObject.Find("SaveManager").GetComponent<saveManager>().SaveData();*/
    }

    public void LoadGame()
    {
        GameManager.instance.LoadSavedGame(); //Needs refinement of GameManager LoadScript if multiple Levels, for wich Level to Load (Write Scene in SaveManager to save)        
        
        Debug.Log("Loading Game");
    }
        

    public void QuitGame()
    {        
        Application.Quit();
    }
}
