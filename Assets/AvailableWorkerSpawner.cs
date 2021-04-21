using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableWorkerSpawner : MonoBehaviour
{
    public GameObject workerPrefab;
    public bool isNewGame;

    public GameObject availableWorkersContainer;
    public randomNameHolder randomNameHolder;

    public AvailableWorkersLibraryManager availableWorkersLibraryManager;

    [SerializeField]
    Transform[] _availableWorkersArray;


    // Start is called before the first frame update
    void Awake()
    {
        //First time setup
        if(isNewGame == true)
        {
            //Generate random Number of Programmers
            var numOfProgrammers = Random.Range(1, 6);
            for (int i = 0; i < numOfProgrammers; i++)
            {
                Instantiate(workerPrefab, availableWorkersContainer.transform);
            }
            _availableWorkersArray = availableWorkersContainer.GetComponentsInChildren<Transform>();

            foreach (Transform t in _availableWorkersArray)
            {
                if (t != availableWorkersContainer.transform)
                {
                    StaffHandler _sh = t.GetComponent<StaffHandler>();
                    int _isMaleRandomizer = Random.Range(0, 2);

                    //Set Model
                    if(_isMaleRandomizer == 0)
                    {
                        _sh.isMale = false;
                        _sh.workerModelprefabIndex = Random.Range(0, 2);
                    }
                    if (_isMaleRandomizer == 1)
                    {
                        _sh.isMale = true;
                        _sh.workerModelprefabIndex = Random.Range(2, 4);
                    }
                    _sh.workerMaterialIndex = Random.Range(0, 11);

                    //Set Name
                    if (_isMaleRandomizer == 0)
                    {
                        randomNameHolder.FirstNames_Female _firstName = (randomNameHolder.FirstNames_Female)Random.Range(0, (int)randomNameHolder.FirstNames_Female._Max);
                        _sh.firstName = _firstName.ToString();

                    }
                    if (_isMaleRandomizer == 1)
                    {                        
                       randomNameHolder.FirstNames_Male _firstName = (randomNameHolder.FirstNames_Male)Random.Range(0, (int) randomNameHolder.FirstNames_Male._Max);                       
                        _sh.firstName = _firstName.ToString();
                        
                    }
                    randomNameHolder.LastNames _lastName = (randomNameHolder.LastNames)Random.Range(0, (int)randomNameHolder.LastNames._Max);
                    _sh.lastName = _lastName.ToString();

                    //Set Profession & Stats
                    _sh.workerProfession = "Programmer";
                    _sh.workerStatProgramming = Random.Range(2, 7);
                    _sh.workerStatSound = Random.Range(0, 5);
                    _sh.workerStatGraphics = Random.Range(0, 5);
                    _sh.workerStatDesign = Random.Range(1, 6);

                    if (availableWorkersLibraryManager.availableWorkers.Contains(_sh.workerID + "_" + _sh.firstName + " " + _sh.lastName))
                    { }
                    else
                    { availableWorkersLibraryManager.availableWorkers.Add(_sh.workerID +"_"+_sh.firstName + " " + _sh.lastName); }

                }
            }

            var numOfSoundDesigners = Random.Range(0, 5);
            for (int i = 0; i < numOfSoundDesigners; i++)
            {
                Instantiate(workerPrefab, availableWorkersContainer.transform);
            }
            _availableWorkersArray = availableWorkersContainer.GetComponentsInChildren<Transform>();

            foreach (Transform t in _availableWorkersArray)
            {
                if (t != availableWorkersContainer.transform)
                {
                    StaffHandler _sh = t.GetComponent<StaffHandler>();
                    int _isMaleRandomizer = Random.Range(0, 2);

                    //Set Model
                    if (_isMaleRandomizer == 0)
                    {
                        _sh.isMale = false;
                        _sh.workerModelprefabIndex = Random.Range(0, 2);
                    }
                    if (_isMaleRandomizer == 1)
                    {
                        _sh.isMale = true;
                        _sh.workerModelprefabIndex = Random.Range(2, 4);
                    }
                    _sh.workerMaterialIndex = Random.Range(0, 11);

                    //Set Name
                    if (_isMaleRandomizer == 0)
                    {
                        randomNameHolder.FirstNames_Female _firstName = (randomNameHolder.FirstNames_Female)Random.Range(0, (int)randomNameHolder.FirstNames_Female._Max);
                        _sh.firstName = _firstName.ToString();

                    }
                    if (_isMaleRandomizer == 1)
                    {
                        randomNameHolder.FirstNames_Male _firstName = (randomNameHolder.FirstNames_Male)Random.Range(0, (int)randomNameHolder.FirstNames_Male._Max);
                        _sh.firstName = _firstName.ToString();

                    }
                    randomNameHolder.LastNames _lastName = (randomNameHolder.LastNames)Random.Range(0, (int)randomNameHolder.LastNames._Max);
                    _sh.lastName = _lastName.ToString();

                    //Set Profession & Stats
                    _sh.workerProfession = "Sound Designer";
                    _sh.workerStatProgramming = Random.Range(0, 5);
                    _sh.workerStatSound = Random.Range(2, 7);
                    _sh.workerStatGraphics = Random.Range(0, 5);
                    _sh.workerStatDesign = Random.Range(1, 6);


                    if (availableWorkersLibraryManager.availableWorkers.Contains(_sh.workerID + "_" + _sh.firstName + " " + _sh.lastName))
                    { }
                    else
                    { availableWorkersLibraryManager.availableWorkers.Add(_sh.workerID + "_" + _sh.firstName + " " + _sh.lastName); }

                }
            }
            
            var numOfGraphicDesigners = Random.Range(0, 5);
            for (int i = 0; i < numOfGraphicDesigners; i++)
            {
                Instantiate(workerPrefab, availableWorkersContainer.transform);
            }
            _availableWorkersArray = availableWorkersContainer.GetComponentsInChildren<Transform>();

            foreach (Transform t in _availableWorkersArray)
            {
                if (t != availableWorkersContainer.transform)
                {
                    StaffHandler _sh = t.GetComponent<StaffHandler>();
                    int _isMaleRandomizer = Random.Range(0, 2);

                    //Set Model
                    if (_isMaleRandomizer == 0)
                    {
                        _sh.isMale = false;
                        _sh.workerModelprefabIndex = Random.Range(0, 2);
                    }
                    if (_isMaleRandomizer == 1)
                    {
                        _sh.isMale = true;
                        _sh.workerModelprefabIndex = Random.Range(2, 4);
                    }
                    _sh.workerMaterialIndex = Random.Range(0, 11);

                    //Set Name
                    if (_isMaleRandomizer == 0)
                    {
                        randomNameHolder.FirstNames_Female _firstName = (randomNameHolder.FirstNames_Female)Random.Range(0, (int)randomNameHolder.FirstNames_Female._Max);
                        _sh.firstName = _firstName.ToString();

                    }
                    if (_isMaleRandomizer == 1)
                    {
                        randomNameHolder.FirstNames_Male _firstName = (randomNameHolder.FirstNames_Male)Random.Range(0, (int)randomNameHolder.FirstNames_Male._Max);
                        _sh.firstName = _firstName.ToString();

                    }
                    randomNameHolder.LastNames _lastName = (randomNameHolder.LastNames)Random.Range(0, (int)randomNameHolder.LastNames._Max);
                    _sh.lastName = _lastName.ToString();

                    //Set Profession & Stats
                    _sh.workerProfession = "Graphic Designer";
                    _sh.workerStatProgramming = Random.Range(0, 5);
                    _sh.workerStatSound = Random.Range(0, 5);
                    _sh.workerStatGraphics = Random.Range(2, 7);
                    _sh.workerStatDesign = Random.Range(1, 6);

                    if (availableWorkersLibraryManager.availableWorkers.Contains(_sh.workerID + "_" + _sh.firstName + " " + _sh.lastName))
                    { }
                    else
                    { availableWorkersLibraryManager.availableWorkers.Add(_sh.workerID + "_" + _sh.firstName + " " + _sh.lastName); }

                }
            }

            var numOfGameDesigners = Random.Range(1, 6);
            for (int i = 0; i < numOfGameDesigners; i++)
            {
                Instantiate(workerPrefab, availableWorkersContainer.transform);
            }
            _availableWorkersArray = availableWorkersContainer.GetComponentsInChildren<Transform>();

            foreach (Transform t in _availableWorkersArray)
            {
                if (t != availableWorkersContainer.transform)
                {
                    StaffHandler _sh = t.GetComponent<StaffHandler>();
                    int _isMaleRandomizer = Random.Range(0, 2);

                    //Set Model
                    if (_isMaleRandomizer == 0)
                    {
                        _sh.isMale = false;
                        _sh.workerModelprefabIndex = Random.Range(0, 2);
                    }
                    if (_isMaleRandomizer == 1)
                    {
                        _sh.isMale = true;
                        _sh.workerModelprefabIndex = Random.Range(2, 4);
                    }
                    _sh.workerMaterialIndex = Random.Range(0, 11);

                    //Set Name
                    if (_isMaleRandomizer == 0)
                    {
                        randomNameHolder.FirstNames_Female _firstName = (randomNameHolder.FirstNames_Female)Random.Range(0, (int)randomNameHolder.FirstNames_Female._Max);
                        _sh.firstName = _firstName.ToString();

                    }
                    if (_isMaleRandomizer == 1)
                    {
                        randomNameHolder.FirstNames_Male _firstName = (randomNameHolder.FirstNames_Male)Random.Range(0, (int)randomNameHolder.FirstNames_Male._Max);
                        _sh.firstName = _firstName.ToString();

                    }
                    randomNameHolder.LastNames _lastName = (randomNameHolder.LastNames)Random.Range(0, (int)randomNameHolder.LastNames._Max);
                    _sh.lastName = _lastName.ToString();

                    //Set Profession & Stats
                    _sh.workerProfession = "Game Designer";
                    _sh.workerStatProgramming = Random.Range(1, 6);
                    _sh.workerStatSound = Random.Range(0, 5);
                    _sh.workerStatGraphics = Random.Range(0, 5);
                    _sh.workerStatDesign = Random.Range(2, 7);


                    if (availableWorkersLibraryManager.availableWorkers.Contains(_sh.workerID + "_" + _sh.firstName + " " + _sh.lastName))
                    { }
                    else
                    { availableWorkersLibraryManager.availableWorkers.Add(_sh.workerID + "_" + _sh.firstName + " " + _sh.lastName); }


                }
            }           

            isNewGame = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}