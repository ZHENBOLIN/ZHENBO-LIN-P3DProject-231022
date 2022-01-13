using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioSource audioSrc;
    public static AudioClip doorOpen;
    public static AudioClip doorClose;

    public static AudioClip ItempickUp;
    public static AudioClip ItemDrop;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        doorOpen = Resources.Load<AudioClip>("Door Open 1");
        doorClose = Resources.Load<AudioClip>("Door Close 1");

        ItempickUp = Resources.Load<AudioClip>("Hat Drop");
        ItemDrop = Resources.Load<AudioClip>("Hat Drop");
    }


    public static void PlayDoorOpenClip()
    {
        audioSrc.PlayOneShot(doorOpen);
    }

    public static void PlayDoorCloseClip()
    {
        audioSrc.PlayOneShot(doorClose);
    }

    public static void PlayItempickUpClip()
    {
        audioSrc.PlayOneShot(ItempickUp);
    }

    public static void PlayItemDropClip()
    {
        audioSrc.PlayOneShot(ItemDrop);
    }
}
