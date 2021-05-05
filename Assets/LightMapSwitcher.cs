using UnityEngine;

using System.Linq;

public class LightMapSwitcher : MonoBehaviour
{
    public Texture2D[] DayNear;
    public Texture2D[] DayFar;
    //public Texture2D[] DayShadowmask;
    public Texture2D[] NightNear;
    public Texture2D[] NightFar;
    //public Texture2D[] NightShadowmask;

    private LightmapData[] dayLightMaps;
    private LightmapData[] nightLightMaps;

    void Start()
    {
        if ((DayNear.Length != DayFar.Length) || (NightNear.Length != NightFar.Length))
        {
            Debug.Log("In order for LightMapSwitcher to work, the Near and Far LightMap lists must be of equal length");
            return;
        }

        // Sort the Day and Night arrays in numerical order, so you can just blindly drag and drop them into the inspector
        DayNear = DayNear.OrderBy(t2d => t2d.name, new NaturalSortComparer<string>()).ToArray();
        DayFar = DayFar.OrderBy(t2d => t2d.name, new NaturalSortComparer<string>()).ToArray();
        //DayShadowmask = DayShadowmask.OrderBy(t2d => t2d.name, new NaturalSortComparer<string>()).ToArray();
        NightNear = NightNear.OrderBy(t2d => t2d.name, new NaturalSortComparer<string>()).ToArray();
        NightFar = NightFar.OrderBy(t2d => t2d.name, new NaturalSortComparer<string>()).ToArray();
        //NightShadowmask = NightShadowmask.OrderBy(t2d => t2d.name, new NaturalSortComparer<string>()).ToArray();

        // Put them in a LightMapData structure
        dayLightMaps = new LightmapData[DayNear.Length];
        for (int i = 0; i < DayNear.Length; i++)
        {
            dayLightMaps[i] = new LightmapData();
            dayLightMaps[i].lightmapDir = DayNear[i];
            dayLightMaps[i].lightmapColor = DayFar[i];
            //dayLightMaps[i].shadowMask = DayShadowmask[i];
        }

        nightLightMaps = new LightmapData[NightNear.Length];
        for (int i = 0; i < NightNear.Length; i++)
        {
            nightLightMaps[i] = new LightmapData();
            nightLightMaps[i].lightmapDir = NightNear[i];
            nightLightMaps[i].lightmapColor = NightFar[i];
            //nightLightMaps[i].shadowMask = NightShadowmask[i];
        }
    }

    #region Publics
    public void SetToDay()
    {
        LightmapSettings.lightmaps = dayLightMaps;
    }

    public void SetToNight()
    {
        LightmapSettings.lightmaps = nightLightMaps;
    }
    #endregion

    #region Debug
    [ContextMenu("Set to Night")]
    void Debug00()
    {
        SetToNight();
    }

    [ContextMenu("Set to Day")]
    void Debug01()
    {
        SetToDay();
    }
    #endregion
}

//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;
//using UnityEngine.Rendering;
//using System.Collections;
 
//public class LightmapsSwap : MonoBehaviour
//{
//    //GUI dropdown
//    public Dropdown dropdown;

//    private LightmapData[] Daydata;
//    private LightmapData[] Nightdata;

//    private LightmapData[][] allLightmaps;

//    private Texture[] DayReflections;
//    private Texture[] NightReflections;

//    private Texture[][] allReflections;

//    private ReflectionProbe[] allReflectionProbes;
//    //path to the night lightmap and reflection substitudes
//    public string nightpath = "";



//    // Use this for initialization
//    void Start()
//    {
//        //ypu can duplicate lightmap folder to break references, move to Resources, and rename back to the scene name
//        if (nightpath == "") nightpath = SceneManager.GetActiveScene().name;

//        Daydata = LightmapSettings.lightmaps;

//        allLightmaps = new LightmapData[2][];
//        allLightmaps[0] = Daydata;

//        Nightdata = new LightmapData[Daydata.Length];

//        for (int i = 0; i < Daydata.Length; i++)
//        {
//            Nightdata[i] = new LightmapData();
//            Nightdata[i].lightmapFar = Resources.Load(nightpath + "/" + Daydata[i].lightmapFar.name) as Texture2D;
//            Nightdata[i].lightmapNear = Resources.Load(nightpath + "/" + Daydata[i].lightmapNear.name) as Texture2D;
//        }

//        allLightmaps[1] = Nightdata;

//        allReflectionProbes = FindObjectsOfType<ReflectionProbe>();

//        DayReflections = new Texture[allReflectionProbes.Length];
//        NightReflections = new Texture[allReflectionProbes.Length];

//        for (int i = 0; i < allReflectionProbes.Length; i++)
//        {
//            DayReflections[i] = allReflectionProbes[i].bakedTexture;
//            NightReflections[i] = Resources.Load(nightpath + "/" + DayReflections[i].name) as Texture;
//            allReflectionProbes[i].mode = ReflectionProbeMode.Custom;
//            allReflectionProbes[i].customBakedTexture = DayReflections[i];
//        }

//        allReflections = new Texture[2][];
//        allReflections[0] = DayReflections;
//        allReflections[1] = NightReflections;

//        dropdown.onValueChanged.AddListener(delegate
//        {
//            SwapLightmaps(dropdown.value);
//        });
//    }

//    public void SwapLightmaps(int option)
//    {

//        LightmapSettings.lightmaps = allLightmaps[option];
//        for (int i = 0; i < allReflectionProbes.Length; i++)
//        {
//            allReflectionProbes[i].customBakedTexture = allReflections[option][i];
//        }
//    }
//}