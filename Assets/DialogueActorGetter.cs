using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class DialogueActorGetter : MonoBehaviour
{
    [SerializeField]
    private Transform playerContainer;
    public GameObject playerActor;
    [SerializeField]
    private DialogueSystemTrigger dialogueSystemTrigger;

    // Start is called before the first frame update
    void Start()
    {
        playerContainer = GameObject.Find("ModelContainer").GetComponent<Transform>();
        playerActor = playerContainer.Find("PlayerModel").gameObject;
        dialogueSystemTrigger.conversationActor = playerActor.transform;
    }

    // Update is called once per frame
    void Update()
    {
         
    }
}
