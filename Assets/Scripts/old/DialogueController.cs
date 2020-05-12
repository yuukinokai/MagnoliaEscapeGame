using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    static private DialogueController thisInstance = null;
    static private int instanceNumber = 0;

    [SerializeField] private Text textDisplay;                  //main display for dialog text
    [SerializeField] private GameObject continueButton;         //click area to continue text
    [SerializeField] public GameObject dialoguePanel; 
    [SerializeField] private GameObject dialogueImage; 
    [SerializeField] public GameObject detailImage;

    [SerializeField] private string[] messages;
    [SerializeField] private Sprite[] images;
    [SerializeField] private GameObject[] choiceButtons;

    private Sprite detail;
    private string[] choices;
    private string currentMessage;
    private int messageIndex = 0;

    IEnumerator Type(string sentence)
    {
        //type sentence letter by letter
        foreach (char letter in sentence)
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    public void ShowDetail(Sprite s){
        detailImage.GetComponent<Image>().sprite = s;
        detailImage.SetActive(true);
    }

    public void CloseDetail(){
        detailImage.SetActive(false);
    }

    public void SetChoices(string[] c){
        choices = c;
    }

    public void SetMessages(string[] m, Sprite[] i){
        messageIndex = 0;
        messages = m;
        images = i;
        NextSentence();
    }

    static public DialogueController GetController(){
        if(thisInstance == null){
            Debug.Log("Error : No instance of Controller.");
        }
        return thisInstance;
    }

    void Awake(){
        thisInstance = this;
        instanceNumber++;
        NextSentence();
       // Debug.Log("Set Controller");
    }

    //update controls the continue button
    void Update()
    {
        if(textDisplay.text == currentMessage)
        {
            continueButton.SetActive(true);
        }
    }

    public void AddChoices(){
        for(int i = 0; i < choices.Length; i++){
            Debug.Log(choices[i]);
            choiceButtons[i].transform.GetChild(0).GetComponent<Text>().text = choices[i];
            choiceButtons[i].SetActive(true);
        }
    }

    public void NextSentence()
    {
        if(messageIndex >= messages.Length){
            dialoguePanel.SetActive(false);
            choices = null;
        }
        else{
            dialoguePanel.SetActive(true);
        }
        if((messageIndex == messages.Length - 1) && (choices != null && choices.Length != 0)){
            AddChoices();
        }
        else{
            Debug.Log("hide buttons");
            foreach(GameObject b in choiceButtons){
                b.SetActive(false);
            }
        }
        if(messageIndex < messages.Length){
            continueButton.SetActive(false);
            textDisplay.text = "";
            if(images.Length <= messageIndex || images[messageIndex] == null){
                dialogueImage.SetActive(false);
            }
            else{
                dialogueImage.SetActive(true);
                dialogueImage.GetComponent<Image>().sprite = images[messageIndex];
            }
            
            
            currentMessage = messages[messageIndex];
            StartCoroutine(Type(messages[messageIndex]));
            messageIndex++;
        }
    }

}
