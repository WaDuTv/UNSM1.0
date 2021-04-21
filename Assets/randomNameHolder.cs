using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomNameHolder : MonoBehaviour
{
    
    public enum FirstNames_Male
    {
        Mark,
        Randy,
        Joe,
        _Max
    }

    public enum FirstNames_Female
    {
        Anna,
        Marie,
        Sandra,
        Rita,
        _Max
    }
    public enum LastNames
    {
        Henry,
        Orton,
        Samoa,
        _Max
    }



    //public string workerFirstName;
    //public string workerLastName;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    var firstNames_Male = (FirstNames_Male)Random.Range(0, 3);
    //    var lastNames_Male = (LastNames_Male)Random.Range(0, 3);

    //    workerFirstName = firstNames_Male.ToString();
    //    workerLastName = lastNames_Male.ToString();
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //public void GenerateName()
    //{
    //    var firstNames_Male = (FirstNames_Male)Random.Range(0, 3);

    //    workerFirstName = firstNames_Male.ToString();

    //}
}
