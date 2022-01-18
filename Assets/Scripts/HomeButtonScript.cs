using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeButtonScript : MonoBehaviour
{
    public Button btn;
    public GameObject curtain;
    public Robot bot;
    private bool clicked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if (clicked)
        {
            print("closed!");
            curtain.GetComponent<CurtainScript>().CloseCurtain("MainMenuScene");
        }
        else
        {
            //Set bool, enlarge
            clicked = true;
            btn.image.transform.localScale = new Vector3(20, 20);

            if (curtain.GetComponent<CurtainScript>().mode.Equals("Settings"))
            {
                curtain.GetComponent<CurtainScript>().CloseCurtain("MainMenuScene");
            }
            else
            {
                //Play the robot audio and talking animation
                bot.PlayHomeButtonAudio();
            }
            
        } 
    }
}
