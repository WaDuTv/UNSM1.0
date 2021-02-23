using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveLoadManager : MonoBehaviour
{
    public TMP_InputField saveName;
    public saveManager sm;    
    public GameObject loadArea;
    public GameObject loadButtonPrefab;
    public List<FileInfo> saveFiles;
    public Sprite defaultPreview;
    
    private void Start()
    {
        sm = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<saveManager>();
    }
    
    public void OnSave()
    {
        sm = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<saveManager>();
        sm.SaveData();
        ScreenshotHandler.TakeScreenShot_Static(Screen.width, Screen.height);
        ShowInGameLoadScreen();    
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

            byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/Screens4save/" + btnTransform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text + ".png");
            Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, false); //Make dynamic
            texture.filterMode = FilterMode.Trilinear;
            texture.LoadImage(bytes);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, Screen.width, Screen.height), new Vector2(0.5f, 0.0f), 1.0f);

            if (System.IO.File.Exists(Application.persistentDataPath + "/Screens4save/" + btnTransform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text + ".png"))
            {
                btnTransform.Find("PreviewImage").GetComponent<Image>().sprite = sprite;
            }
            else
            {
                btnTransform.Find("PreviewImage").GetComponent<Image>().sprite = defaultPreview;
            }

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

                byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/Screens4save/" + btnTransform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text + ".png");
                Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, false); //Make dynamic
                texture.filterMode = FilterMode.Trilinear;
                texture.LoadImage(bytes);
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, Screen.width,Screen.height), new Vector2(0.5f,0.0f),1.0f);
                
                if (System.IO.File.Exists(Application.persistentDataPath + "/Screens4save/" + btnTransform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text + ".png"))
                {
                btnTransform.Find("PreviewImage").GetComponent<Image>().sprite = sprite;
                }
                else
                {
                btnTransform.Find("PreviewImage").GetComponent<Image>().sprite = defaultPreview;
                }

                btnTransform.GetComponent<Button>().onClick.AddListener(() =>
                {
                    GameObject.Find("Game Manager").GetComponent<GameManager>().saveName = btnTransform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text;                    
                    sm.LoadData(btnTransform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text);
                });

                index++;
            Debug.Log("I have been invoked!");
            }


    }

    public IEnumerator RefreshInGameLoadScreen()
    {
        yield return new WaitForSeconds(1f);
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

            byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/Screens4save/" + btnTransform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text + ".png");
            Texture2D texture = new Texture2D(300, 300, TextureFormat.ARGB32, false); //Make dynamic
            texture.filterMode = FilterMode.Trilinear;
            texture.LoadImage(bytes);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, 300, 300), new Vector2(0.5f, 0.0f), 1.0f);

            if (System.IO.File.Exists(Application.persistentDataPath + "/Screens4save/" + btnTransform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text + ".png"))
            {
                btnTransform.Find("PreviewImage").GetComponent<Image>().sprite = sprite;
            }
            else
            {
                btnTransform.Find("PreviewImage").GetComponent<Image>().sprite = defaultPreview;
            }

            btnTransform.GetComponent<Button>().onClick.AddListener(() =>
            {
                GameObject.Find("Game Manager").GetComponent<GameManager>().saveName = btnTransform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text;
                sm.LoadData(btnTransform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text);
            });

            index++;
            Debug.Log("I have been invoked!");
        }


    }

    void CreateSprite()
    {
        ScreenshotHandler.TakeScreenShot_Static(Screen.width, Screen.height);
    }

}
