using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightmanager : MonoBehaviour
{
    public LightMapSwitcher lightMapSwitcher;

    public Material skyscraperMaterial_nonEmissive;
    public Material skyscraperMaterial_Emissive;

    [SerializeField]
    private GameObject[] switchableBuildings;

    // Start is called before the first frame update
    void Start()
    {
        switchableBuildings = GameObject.FindGameObjectsWithTag("switchableBuilding");
        if (EnviroSky.instance.isNight)
        {
            lightMapSwitcher.SetToNight();
            foreach (GameObject sb in switchableBuildings)
            {
                sb.GetComponent<MeshRenderer>().material = skyscraperMaterial_Emissive;
            }
        }
        if (EnviroSky.instance.isNight == false)
        {
            lightMapSwitcher.SetToDay();
            foreach (GameObject sb in switchableBuildings)
            {
                sb.GetComponent<MeshRenderer>().material = skyscraperMaterial_nonEmissive;
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void SwitchEmissiveMaterialsOn()
    {        
        foreach (GameObject sb in switchableBuildings)
        {
            sb.GetComponent<MeshRenderer>().material = skyscraperMaterial_Emissive;
        }
    }
    public void SwitchEmissiveMaterialsOff()
    {        

        foreach (GameObject sb in switchableBuildings)
        {
            sb.GetComponent<MeshRenderer>().material = skyscraperMaterial_nonEmissive;
        }
    }

}
