using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;
using PixelCrushers.DialogueSystem;

public class HangUpCall : MonoBehaviour
{
    [SerializeField]
    private UIView phoneCallView;
    [SerializeField]
    private UIView contacts;

    public GameObject callerModel;

public void HangUp()
    {
        if(DialogueManager.isConversationActive)
        {
            DialogueManager.StopConversation();
        }

        callerModel.GetComponent<Animator>().SetBool("callHasEnded", true);

        if(callerModel.GetComponent<isTemporaryModel>().isTemporary_ == true)
        {
            Destroy(callerModel.gameObject);
        }
        if (callerModel.GetComponent<isTemporaryModel>().isTemporary_ != true)
        {
            callerModel.transform.Find("modelCam").GetComponent<Camera>().targetTexture = null;
            GameObject _cellphone = callerModel.GetComponent<modelAttachmentsHolder>().cellPhone;
            _cellphone.SetActive(false);
        }

    }

}
