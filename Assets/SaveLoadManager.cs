using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class SaveLoadManager : MonoBehaviour
{
    public TMP_InputField saveName;
    public string screenCapDirectory;
    public string fileType = ".png";
    public GameObject canvas;
    public GameObject blur;
    
    public saveManager sm;    
    public GameObject loadArea;
    public GameObject loadButtonPrefab;
    public List<FileInfo> saveFiles;
    public Sprite defaultPreview;

    private void Awake()
    {
        System.IO.Directory.CreateDirectory(Application.persistentDataPath + "/Screens4save");
    }

    private void Start()
    {
        sm = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<saveManager>();
        screenCapDirectory = Application.persistentDataPath + "/Screens4save";
    }
    
    public void OnSave()
    {
        sm = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<saveManager>();
        sm.SaveData();
        //ScreenshotHandler.TakeScreenShot_Static(Screen.width, Screen.height);
        StartCoroutine(CaptureScreen());        
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

            btnTransform.gameObject.GetComponent<Image>().enabled = true;
            btnTransform.gameObject.GetComponent<Button>().enabled = true;
            btnTransform.gameObject.GetComponent<Image>().enabled = true;
            btnTransform.gameObject.GetComponent<LayoutElement>().enabled = true;
            btnTransform.gameObject.GetComponent<VerticalLayoutGroup>().enabled = true;
            btnTransform.gameObject.GetComponent<Image>().enabled = true;

            btnTransform.Find("Image").GetComponent<Image>().enabled = true;
            btnTransform.Find("Image").GetComponent<LayoutElement>().enabled = true;

            btnTransform.Find("PreviewImage").GetComponent<Image>().enabled = true;
            btnTransform.Find("PreviewImage").GetComponent<LayoutElement>().enabled = true;
            //btnTransform.Find("PreviewImage").GetComponent<LayoutElement>().preferredWidth = (-1 * btnTransform.GetComponent<RectTransform>().sizeDelta.x) / 3;
            btnTransform.Find("PreviewImage").GetComponent<LayoutElement>().preferredHeight = btnTransform.Find("PreviewImage").GetComponent<LayoutElement>().preferredWidth / 16 * 9;

            btnTransform.Find("Image").Find("Text (TMP)").GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
            btnTransform.Find("Image").Find("Text (TMP)").GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            btnTransform.Find("Image").Find("Text (TMP)").GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
            btnTransform.Find("Image").Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = saveFiles[index].Name.Replace(".dat", "");     

            if (System.IO.File.Exists(Application.persistentDataPath + "/Screens4save/" + btnTransform.Find("Image").Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text + ".png"))
            {
                byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/Screens4save/" + btnTransform.Find("Image").Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text + ".png");
                Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, false); //Make dynamic
                texture.filterMode = FilterMode.Trilinear;
                texture.LoadImage(bytes);
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, 1920, 1080), new Vector2(0.5f, 0.0f), 1.0f);
                btnTransform.Find("PreviewImage").GetComponent<Image>().sprite = sprite;
            }
            else
            {
                btnTransform.Find("PreviewImage").GetComponent<Image>().sprite = defaultPreview;
            }

            btnTransform.GetComponent<Button>().onClick.AddListener(() =>
                {
                    GameObject.Find("Game Manager").GetComponent<GameManager>().saveName = btnTransform.Find("Image").Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text;

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

                btnTransform.Find("Image").Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = saveFiles[index].Name.Replace(".dat", "");

            if (File.Exists(Application.persistentDataPath + "/Screens4save/" + btnTransform.Find("Image").Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text + ".png"))
            {
                byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/Screens4save/" + btnTransform.Find("Image").Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text + ".png");
                Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, false); //Make dynamic
                texture.filterMode = FilterMode.Trilinear;
                texture.LoadImage(bytes);
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, 1920, 1080), new Vector2(0.5f, 0.0f), 1.0f);
                Debug.Log("File does exist");
                btnTransform.Find("PreviewImage").GetComponent<Image>().sprite = sprite;
            }
            else 
            {   
                btnTransform.Find("PreviewImage").GetComponent<Image>().sprite = defaultPreview;
            }

            btnTransform.GetComponent<Button>().onClick.AddListener(() =>
                {
                    GameObject.Find("Game Manager").GetComponent<GameManager>().saveName = btnTransform.Find("Image").Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text;                    
                    sm.LoadData(btnTransform.Find("Image").Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text);
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

            btnTransform.Find("Image").Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = saveFiles[index].Name.Replace(".dat", "");

            if (System.IO.File.Exists(Application.persistentDataPath + "/Screens4save/" + btnTransform.Find("Image").Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text + ".png"))
            {

                byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/Screens4save/" + btnTransform.Find("Image").Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text + ".png");
                Texture2D texture = new Texture2D(300, 300, TextureFormat.ARGB32, false); //Make dynamic
                texture.filterMode = FilterMode.Trilinear;
                texture.LoadImage(bytes);
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, 300, 300), new Vector2(0.5f, 0.0f), 1.0f);
                btnTransform.Find("PreviewImage").GetComponent<Image>().sprite = sprite;
            }
            else
            {
                btnTransform.Find("PreviewImage").GetComponent<Image>().sprite = defaultPreview;
            }

            btnTransform.GetComponent<Button>().onClick.AddListener(() =>
            {
                GameObject.Find("Game Manager").GetComponent<GameManager>().saveName = btnTransform.Find("Image").Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text;
                sm.LoadData(btnTransform.Find("Image").Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text);
            });

            index++;
            Debug.Log("I have been invoked!");
        }


    }

    void CreateSprite()
    {
        ScreenshotHandler.TakeScreenShot_Static(Screen.width, Screen.height);
    }

    public IEnumerator CaptureScreen()
    {
        yield return null;
        canvas.GetComponent<Canvas>().enabled = false;
        blur.GetComponent<Volume>().enabled = false;

        yield return new WaitForEndOfFrame();

        ScreenCapture.CaptureScreenshot(screenCapDirectory + "/" + saveName.text + fileType);

        canvas.GetComponent<Canvas>().enabled = true;
        blur.GetComponent<Volume>().enabled = true;
    }

}
