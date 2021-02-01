using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using TigerForge;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private saveManager sm;
    public GameObject loadingScreen;
    public ProgressBar bar;
    public TextMeshProUGUI textField;
    EasyFileSave saveData;

    private void Awake()
    {        
        instance = this;

        SceneManager.LoadSceneAsync((int)SceneIndexes.MainMenu, LoadSceneMode.Additive);

    }

    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();

    public void LoadGame()
    {
        loadingScreen.gameObject.SetActive(true);

        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.MainMenu));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.Main, LoadSceneMode.Additive));

        StartCoroutine(GetSceneLoadProgress());    
    }

    float totalSceneProgress;
    public void LoadSavedGame()
    {
        loadingScreen.gameObject.SetActive(true);

        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.MainMenu));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.Main, LoadSceneMode.Additive));
        
        StartCoroutine(GetSceneLoadProgress());
        SceneManager.sceneLoaded += LoadData;
    }

    void LoadData(Scene scene, LoadSceneMode mode)
    {
        sm = GameObject.Find("SaveManager").GetComponent<saveManager>();
        sm.LoadData();
    }

    
    public IEnumerator GetSceneLoadProgress()
    {
        for (int i = 0; i < scenesLoading.Count ; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                totalSceneProgress = 0;
                
                foreach(AsyncOperation operation in scenesLoading)
                {
                    totalSceneProgress += operation.progress;
                }

                totalSceneProgress = (totalSceneProgress / scenesLoading.Count) * 100f;

                textField.text = string.Format("Game is Loading {0}%", totalSceneProgress);

                bar.current = Mathf.RoundToInt(totalSceneProgress);

                yield return null;


            }
        }

        yield return null;
        
        loadingScreen.gameObject.SetActive(false);
    }

}
