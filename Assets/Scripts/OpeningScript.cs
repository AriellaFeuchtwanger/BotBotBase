using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class OpeningScript : MonoBehaviour
{
    public SkeletonGraphic logo;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GoToNextScene());
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    IEnumerator GoToNextScene()
    {
        yield return new WaitForSeconds(5);

        General.MainMenuScene();
    }
}
