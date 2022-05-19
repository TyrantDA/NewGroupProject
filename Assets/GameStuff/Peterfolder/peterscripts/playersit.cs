using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playersit : MonoBehaviour
{
    public Animator anim;
    public Collider cap;
    public Collider shp;
    public GameObject hold;
    public AudioSource laugh;
    public AudioSource celebration1;
    public AudioSource celebration2;
    bool playingLoop = false;
    bool playingSound = false;

    bool sitting = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool getSitting()
    {
        return sitting;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            if (anim.GetBool("sit") == false)
            {
                anim.SetBool("sit", true);
                cap.enabled = !cap.enabled;
                shp.enabled = !shp.enabled;
                GetComponent<InputHandler>().enabled = !GetComponent<InputHandler>().enabled;
                GetComponent<TopDownCharacterMover>().enabled = !GetComponent<TopDownCharacterMover>().enabled;
                sitting = true;

            }
            else
            {
                anim.SetBool("sit", false);
                cap.enabled = !cap.enabled;
                shp.enabled = !shp.enabled;
                GetComponent<InputHandler>().enabled = !GetComponent<InputHandler>().enabled;
                GetComponent<TopDownCharacterMover>().enabled = !GetComponent<TopDownCharacterMover>().enabled;
                sitting = false;
            }

        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (anim.GetBool("sit") == false)
            {
                hold.gameObject.SetActive(true);
                anim.SetBool("sit", true);
                cap.enabled = !cap.enabled;
                shp.enabled = !shp.enabled;
                GetComponent<InputHandler>().enabled = !GetComponent<InputHandler>().enabled;
                GetComponent<TopDownCharacterMover>().enabled = !GetComponent<TopDownCharacterMover>().enabled;
                sitting = true;
            }
            else
            {
                hold.gameObject.SetActive(false);
                anim.SetBool("sit", false);
                cap.enabled = !cap.enabled;
                shp.enabled = !shp.enabled;
                GetComponent<InputHandler>().enabled = !GetComponent<InputHandler>().enabled;
                GetComponent<TopDownCharacterMover>().enabled = !GetComponent<TopDownCharacterMover>().enabled;
                sitting = false;
            }

        }
        if (Input.GetKeyUp("h"))
        {
            laugh.Pause();
            anim.SetBool("dance", false);
            playingSound = false;

        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            laugh.Play();
            anim.SetBool("dance", true);
            playingSound = true;

        }
        if (Input.GetKeyUp("h"))
        {
            laugh.Pause();
            anim.SetBool("dance", false);
            playingSound = false;
        }

        if (playingSound)
        {
            if (!playingLoop)
            {
                StartCoroutine("playDanceSound");
            }
        }
        else
        {
            if(playingLoop)
            {
                StopCoroutine("playDanceSound");
                laugh.Stop();
                celebration1.Stop();
                celebration2.Stop();
            }

        }
    }

    IEnumerator playDanceSound()
    {
        playingLoop = true;
        laugh.Play();
        yield return new WaitForSeconds(laugh.clip.length);
        celebration1.Play();
        yield return new WaitForSeconds(celebration1.clip.length);
        celebration2.Play();
        yield return new WaitForSeconds(celebration2.clip.length);
        playingLoop = false;
    }

}
