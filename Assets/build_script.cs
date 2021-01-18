using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class build_script : MonoBehaviour
{
    public GameObject desk_blueprint;

    public void spawn_desk_bluerint()
    {
        Instantiate(desk_blueprint);
    }

    public GameObject plant_01_blueprint;

    public void spawn_plant_01_bluerint()
    {
        Instantiate(plant_01_blueprint);
    }

}
