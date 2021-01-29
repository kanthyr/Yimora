using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button button1;
    public Button button2;

    private GameController gameController;

    private Canvas canvas;
    
    void OnEnable()
    {
        //Register Button Events
        button1.onClick.AddListener(() => ButtonCallBack(button1));
        button2.onClick.AddListener(() => ButtonCallBack(button2));
    }

    private void Start()
    {
        GameObject gameControl = GameObject.Find("GameController");
        gameController = gameControl.GetComponent<GameController>();
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = gameController.cam;
    }

    private void ButtonCallBack(Button buttonPressed)
    {
        if (buttonPressed == button1)
        {
            //Your code for button 1
            //Debug.Log("Boton 1");
            gameController.StartGame();
        }

        if (buttonPressed == button2)
        {
            //Your code for button 2
            //Debug.Log("Boton 2");
            Application.Quit();
        }
    }

    void OnDisable()
    {
        //Un-Register Button Events
        button1.onClick.RemoveAllListeners();
        button2.onClick.RemoveAllListeners();
    }
}
