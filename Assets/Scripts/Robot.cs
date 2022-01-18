using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Robot : MonoBehaviour
{
    public GameObject bot;
    SkeletonGraphic anim;
    public AudioSource src;
    public AudioClip oops;
    public AudioClip goodJob;
    public AudioClip hooray;
    public AudioClip instructions;
    public AudioClip home;
    public AudioClip replay;
    public AudioClip endofgame;
    public AudioClip mainMenu;
    float talkAnimationDuration;

    // Start is called before the first frame update
    void Start()
    {
        anim = bot.GetComponent<SkeletonGraphic>();
        talkAnimationDuration = anim.Skeleton.Data.FindAnimation("Talk").Duration;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayHomeButtonAudio()
    {
        src.Stop();
        src.PlayOneShot(home);
        anim.AnimationState.SetAnimation(2, "Talk", false);

        float counter = home.length;
        while (counter > 1)
        {
            anim.AnimationState.AddAnimation(2, "Talk", false, 0f);
            counter -= talkAnimationDuration;
        }
    }

    public void PlayReplayButtonAudio()
    {
        src.Stop();
        src.PlayOneShot(replay);
        anim.AnimationState.SetAnimation(2, "Talk", false);

        float counter = replay.length;
        while (counter > 1)
        {
            anim.AnimationState.AddAnimation(2, "Talk", false, 0f);
            counter -= talkAnimationDuration;
        }
    }

    public void PlayOneHurrayAudioandAnim()
    {
        anim.AnimationState.SetAnimation(1, "Yay", false);
        anim.AnimationState.AddAnimation(1, "Idle", true, 0f);

        src.Stop();
        src.PlayOneShot(goodJob);
        anim.AnimationState.SetAnimation(2, "Talk", false);

        float counter = goodJob.length;
        while (counter > 1)
        {
            anim.AnimationState.AddAnimation(2, "Talk", false, 0f);
            counter -= talkAnimationDuration;
        }

    }

    public void PlayOops()
    {
        anim.AnimationState.SetAnimation(1, "Oops", false);
        anim.AnimationState.AddAnimation(1, "Idle", true, 0f);

        src.Stop();
        src.PlayOneShot(oops);
        anim.AnimationState.SetAnimation(2, "Talk", false);

        float counter = oops.length;
        while (counter > 1)
        {
            anim.AnimationState.AddAnimation(2, "Talk", false, 0f);
            counter -= talkAnimationDuration;
        }
    }

    public void EndOfGame()
    {
        //Play hooray
        anim.AnimationState.SetAnimation(1, "Raise Hands", false);
        anim.AnimationState.AddAnimation(1, "Wave", true, 0f);

        src.Stop();
        src.PlayOneShot(hooray);
        anim.AnimationState.SetAnimation(2, "Talk", false);

        float counter = hooray.length;
        while (counter > 1)
        {
            anim.AnimationState.AddAnimation(2, "Talk", false, 0f);
            counter -= talkAnimationDuration;
        }


        //Play end of game
        InvokeRepeating("PlayEndGame", 1f, 20f);
    }

    private void PlayEndGame()
    {
        src.PlayOneShot(endofgame);
    }


    public void PlayMainMenu()
    {
        src.Stop();
        src.PlayOneShot(mainMenu);
        anim.AnimationState.SetAnimation(2, "Talk", false);

        float counter = mainMenu.length;
        while (counter > 1)
        {
            anim.AnimationState.AddAnimation(2, "Talk", false, 0f);
            counter -= talkAnimationDuration;
        }
    }

    public void PlayInstructions()
    {
        src.Stop();
        src.PlayOneShot(instructions);
        anim.AnimationState.SetAnimation(2, "Talk", false);

        float counter = instructions.length;
        while (counter > 1)
        {
            anim.AnimationState.AddAnimation(2, "Talk", false, 0f);
            counter -= talkAnimationDuration;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        src.Stop();
        src.PlayOneShot(clip);
    }

    private void Talk(float timeOfClip)
    {

    }
}
