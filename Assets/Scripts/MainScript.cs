using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public Robot blueBot;
    public Robot bowBot;
    public Robot mordyBot;
    public Robot swirlBot;
    int counter = 0;
    int roboCounter = 1;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ReadInstructions", 1.0f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToScene(string sceneName)
    {
        General.DisableAllButtons(GameObject.Find("Canvas"));
        GameObject.Find("Curtain").GetComponent<CurtainScript>().CloseCurtain(sceneName);
    }

    private void ReadInstructions()
    {
        switch (roboCounter)
        {
            case 1:
                blueBot.PlayMainMenu();
                break;
            case 2:
                bowBot.PlayMainMenu();
                break;
            case 3:
                mordyBot.PlayMainMenu();
                break;
            case 4:
                swirlBot.PlayMainMenu();
                break;
        }

        roboCounter++;

        if (roboCounter == 5)
        {
            roboCounter = 1;
        }
    }
}
