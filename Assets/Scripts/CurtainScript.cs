using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainScript : MonoBehaviour
{
    public Robot bot;
    public bool open;
    public AudioSource src;
    public string mode;
    
    // Start is called before the first frame update
    void Start()
    {
        General.sceneReady = false;
        //As soon as the scene starts, we want to move the curtain up
        StartCoroutine(MoveCurtainUp());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseCurtain(string scene)
    {
        StartCoroutine(MoveCurtainDown(scene));
    }

    IEnumerator MoveCurtainUp()
    {
        General.DisableAllButtons(GameObject.Find("Canvas"));
        while (!open)
        {
            //yield return new WaitForSeconds(.005f);
            yield return null;
            //transform.position = new Vector2(transform.position.x, transform.position.y + 2f);
            transform.position += transform.up * 0.8f * 10 * Time.deltaTime;

            if (transform.position.y >= 11.2)
            {
                //Curtain has been moved up, let's get the robot taken care of.
                if (mode.Equals("Game"))
                {
                    bot.PlayInstructions();
                }
                
                open = true;
                //Once curtain is coming up, we want to enable the buttons again
                General.EnableAllButtons(GameObject.Find("Canvas"));
            }
        }

        
    }

    IEnumerator MoveCurtainDown(string scene)
    {
        bool closed = false;

        //Ready to close - let's disable all the buttons
        General.DisableAllButtons(GameObject.Find("Canvas"));
        //yield return new WaitForSeconds(.005f);
        while (!closed)
        {
            yield return null;
            //transform.position = new Vector2(transform.position.x, transform.position.y - 2f);
            transform.position -= transform.up * 0.8f * 10 * Time.deltaTime;

            if (transform.position.y <= .7)
            {
                General.LoadScene(scene);
            }
        }
        
    }
}
