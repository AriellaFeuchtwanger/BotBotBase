using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReplayButtonScript : MonoBehaviour
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
            //Reset the level
            string currGame = PlayerPrefs.GetString("Game");
            //Load the scene
            curtain.GetComponent<CurtainScript>().CloseCurtain(currGame);
        }
        else
        {
            clicked = true;
            btn.image.transform.localScale = new Vector3(20, 20);

            //Play Audio
            bot.PlayReplayButtonAudio();
        }
    }
}
