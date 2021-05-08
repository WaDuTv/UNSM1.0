using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Doozy.Engine.UI;
using PixelCrushers.DialogueSystem;
using BehaviorDesigner.Runtime;

public class HangUpCall : MonoBehaviour
{
    [SerializeField]
    private UIView phoneCallView;
    [SerializeField]
    private UIView contacts;
    private AlwaysVisibleHolderScript alwaysVisibleHolderScript;

    public GameObject callerModel;

public void HangUp()
    {
        alwaysVisibleHolderScript = GameObject.Find("AlwaysVisibleHolder").GetComponent<AlwaysVisibleHolderScript>();
        string[] calledPersonNameArray = callerModel.name.Split(char.Parse("_"));
        string calledPerson = calledPersonNameArray[1];
        StaffHandler staffHandler = GameObject.Find("worker_" + calledPerson).GetComponent<StaffHandler>();
        Animator _modelAnimator = callerModel.GetComponent<Animator>();
        if(DialogueManager.isConversationActive)
        {
            DialogueManager.StopConversation();
        }

        alwaysVisibleHolderScript.playerModel.GetComponent<stateChanger>().isIdle = true;        
        //_modelAnimator.SetBool("callHasEnded", true);
        //_modelAnimator.SetBool("isBeingCalled", false);

        SetUpWorkerModelAfterCall();
    }

    public void SetUpWorkerModelAfterCall()
    {
        string[] calledPersonNameArray = callerModel.name.Split(char.Parse("_"));       
        string calledPerson = calledPersonNameArray[1];
        StaffHandler staffHandler = GameObject.Find("worker_" + calledPerson).GetComponent<StaffHandler>();
        Animator _modelAnimator = callerModel.GetComponent<Animator>();

        if (callerModel.GetComponent<isTemporaryModel>().isTemporary_ == true && callerModel.GetComponent<isTemporaryModel>().wasHired == false)
        {
            Destroy(callerModel.gameObject);
        }
        if (callerModel.GetComponent<isTemporaryModel>().isTemporary_ != true || callerModel.GetComponent<isTemporaryModel>().wasHired == true)
        {
            callerModel.transform.Find("modelCam").GetComponent<Camera>().targetTexture = null;
            GameObject _cellphone = callerModel.GetComponent<modelAttachmentsHolder>().cellPhone;
            _cellphone.SetActive(false);
        }
        if (callerModel.GetComponent<isTemporaryModel>().wasHired == true && callerModel.GetComponent<isTemporaryModel>().isTemporary_ == true)
        {
            GameObject[] _modelspawnPositions = GameObject.FindGameObjectsWithTag("newWorkerSpawn");

            int _index = Random.Range(0, _modelspawnPositions.Length);

            staffHandler.lastModelPosition = _modelspawnPositions[_index].transform.position;
            callerModel.transform.position = _modelspawnPositions[_index].transform.position;
            callerModel.GetComponent<NavMeshAgent>().Warp(_modelspawnPositions[_index].transform.position);
            callerModel.transform.eulerAngles = _modelspawnPositions[_index].transform.eulerAngles;

            callerModel.GetComponent<stateChanger>().isOnPhone = false;
            callerModel.GetComponent<stateChanger>().isIdle = true;
            
            //_modelAnimator.SetBool("isIdle", true);
            //_modelAnimator.SetBool("callHasEnded", false);
        }
    }
}
