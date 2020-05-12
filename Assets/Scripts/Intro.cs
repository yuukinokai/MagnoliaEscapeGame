using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{

    [SerializeField] private Text textDisplay;
    [SerializeField] private string currentMessage;
    [SerializeField] private GameObject continueButton;

    private IEnumerator coroutine;


    IEnumerator Type(string sentence)
    {
        //type sentence letter by letter
        foreach (char letter in sentence)
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    public void QuitGame()
    {
        if (textDisplay.text == currentMessage)
        {
            Application.Quit();
        }
        else
        {
            StopCoroutine(coroutine);
            textDisplay.text = currentMessage;
        }       
    }

    // Start is called before the first frame update
    void Start()
    {
        coroutine = Type(currentMessage);
        StartCoroutine(coroutine);
    }


    public void Continue()
    {
        if (textDisplay.text == currentMessage)
        {
            SceneManager.LoadScene("enter_clue");
        }
        else
        {
            StopCoroutine(coroutine);
            textDisplay.text = currentMessage;
        }
    }
}
