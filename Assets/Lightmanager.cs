using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightmanager : MonoBehaviour
{
    public LightMapSwitcher lightMapSwitcher;

    public Material buildingMaterial_nonEmissive;
    public Material buildingMaterial_Emissive;

    public Material skyscraperMaterial_nonEmissive;
    public Material skyscraperMaterial_Emissive;

    public Material lampMaterial_nonEmissive;
    public Material lampMaterial_Emissive;

    public Material objectMaterial_nonEmissive;
    public Material objectMaterial_Emissive;

    public Material lightBulpMaterial_nonEmissive;
    public Material lightBulpMaterial_Emissive;

    [SerializeField]
    private GameObject[] switchableBuildings;
    [SerializeField]
    private GameObject[] switchableSkyscraper;
    [SerializeField]
    private GameObject[] switchableLamps;
    [SerializeField]
    private GameObject[] switchableObjects;
    [SerializeField]
    private GameObject[] switchableLightBulp;
    [SerializeField]
    private GameObject[] switchablePointLights;
    [SerializeField]
    private GameObject[] switchableLights;


    private bool isNight;

    // Start is called before the first frame update
    void Start()
    {
        switchableBuildings = GameObject.FindGameObjectsWithTag("switchableBuilding");
        switchableSkyscraper = GameObject.FindGameObjectsWithTag("switchableSkyscraper");
        switchablePointLights = GameObject.FindGameObjectsWithTag("switchablePointLight");
        switchableLights = GameObject.FindGameObjectsWithTag("switchableLight");
        switchableLamps = GameObject.FindGameObjectsWithTag("switchableLamp");
        switchableLightBulp = GameObject.FindGameObjectsWithTag("switchableLightBulp");
        switchableObjects = GameObject.FindGameObjectsWithTag("switchableObjects");
        //if (EnviroSky.instance.isNight == true)
        //{
        //    lightMapSwitcher.SetToNight();
        //    SwitchEmissiveMaterialsOn();
        //}
        //if (EnviroSky.instance.isNight == false)
        //{
        //    lightMapSwitcher.SetToDay();
        //    SwitchEmissiveMaterialsOff();
        //}

    }

    // Update is called once per frame
    void Update()
    {
        //if (EnviroSky.instance.isNight == true)
        //{
        //    lightMapSwitcher.SetToNight();
        //    SwitchEmissiveMaterialsOn ();
        //}
        //if (EnviroSky.instance.isNight == false)
        //{
        //    lightMapSwitcher.SetToDay();
        //    SwitchEmissiveMaterialsOff();
        //}

    }

    public void SwitchEmissiveMaterialsOn()
    {        
        foreach (GameObject sb in switchableBuildings)
        {
            sb.GetComponent<MeshRenderer>().material = buildingMaterial_Emissive;
        }
        foreach (GameObject ss in switchableSkyscraper)
        {
            ss.GetComponent<MeshRenderer>().material = skyscraperMaterial_Emissive;
        }
        foreach (GameObject sl in switchableLamps)
        {
            sl.GetComponent<MeshRenderer>().material = lampMaterial_Emissive;
        }
        foreach (GameObject so in switchableObjects)
        {
            so.GetComponent<MeshRenderer>().material = objectMaterial_Emissive;
        }
        foreach (GameObject slb in switchableLightBulp)
        {
            slb.GetComponent<MeshRenderer>().enabled = true;
        }


        foreach (GameObject pl in switchablePointLights)
        {
            pl.GetComponent<Light>().enabled = true;
        }
        foreach (GameObject sl in switchableLights)
        {
            sl.GetComponent<Light>().enabled = true;
        }
    }
    public void SwitchEmissiveMaterialsOff()
    {

        foreach (GameObject sb in switchableBuildings)
        {
            sb.GetComponent<MeshRenderer>().material = buildingMaterial_nonEmissive;
        }
        foreach (GameObject sb in switchableSkyscraper)
        {
            sb.GetComponent<MeshRenderer>().material = skyscraperMaterial_nonEmissive;
        }
        foreach (GameObject sl in switchableLamps)
        {
            sl.GetComponent<MeshRenderer>().material = lampMaterial_nonEmissive;
        }
        foreach (GameObject so in switchableObjects)
        {
            so.GetComponent<MeshRenderer>().material = objectMaterial_nonEmissive;
        }
        foreach (GameObject slb in switchableLightBulp)
        {
            slb.GetComponent<MeshRenderer>().enabled = false;
        }

        foreach (GameObject pl in switchablePointLights)
        {
            pl.GetComponent<Light>().enabled = false;
        }
        foreach (GameObject sl in switchableLights)
        {
            sl.GetComponent<Light>().enabled = false;
        }
    }

}
