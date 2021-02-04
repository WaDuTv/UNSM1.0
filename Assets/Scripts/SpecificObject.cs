using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecificObject : SavableObject
{
    //Add Object specific values here
    [SerializeField]
    private float speed; //Example value
    [SerializeField]
    private float strength; //Example value
    [SerializeField]
    public int cost;
    [SerializeField]
    public string description;

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Save(int id)
    {
        saveInfo = cost.ToString() + "_" + speed.ToString() + "_" + description;
        base.Save(id);
    }

    public override void Load(string[] values)
    {
        cost = int.Parse(values[4]);
        speed = float.Parse(values[5]);
        description = values[6];
        base.Load(values);
    }
}
