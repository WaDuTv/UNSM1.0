using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject loadingScreen;
    public ProgressBar bar;
    public TextMeshProUGUI textField;

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

        yield return new WaitForSeconds(3f);
        
        loadingScreen.gameObject.SetActive(false);
    }
}
