using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Button keyboardButton;
    public Button mouseButton;
    public Button restartButton;
    public GameObject GameOverScreen;
    public GameObject TitleScreen;
    public GameObject player;
    private GameObject[] skeletons;
    public Animator healthAnimator;
    public Canvas thisCanvas;
    void Start()
    {
        keyboardButton.onClick.AddListener(TaskOnClick1);
        mouseButton.onClick.AddListener(TaskOnClick2);
        restartButton.onClick.AddListener(TaskOnClick3);
        Debug.Log("UI_Manager.Start");
    }

    private void TaskOnClick1()
    {
        //reset player
        PlayerScript.instance.setHealth(3);
        player.transform.position = new Vector2(0, 0);
        GameScript.instance.keyboardPlay = true;
        GameScript.instance.mousePlay = false;
        GameScript.instance.menuState = false;
        TitleScreen.SetActive(false);
        GameScript.instance.playState = true;
        SkeletonSpawner.instance.StartGame();
        Debug.Log("TaskOnClick1");
    }
    private void TaskOnClick2()
    {
        //reset player
        PlayerScript.instance.setHealth(3);
        player.transform.position = new Vector2(0, 0);
        GameScript.instance.keyboardPlay = false;
        GameScript.instance.mousePlay = true;
        GameScript.instance.menuState = false;
        TitleScreen.SetActive(false);
        GameScript.instance.playState = true;
        SkeletonSpawner.instance.StartGame();
        Debug.Log("TaskOnClick2");
    }
    private void TaskOnClick3() //restart
    {
        skeletons = GameObject.FindGameObjectsWithTag("Skeleton");
        //delete all skeletons
        for (int i = 0; i < skeletons.Length; i++)
        {
            Destroy(skeletons[i]);
        }
        PlayerScript.instance.setHealth(3);
        healthAnimator.SetInteger("Health", 3);
        GameScript.instance.keyboardPlay = false;
        GameScript.instance.mousePlay = false;
        GameScript.instance.menuState = true;
        TitleScreen.SetActive(true);
        GameOverScreen.SetActive(false);
        //clear skeletons, restart spawner
        Debug.Log("TaskOnClick3");
    }
}
