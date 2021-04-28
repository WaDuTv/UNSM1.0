using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomNameHolder : MonoBehaviour
{
    
    public enum FirstNames_Male
    {
        James,
        John,
        Robert,
        Michael,
        William,
        David,
        Richard,
        Joseph,
        Thomas,
        Charles,
        Christopher,
        Daniel,
        Matthew,
        Anthony,
        Donald,
        Mark,
        Paul,
        Steven,
        Andrew,
        Kenneth,
        _Max
    }

    public enum FirstNames_Female
    {
        Mary,
        Patricia,
        Jennifer,
        Linda,
        Elizabeth,
        Barbara,
        Susan,
        Jessica,
        Sarah,
        Karen,
        Nancy,
        Lisa,
        Margaret,
        Betty,
        Sandra,
        Ashley,
        Dorothy,
        Kimberly,
        Emily,
        Donna,
        _Max
    }
    public enum LastNames
    {
        Smith,
        Johnson,
        Williams,
        Brown,
        Jones,
        Garcia,
        Miller,
        Davis,
        Rodriguez,
        Martinez,
        Hernandez,
        Lopez,
        Gonzales,
        Wilson,
        Anderson,
        Thomas,
        Taylor,
        Moore,
        Jackson,
        Martin,
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
