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

    private bool isNight;

    // Start is called before the first frame update
    void Start()
    {
        switchableBuildings = GameObject.FindGameObjectsWithTag("switchableBuilding");
        if (EnviroSky.instance.isNight == true)
        {
            lightMapSwitcher.SetToNight();
            SwitchEmissiveMaterialsOn();
        }
        if (EnviroSky.instance.isNight == false)
        {
            lightMapSwitcher.SetToDay();
            SwitchEmissiveMaterialsOff();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (EnviroSky.instance.isNight == true)
        {
            lightMapSwitcher.SetToNight();
            SwitchEmissiveMaterialsOn ();
        }
        if (EnviroSky.instance.isNight == false)
        {
            lightMapSwitcher.SetToDay();
            SwitchEmissiveMaterialsOff();
        }

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
