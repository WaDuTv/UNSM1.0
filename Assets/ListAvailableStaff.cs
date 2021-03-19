using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ListAvailableStaff : MonoBehaviour
{
    public GameObject staffContainer;
    public GameObject listArea;
    public GameObject staffMemberPrefab;
    public TMP_InputField newGameName;

    private Image _backgroundImage;
    private HorizontalLayoutGroup _mainGroup;
    private TMP_Text _staffNametext;
    private TMP_Text _staffInfotext;

    
    public List<GameObject> availableStaff = null;
    // Start is called before the first frame update
    void Start()
    {

        Transform[] staff = staffContainer.GetComponentsInChildren<Transform>();
        foreach (Transform transform in staff)
        {
            if (availableStaff.Contains(transform.gameObject))
            { }
            else if (transform != null && transform.gameObject != null && transform.gameObject != staffContainer && transform.gameObject.GetComponent<StaffHandler>().isAssignedToProject == false)
            {
                //Debug.Log(transform.gameObject);
                availableStaff.Add(transform.gameObject);

            }
        }

        foreach (Transform staffMemberPrefab in listArea.transform)
        {
            GameObject.Destroy(staffMemberPrefab.gameObject);
        }

        Transform btnTemplate = staffMemberPrefab.transform;

        int index = 0;

        foreach (GameObject o in availableStaff)
        {
            Transform btnTransform = Instantiate(btnTemplate, transform);
            btnTransform.gameObject.SetActive(true);
            btnTransform.gameObject.name = "current_" + o.GetComponent<StaffHandler>().firstName + " " + o.GetComponent<StaffHandler>().lastName;
            btnTransform.gameObject.GetComponent<workerNameHolder>().workerName = "worker_" + o.GetComponent<StaffHandler>().firstName + " " + o.GetComponent<StaffHandler>().lastName;
            _backgroundImage = btnTransform.gameObject.GetComponent<Image>();
            _mainGroup = btnTransform.gameObject.GetComponent<HorizontalLayoutGroup>();
            _staffNametext = btnTransform.Find("StaffName").GetComponent<TMP_Text>();
            _staffInfotext = btnTransform.Find("Staffinfo").GetComponent<TMP_Text>();

            _backgroundImage.enabled = true;
            _mainGroup.enabled = true;
            _staffNametext.enabled = true;
            _staffInfotext.enabled = true;


            btnTransform.Find("StaffName").GetComponent<TextMeshProUGUI>().text = o.GetComponent<StaffHandler>().firstName + " " + o.GetComponent<StaffHandler>().lastName;
            btnTransform.Find("Staffinfo").GetComponent<TextMeshProUGUI>().text = "- " + o.GetComponent<StaffHandler>().workerProfession + " , Stats: Programming: " + o.GetComponent<StaffHandler>().workerStatProgramming.ToString() + ", Sound: " + o.GetComponent<StaffHandler>().workerStatSound.ToString() + ", Graphics: " + o.GetComponent<StaffHandler>().workerStatGraphics.ToString() + ", Design:" + o.GetComponent<StaffHandler>().workerStatDesign.ToString();



        }
        if (availableStaff.Count == 0)
        {
            Debug.Log("No Staff available");
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    
   public void RefreshList()
    {

        Transform[] staff = staffContainer.GetComponentsInChildren<Transform>();
        foreach (Transform transform in staff)
        {
            if(availableStaff.Contains(transform.gameObject))
            { }
            else if (transform != null && transform.gameObject != null && transform.gameObject != staffContainer && transform.gameObject.GetComponent<StaffHandler>().isAssignedToProject == false)
            {
                //Debug.Log(transform.gameObject);
                availableStaff.Add(transform.gameObject);

            }
        }

        foreach (Transform staffMemberPrefab in listArea.transform)
        {
            GameObject.Destroy(staffMemberPrefab.gameObject);
        }

        Transform btnTemplate = staffMemberPrefab.transform;

        int index = 0;

        foreach (GameObject o in availableStaff)
        {
            Transform btnTransform = Instantiate(btnTemplate, transform);
            btnTransform.gameObject.SetActive(true);
            btnTransform.gameObject.name = "current_" + o.GetComponent<StaffHandler>().firstName + " " + o.GetComponent<StaffHandler>().lastName;
            btnTransform.gameObject.GetComponent<workerNameHolder>().workerName = "worker_" + o.GetComponent<StaffHandler>().firstName + " " + o.GetComponent<StaffHandler>().lastName;
            _backgroundImage = btnTransform.gameObject.GetComponent<Image>();
            _mainGroup = btnTransform.gameObject.GetComponent<HorizontalLayoutGroup>();
            _staffNametext = btnTransform.Find("StaffName").GetComponent<TMP_Text>();
            _staffInfotext = btnTransform.Find("Staffinfo").GetComponent<TMP_Text>();

            _backgroundImage.enabled = true;
            _mainGroup.enabled = true;
            _staffNametext.enabled = true;
            _staffInfotext.enabled = true;


            btnTransform.Find("StaffName").GetComponent<TextMeshProUGUI>().text = o.GetComponent<StaffHandler>().firstName + " " + o.GetComponent<StaffHandler>().lastName;
            btnTransform.Find("Staffinfo").GetComponent<TextMeshProUGUI>().text = "- " + o.GetComponent<StaffHandler>().workerProfession + " , Stats: Programming: " + o.GetComponent<StaffHandler>().workerStatProgramming.ToString() + ", Sound: " + o.GetComponent<StaffHandler>().workerStatSound.ToString() + ", Graphics: " + o.GetComponent<StaffHandler>().workerStatGraphics.ToString() + ", Design:" + o.GetComponent<StaffHandler>().workerStatDesign.ToString();



        }
        if (availableStaff.Count == 0)
        {
            Debug.Log("No Staff available");
        }
    }

}
