using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionController : MonoBehaviour
{
    static private DecisionController thisInstance = null;
    static private int instanceNumber = 0;
    private DialogueController dcontroller = null;

    [SerializeField] private string[] messages;
    [SerializeField] private Sprite[] images;
    [SerializeField] private string[] choices;
    
    void Awake()
    {
        dcontroller = DialogueController.GetController();
        thisInstance = this;
        instanceNumber++;
        dcontroller.SetChoices(choices);
        dcontroller.SetMessages(messages, images);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
