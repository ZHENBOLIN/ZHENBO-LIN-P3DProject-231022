using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDoorController : MonoBehaviour
{
    [SerializeField] private Animator doorAnim = null;

    public GameObject winText;

    private bool doorOpen = false;

    [SerializeField] private string openAnimationName = "LastDoorOpen";
    [SerializeField] private string closeAnimationName = "LastDoorClose";

    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;

    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;
    }


    public void LastPlayAnimation()
    {
        if (!doorOpen && !pauseInteraction)
        {
            Debug.Log("Open last door");
            SoundManager.PlayDoorOpenClip();
            doorAnim.Play(openAnimationName, 0, 0.0f);
            doorOpen = true;
            StartCoroutine(PauseDoorInteraction());
            winText.SetActive(true);
        }
        else if (doorOpen && !pauseInteraction)
        {
            Debug.Log("Close last door");
            doorAnim.Play(closeAnimationName, 0, 0.0f);
            SoundManager.PlayDoorCloseClip();
            doorOpen = false;
            StartCoroutine(PauseDoorInteraction());
            winText.SetActive(true);
        }

    }
}
