using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ObjectType //Add Prefab Names here
{
    Plant,
}

public abstract class SavableObject : MonoBehaviour
{

    protected string saveInfo;

    [SerializeField]
    private ObjectType objectType;

    // Start is called before the first frame update
    private void Start()
    {
        saveManager.Instance.SavableObjects.Add(this);
    }

    public virtual void Save(int id)
    {
        PlayerPrefs.SetString(Application.loadedLevel+"-"+ id.ToString(), objectType +"_"+ transform.position.ToString() + "_" + transform.localScale.ToString() + "_" + transform.localRotation.ToString()+"_"+saveInfo);
    }

    public virtual void Load(string[] values)
    {
        transform.localPosition = saveManager.Instance.StringToVector(values[1]);
        transform.localScale = saveManager.Instance.StringToVector(values[2]);
        transform.localRotation = saveManager.Instance.StringToQuaternion(values[3]);

    }

    public void DestroySavable()
    {
        saveManager.Instance.SavableObjects.Remove(this);
        Destroy(gameObject);
    }
}
