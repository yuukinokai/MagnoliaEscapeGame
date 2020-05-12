using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objects : MonoBehaviour {

    public Sprite details;
    public string item;
    public Sprite itemSprite;
    public string emptyItem = "Nothing interesting here.";    
    public string moveRoom;
    private DialogueController dc = null;
    private bool clicked = false;


    // Use this for initialization
    void Awake () {
        dc = DialogueController.GetController();
    }

    // Update is called once per frame
    void Update () {

    }

    private void OnMouseDown()
    {
        
    }

    private void OnMouseEnter()
    {
        Debug.Log("enter");
    }

    private void OnMouseExit()
    {

    }

    private void OnMouseUpAsButton()
    {
        if(dc.dialoguePanel.active){
            return;
        }
        if(moveRoom != null && moveRoom != ""){
            SceneManager.LoadScene(moveRoom);
        }
        Debug.Log("click");
        if(details != null){
            dc.ShowDetail(details);
        }
        else if(item != null && item != ""){
            if(!clicked){
                string[] s = {"You found a " + item + "."};
                Sprite[] sp = {itemSprite};
                dc.SetMessages(s, sp);
                clicked = true;
            }
            else{
                string[] s = {emptyItem};
                Sprite[] sp = new Sprite[0];
                dc.SetMessages(s, sp);
                clicked = true;
            }
        }
        
    }
}