using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int DeathlyHollowsNumber = 0;

    public GameObject TriggerCube;
    public GameObject Boll;
    public GameObject DeathlyHallows;
    public GameObject winButton;

    public GameObject hidedtaskText;
    public GameObject showedtaskText;
    public bool taskShow = true;

    public GameObject hidedshortKeyText;
    public GameObject showedshortKeyText;
    public bool shortKeyShow = true;



    public static GameManager Instance;



    void Awake()
    {
        Instance = this;
    }

     void Update()
    {
        if (DeathlyHollowsNumber >= 5)
        {
            winButton.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("cheat");
            DeathlyHollowsNumber = 5;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (!taskShow)
            {
                Debug.Log("show task");
                taskShow = true;
                showedtaskText.SetActive(true);
                hidedtaskText.SetActive(false);
            }
            else 
            {
                Debug.Log("hide task");
                taskShow = false;
                showedtaskText.SetActive(false);
                hidedtaskText.SetActive(true);
            }

        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (!shortKeyShow)
            {
                Debug.Log("show shortKey");
                shortKeyShow = true;
                showedshortKeyText.SetActive(true);
                hidedshortKeyText.SetActive(false);
            }
            else 
            {
                Debug.Log("hide shortKey");
                shortKeyShow = false;
                showedshortKeyText.SetActive(false);
                hidedshortKeyText.SetActive(true);
            }

        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Debug.Log("Quit");
            Application.Quit();
        }



        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        TriggerCube.SetActive(false);
        Boll.SetActive(true);
        DeathlyHallows.SetActive(true);
    }

}
