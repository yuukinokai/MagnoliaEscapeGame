using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private Button buttonObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DebugPrint(string s){
        Debug.Log(s);
    }

    public void ChangeScene(string s){
        SceneManager.LoadScene(s);
    }

    public void TogglePannel(GameObject o)
    {
        if (o.active)
        {
            o.SetActive(false);
        }
        else
        {
            o.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowClues(GameObject o)
    {
        Transform pannelobject = o.transform.GetChild(2).transform;
        Debug.Log(pannelobject.name);
        foreach (Transform child in pannelobject)
        {
            child.gameObject.SetActive(false);
        }
        HashSet<Clue> clues = CluesFolder.GetCluesFolder().GetClues();
        int i = 0;
        foreach(Clue c in clues)
        {
            pannelobject.GetChild(i).GetComponentsInChildren<Image>()[0].sprite = c.GetImage();
            pannelobject.GetChild(i).GetComponentsInChildren<Text>()[0].text = c.GetName().ToUpper();
            pannelobject.GetChild(i).gameObject.SetActive(true);
            i++;
        }
        o.SetActive(true);
    }
}
