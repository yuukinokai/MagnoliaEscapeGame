using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Clue : MonoBehaviour
{

    [SerializeField] private Text clueText;
    [SerializeField] private Sprite clueImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public string GetName()
    {
        return name;
    }

    public Sprite GetImage()
    {
        return clueImage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
