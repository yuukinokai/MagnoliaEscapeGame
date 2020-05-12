using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    static private LevelController thisInstance = null;
    static private int instanceNumber = 0;
    static private int roomNumber = 0;

    int count = 0;

    static private string[] scenes = {"room1", "room2", "room3"};

    void Awake(){
        thisInstance = this;
        instanceNumber++;
       // Debug.Log("Set Controller");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeScene(string sname){
        SceneManager.LoadScene(sname);
    }

    public void changeRight(){
        roomNumber = (roomNumber + 1) % scenes.Length;
        string nextRoom = scenes[roomNumber];
        SceneManager.LoadScene(nextRoom);
    }

    public void changeLeft(){
        roomNumber = (roomNumber - 1) % scenes.Length;
        while (roomNumber < 0){
            roomNumber += scenes.Length;
        }
        string nextRoom = scenes[roomNumber];
        SceneManager.LoadScene(nextRoom);
    }
}
