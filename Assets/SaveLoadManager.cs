using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveLoadManager : MonoBehaviour
{
    public TMP_InputField saveName;
    public saveManager sm;
    public GameObject loadArea;
    public GameObject loadButtonPrefab;
    public List<FileInfo> saveFiles;
    
    private void Start()
    {
        sm = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<saveManager>();
    }
    
    public void OnSave()
    {
        sm = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<saveManager>();
        sm.SaveData();        
        Debug.Log("Saved Game. Filename: " + sm.saveData.GetFileName());
    }


    public void GetFiles()
    {
        saveFiles = new List<FileInfo>();
        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
        FileInfo[] info = dir.GetFiles("*.dat");

        foreach (FileInfo f in info)
        {
            saveFiles.Add(f);
        }


    }

    public void ShowLoadScreen()
    {   
        foreach (Transform loadButtonPrefab in loadArea.transform)
        {
            GameObject.Destroy(loadButtonPrefab.gameObject);
        }
        saveFiles = new List<FileInfo>();
        Transform btnTemplate = loadButtonPrefab.transform;        
        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
        FileInfo[] info = dir.GetFiles("*.dat");

        foreach (FileInfo f in info)
        {
            saveFiles.Add(f);
            Debug.Log(f);
        }

        int index = 0;

            foreach (FileInfo f in saveFiles)
            {
                Transform btnTransform = Instantiate(btnTemplate, transform);
                btnTransform.gameObject.SetActive(true);

                btnTransform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = saveFiles[index].Name.Replace(".dat", "");

                btnTransform.GetComponent<Button>().onClick.AddListener(() =>
                {
                    GameObject.Find("Game Manager").GetComponent<GameManager>().saveName = btnTransform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text;

                    GameObject.Find("Game Manager").GetComponent<GameManager>().LoadSavedGame();
                });

                index++;
            }
        

    }

    public void ShowInGameLoadScreen()
    {
        foreach (Transform loadButtonPrefab in loadArea.transform)
        {
            GameObject.Destroy(loadButtonPrefab.gameObject);
        }
        
        saveFiles = new List<FileInfo>();
        Transform btnTemplate = loadButtonPrefab.transform;
        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
        FileInfo[] info = dir.GetFiles("*.dat");

        foreach (FileInfo f in info)
        {
            saveFiles.Add(f);
            Debug.Log(f);
        }

        int index = 0;
            foreach (FileInfo f in saveFiles)
            {
                Transform btnTransform = Instantiate(btnTemplate, transform);
                btnTransform.gameObject.SetActive(true);

                btnTransform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = saveFiles[index].Name.Replace(".dat", "");

                btnTransform.GetComponent<Button>().onClick.AddListener(() =>
                {
                    GameObject.Find("Game Manager").GetComponent<GameManager>().saveName = btnTransform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text;                    
                    sm.LoadData(btnTransform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text);
                });

                index++;
            }


    }

}
