using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CluesFolder : MonoBehaviour
{

    static CluesFolder instance = null;
    private HashSet<Clue> clues = new HashSet<Clue>();
    [SerializeField] private Clue[] allClues;
    [SerializeField] private GameObject cluePannel;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        allClues = GetComponentsInChildren<Clue>();
    }

    static public CluesFolder GetCluesFolder()
    {
        return instance;
    }

    public HashSet<Clue> GetClues()
    {
        return clues;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Validate(InputField inputFieldRef)
    {
        string str = inputFieldRef.text;
        //s.ToLower();
        string s = char.ToLower(str[0]) + str.Substring(1, str.Length-1); 
        if (s == "u0")
        {
            SceneManager.LoadScene("end");
        }
        foreach(Clue c in allClues) {
            if (c.GetName() == s)
            {
                Debug.Log(s);
                clues.Add(c);
                Text[] newText = cluePannel.GetComponentsInChildren<Text>();
                Image[] newImage = cluePannel.GetComponentsInChildren<Image>();
                newImage[1].sprite = c.GetImage();
                newText[0].text = s.ToUpper();
                cluePannel.SetActive(true);
                
            }
        }
        inputFieldRef.text = "";
    }
}
