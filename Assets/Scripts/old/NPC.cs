using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string[] dialog;
    public Sprite[] images;
    private DialogueController dc = null;

    void Awake()
    {
        dc = DialogueController.GetController();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUpAsButton()
    {
        if(dc.dialoguePanel.active || dc.detailImage.active){
            return;
        }
        dc.SetMessages(dialog, images);
        
    }
}
