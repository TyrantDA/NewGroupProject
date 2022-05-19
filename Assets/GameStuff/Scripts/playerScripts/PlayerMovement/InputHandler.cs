using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    TopDownCharacterMover move;
    public AudioSource walking;
    public AudioSource running;
    bool playingWalk = false;
    bool playingRun = false;
    public Vector2 InputVector { get; private set; }

    public Vector3 MousePosition { get; private set; }
    // Update is called once per frame

    private void Start()
    {
        move = GetComponent<TopDownCharacterMover>();
    }
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        InputVector = new Vector2(h, v);

        if(h != 0 || v != 0)
        {
            if (!move.notActive)
            {
                if (!playingWalk)
                {
                    if (playingRun)
                    {
                        running.Pause();
                        playingRun = false;

                    }
                    walk();
                }
            }
            else
            {
                if(!playingRun)
                {
                    if(playingWalk)
                    {
                        walking.Pause();
                        playingWalk = false;
                    }
                    run();
                }
            }
        }
        else
        {
            StopCoroutine("walk");
            if (!move.notActive)
            {
                walking.Pause();
                playingWalk = false;
            }
            else
            {
                running.Pause();
                playingRun = false;
            }
           
        }

        MousePosition = Input.mousePosition;
    }

    void walk()
    {
        walking.Play();
        playingWalk = true;
    }

    void run()
    {
        running.Play();
        playingRun = true;
    }
}
