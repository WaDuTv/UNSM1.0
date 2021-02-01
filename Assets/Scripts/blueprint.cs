using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class hasComponent
{
    public static bool HasComponent<T>(this GameObject flag) where T : Component
    {
        return flag.GetComponent<T>() != null;
    }
}

public class blueprint : MonoBehaviour
{
    RaycastHit hit;
    Vector3 movePoint;
    public GameObject prefab;
    public string CollisionName;
    private GameObject plane;

    public ShopScript shopSystem;

    public int objPrice;

    private MouseControls mouseControls;

    public Vector3 targetAngle = new Vector3(0f, 0f, 0f);

    private Vector3 currentAngle;

    private void Awake()
    {
        mouseControls = new MouseControls();
    }

    private void OnEnable()
    {
        mouseControls.Enable();
    }

    private void OnDisable()
    {
        mouseControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {

        currentAngle = transform.eulerAngles;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 3)))
        {
            transform.position = hit.point;            
        }

        movePoint = Input.mousePosition;

        shopSystem = GameObject.Find("ShopManager").GetComponent<ShopScript>();

    }
    // Update is called once per frame
    void Update()
    {
        //transform.Find("positioningPlane").GetComponent<Renderer>().material.color = new Color(0, 255, 0, 0.2f);

        

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Terrain.activeTerrain.GetComponent<Collider>().Raycast(ray, out hit, 50000.0f))
        {
            transform.position = hit.point + new Vector3(0, 0.2f, 0);
        }

        if (Input.GetKeyDown(KeyCode.Period))
        {
            transform.RotateAround(transform.position, Vector3.up, 90f);
        }
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            transform.RotateAround(transform.position, -Vector3.up, 90f);
        }

        if (Input.GetMouseButtonDown(0))
        {
            int currentMoney = shopSystem.bankamount;            
            if(currentMoney >= objPrice)
            {
                int newMoney = currentMoney - objPrice;
                shopSystem.bankamount = newMoney;
                GameObject obj = Instantiate(prefab, transform.position - new Vector3(0, 0.1f, 0), transform.rotation);
                 if (prefab.HasComponent<ObjController>())
                {
                prefab.GetComponent<ObjController>().maincam = GameObject.FindGameObjectWithTag("worldcam");                
                }
                int num = GameObject.FindGameObjectsWithTag(prefab.tag).Length;
                obj.name = prefab.name + num++;
                if (Input.GetKey(KeyCode.LeftShift))
                {
                
                return;
                }            
                else
                {
                Destroy(gameObject);
                }
            }
            else
            {
                Debug.Log("Not enough Money");
                Destroy(this.gameObject);
            }
        }



        if (Input.GetMouseButton(1))
            {
                Destroy(gameObject);
            }
    }
    void OnCollisionEnter(Collision col)
    {
        CollisionName = col.gameObject.name;
        if (col.gameObject.tag == "Furniture")
        {
            transform.Find("positioningPlane").GetComponent<Renderer>().material.color = new Color(255, 0, 0);
            Debug.Log("Hier steht schon was! " + CollisionName);
            Debug.Log(transform.name + transform.GetComponent<Renderer>().sharedMaterial.color + transform.name);
        }

    }

    void OnCollisionExit(Collision col)
    {
        transform.Find("positioningPlane").GetComponent<Renderer>().material.color = new Color(0, 255, 0);
    }


}
