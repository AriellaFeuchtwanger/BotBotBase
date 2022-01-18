using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class General : MonoBehaviour
{
    public static bool sceneReady;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void MainMenuScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //Set the levels for the game:
    public static int getLevel(string initial)
    {
        //Get the max and current levels
        int maxLevel = PlayerPrefs.GetInt(initial + "MAX", 4);
        int currLevel = PlayerPrefs.GetInt(initial + "CURR", 1);

        print(currLevel);

        //Check if the max level (parent set, default lvl 4) is greater
        //than the current level
        if (maxLevel < currLevel)
        {
            return maxLevel;
        }
        else
        {
            return currLevel;
        }
    }

    //The Four levels (aka what initial can be) are:
    //1. Matching
    //2. Donuts
    //3. PresentPatterns
    //4. CoinCounting
    public static void setValues(string initial)
    {
        //Set the playerprefs with the new values:
        //First let's check if we're in the middle of something
        bool set = false;
        if (PlayerPrefs.GetFloat(initial + "4") > 0 && PlayerPrefs.GetFloat(initial + "4") < 1)
        {
            PlayerPrefs.SetFloat(initial + "4", (PlayerPrefs.GetFloat(initial + "4") - .25f));
            set = true;
        }
        else if (PlayerPrefs.GetFloat(initial + "3") > 0 && PlayerPrefs.GetFloat(initial + "3") < 1)
        {
            PlayerPrefs.SetFloat(initial + "3", (PlayerPrefs.GetFloat(initial + "3") - .25f));
            set = true;
        }
        else if (PlayerPrefs.GetFloat(initial + "2") > 0 && PlayerPrefs.GetFloat(initial + "2") < 1)
        {
            PlayerPrefs.SetFloat(initial + "2", (PlayerPrefs.GetFloat(initial + "2") - .25f));
            set = true;
        }
        else if (PlayerPrefs.GetFloat(initial + "1") > 0 && PlayerPrefs.GetFloat(initial + "1") < 1)
        {
            PlayerPrefs.SetFloat(initial + "1", (PlayerPrefs.GetFloat(initial + "1") - .25f));
            set = true;
        }

        //Now let's check if we haven't set a value yet. If yes, that means it's either the first time running,
        //or we just finished a photo
        if (!set)
        {
            if (PlayerPrefs.GetFloat(initial + "4", -1) == 0)
            {
                //All done. No more photos to unlock
            }
            else if (PlayerPrefs.GetFloat(initial + "3", -1) == 0)
            {
                PlayerPrefs.SetFloat(initial + "4", .75f);

                //Set the level
                PlayerPrefs.SetInt(initial + "CURR", 4);
            }
            else if (PlayerPrefs.GetFloat(initial + "2", -1) == 0)
            {
                PlayerPrefs.SetFloat(initial + "3", .75f);

                //Set the level
                PlayerPrefs.SetInt(initial + "CURR", 3);
            }
            else if (PlayerPrefs.GetFloat(initial + "1", -1) == 0)
            {
                PlayerPrefs.SetFloat(initial + "2", .75f);
                //Set the level
                PlayerPrefs.SetInt(initial + "CURR", 2);
            }
            else
            {
                PlayerPrefs.SetFloat(initial + "1", .75f);
                //Set the level
                PlayerPrefs.SetInt(initial + "CURR", 1);
            }
        }

    }

    public static void DisableAllButtons(GameObject canvas)
    {
        Button[] buttons = canvas.GetComponentsInChildren<Button>();

        foreach (Button btn in buttons)
        {
            btn.interactable = false;
        }
    }

    public static void EnableAllButtons(GameObject canvas)
    {
        Button[] buttons = canvas.GetComponentsInChildren<Button>();

        foreach (Button btn in buttons)
        {
            btn.interactable = true;
        }
    }
}
