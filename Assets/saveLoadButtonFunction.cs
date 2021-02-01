using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveLoadButtonFunction : MonoBehaviour
{
    private GameObject sm;

    private void Start()
    {
        sm = GameObject.Find("SaveManager");
    }
    public void Load()
    {
        sm.GetComponent<saveManager>().LoadData();
    }

    public void Save()
    {
        sm.GetComponent<saveManager>().SaveData();
    }
}
