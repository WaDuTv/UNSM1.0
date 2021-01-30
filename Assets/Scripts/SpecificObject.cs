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
    private float cost;

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Save(int id)
    {
        saveInfo = cost.ToString() + "_" + speed.ToString();
        base.Save(id);
    }

    public override void Load(string[] values)
    {
        cost = float.Parse(values[4]);
        speed = float.Parse(values[5]);
        base.Load(values);
    }
}
