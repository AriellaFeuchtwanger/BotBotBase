using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    int game1;
    int game2;
    int game3;
    int game4;
    public GameObject popup;
    bool popupOpen;
    bool popupClose;
    public GameObject levelTracker;
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("Mode", "Settings");
        //Set the current levels
        game1 = PlayerPrefs.GetInt("Game1MAX", 4);
        game2 = PlayerPrefs.GetInt("Game2MAX", 4);
        game3 = PlayerPrefs.GetInt("Game3MAX", 4);
        game4 = PlayerPrefs.GetInt("Game4MAX", 4);

        GameObject.Find("G1 " + game1 + "/Image").transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        GameObject.Find("G2 " + game2 + "/Image").transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        GameObject.Find("G3 " + game3 + "/Image").transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        GameObject.Find("G4 " + game4 + "/Image").transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));

        text = popup.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (popupOpen)
        {
            //print(popup.transform.position.x + ", " + popup.transform.position.y);
            popup.transform.position += popup.transform.up * 0.8f *
            10 * Time.deltaTime;

            if (popup.transform.position.y >= -0.25)
            {
                popupOpen = false;

                Button[] buttons = levelTracker.GetComponentsInChildren<Button>();

                foreach (Button btn in buttons)
                {
                    btn.interactable = false;
                    btn.transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
                }

                GameObject.Find("Header").transform.localRotation = Quaternion.Euler(0, 90, 0);
                GameObject.Find("Game 1 Btn/OpenPopUp").transform.localRotation = Quaternion.Euler(0, 90, 0);
                GameObject.Find("Game 2 Btn/OpenPopUp").transform.localRotation = Quaternion.Euler(0, 90, 0);
                GameObject.Find("Game 3 Btn/OpenPopUp").transform.localRotation = Quaternion.Euler(0, 90, 0);
                GameObject.Find("Game 4 Btn/OpenPopUp").transform.localRotation = Quaternion.Euler(0, 90, 0);

            }
        }

        if (popupClose)
        {
            print(popup.transform.position.x + ", " + popup.transform.position.y);
            popup.transform.position -= popup.transform.up * 0.8f *
            10 * Time.deltaTime;

            if (popup.transform.position.y <= -10)
            {
                popupClose = false;

                Button[] buttons = levelTracker.GetComponentsInChildren<Button>();
                foreach (Button btn in buttons)
                {
                    btn.interactable = true;
                    btn.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                }

                GameObject.Find("Header").transform.localRotation = Quaternion.Euler(0, 0, 0);
                GameObject.Find("Game 1 Btn/OpenPopUp").transform.localRotation = Quaternion.Euler(0, 0, 0);
                GameObject.Find("Game 2 Btn/OpenPopUp").transform.localRotation = Quaternion.Euler(0, 0, 0);
                GameObject.Find("Game 3 Btn/OpenPopUp").transform.localRotation = Quaternion.Euler(0, 0, 0);
                GameObject.Find("Game 4 Btn/OpenPopUp").transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    public void LevelChange(Button btn)
    {
        string[] gameLevel = btn.name.Split(' ');
        string gameName = "";
        GameObject.Find(gameLevel[0] + " " + gameLevel[1] + "/Image").transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));


        switch (gameLevel[0])
        {
            case "G1":
                GameObject.Find("G1 " + game1 + "/Image").transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
                game1 = int.Parse(gameLevel[1]);
                gameName = "Game1";
                break;
            case "G2":
                GameObject.Find("G2 " + game2 + "/Image").transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
                game2 = int.Parse(gameLevel[1]);
                gameName = "Game2";
                break;
            case "G3":
                GameObject.Find("G3 " + game3 + "/Image").transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
                game3 = int.Parse(gameLevel[1]);
                gameName = "Game3";
                break;
            case "G4":
                GameObject.Find("G4 " + game4 + "/Image").transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
                game4 = int.Parse(gameLevel[1]);
                gameName = "Game4";
                break;
        }

        PlayerPrefs.SetInt(gameName + "MAX", int.Parse(gameLevel[1]));
    }

    //Must replace this based on your needs for the game
    public void SettingsPopUp(string game)
    {
        print(game);
        popupOpen = true;

        switch (game)
        {
            case "Game 1":
                text.text = "Level 1: 4 donut colors" +
                    "\nLevel 2: 7 donut colors" +
                    "\nLevel 3: 10 donut colors" +
                    "\nLevel 4: 13 donut colors";
                break;
            case "Game 2":
                text.text = "Level 1: 3 matches/6 cards" +
                    "\nLevel 2: 4 matches/8 cards" +
                    "\nLevel 3: 6 matches/12 cards" +
                    "\nLevel 4: 8 matches/16 cards";
                break;
            case "Game 3":
                text.text = "Level 1: Continue the pattern (add 1 gift box). Series of 2." +
                    "\nLevel 2: Continue the pattern (add 2 gift boxes). Series of 2." +
                    "\nLevel 3: Continue the pattern (add 1 gift box). Series of 3." +
                    "\nLevel 4: Complete the pattern (add 1 gift box to the MIDDLE of the pattern). Series of 3";
                break;
            case "Game 4":
                text.text = "Level 1: Numbers 1-5" +
                    "\nLevel 2: Numbers 1-10" +
                    "\nLevel 3: Numbers 1-15" +
                    "\nLevel 4: Numbers 1-20";
                break;
        }



    }


    public void ClosePopup()
    {
        print("Closing!");
        popupClose = true;

    }

}
