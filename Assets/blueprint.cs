using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueprint : MonoBehaviour
{
    RaycastHit hit;
    Vector3 movePoint;
    public GameObject prefab;
    public string CollisionName;
    private GameObject plane;


    // Start is called before the first frame update
    void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 3)))
        {
            transform.position = hit.point;
        }

        movePoint = Input.mousePosition;

    }
    // Update is called once per frame
    void Update()
    {
        //transform.Find("positioningPlane").GetComponent<Renderer>().material.color = new Color(0, 255, 0, 0.2f);

        

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 3)))
        {
            transform.position = hit.point + new Vector3(0, 0.11f, 0);
        }

        if (Input.GetKey(KeyCode.U))
        {
            transform.RotateAround(transform.position, Vector3.up, 200 * Time.deltaTime);
        }

        if (Input.GetMouseButton(0))
        {
            
            GameObject chiefDesk = Instantiate(prefab, transform.position - new Vector3(0,0.11f,0), transform.rotation);
            prefab.GetComponent<ObjController>().maincam = GameObject.FindGameObjectWithTag("worldcam");
            int num = GameObject.FindGameObjectsWithTag(prefab.tag).Length;                      
            chiefDesk.name = prefab.name + num++ ;
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        CollisionName = col.gameObject.name;
        if (col.gameObject.tag == "Furniture")
        {
            transform.Find("positioningPlane").GetComponent<Renderer>().material.color = new Color(255, 0, 0, 0.2f);
            Debug.Log("Hier steht schon was! " + CollisionName);
            Debug.Log(transform.name + transform.GetComponent<Renderer>().sharedMaterial.color + transform.name);
        }

    }

    void OnCollisionExit(Collision col)
    {
        transform.Find("positioningPlane").GetComponent<Renderer>().material.color = new Color(0, 255, 0, 0.2f);
    }
}
