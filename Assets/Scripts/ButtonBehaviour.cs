using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DisplayClue(GameObject cluePannel)
    {
       
        Image[] newImage = cluePannel.GetComponentsInChildren<Image>();
        newImage[2].sprite = GetComponent<Image>().sprite;
        
        cluePannel.SetActive(true);
        Debug.Log(GetComponentsInChildren<Text>()[0].text);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
