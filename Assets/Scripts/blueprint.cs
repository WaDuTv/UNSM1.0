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
            transform.position = hit.point + new Vector3(0, 0.2f, 0);
        }

        if (Input.GetKey(KeyCode.Period))
        {
            transform.RotateAround(transform.position, Vector3.up, 200 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Comma))
        {
            transform.RotateAround(transform.position, -Vector3.up, 200 * Time.deltaTime);
        }

        if (Input.GetMouseButton(0))
        {
            
            GameObject chiefDesk = Instantiate(prefab, transform.position - new Vector3(0,0.1f,0), transform.rotation);
            if (prefab.HasComponent<ObjController>())
            {
                prefab.GetComponent<ObjController>().maincam = GameObject.FindGameObjectWithTag("worldcam");
            }
            int num = GameObject.FindGameObjectsWithTag(prefab.tag).Length;                      
            chiefDesk.name = prefab.name + num++ ;
            Destroy(gameObject);
            //Debug.Log(this.GetComponent<build_script>().plant_01_blueprint.name.Replace("_Ghost", string.Empty));
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
