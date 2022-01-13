using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDoorController : MonoBehaviour
{
    [SerializeField] private Animator doorAnim = null;

    public bool doorOpen = false;

    [SerializeField] private string openAnimationName = "DoorOpen";
    [SerializeField] private string closeAnimationName = "DoorClose";

    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;


    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;
    }


    public void PlayAnimation()
    {
        if (!doorOpen && !pauseInteraction)
        {
            Debug.Log("Open door");
            SoundManager.PlayDoorOpenClip();
            doorAnim.Play("DoorOpen", 0, 0.0f);
             doorOpen = true;
            StartCoroutine(PauseDoorInteraction());
     
        }
        else if (doorOpen && !pauseInteraction)
        {
            Debug.Log("Close door");
            doorAnim.Play("DoorClose", 0, 0.0f);
            SoundManager.PlayDoorCloseClip();
            doorOpen = false;
            StartCoroutine(PauseDoorInteraction());

        }
        
    }
    
}
