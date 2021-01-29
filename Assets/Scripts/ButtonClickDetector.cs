using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickDetector : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    
    public Image background;

    public Sprite fondo1;
    public Sprite fondo2;
    public Sprite fondo3;

    private string _fondoSelect;
    
    private GameController gameController;

    private Canvas canvas;
    
    void OnEnable()
    {
        //Register Button Events
        button1.onClick.AddListener(() => ButtonCallBack(button1));
        button2.onClick.AddListener(() => ButtonCallBack(button2));
        button3.onClick.AddListener(() => ButtonCallBack(button3));
        button4.onClick.AddListener(() => ButtonCallBack(button4));
        button5.onClick.AddListener(() => ButtonCallBack(button5));
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
            background.sprite = fondo1;
            background.color = Color.white;
            _fondoSelect = "Coliseo";
        }

        if (buttonPressed == button2)
        {
            //Your code for button 2
            background.sprite = fondo2;
            background.color = Color.white;
            _fondoSelect = "Carniceria";
        }

        if (buttonPressed == button3)
        {
            //Your code for button 3
            background.sprite = fondo3;
            background.color = Color.white;
            _fondoSelect = "Bosque";
        }
        
        if (buttonPressed == button4)
        {
            //Your code for button 4
            gameController.SetBackground(_fondoSelect);
            gameController.StartMatch();
        }
        
        if (buttonPressed == button5)
        {
            //Your code for button 5
            gameController.BackToMM();
        }
    }

    void OnDisable()
    {
        //Un-Register Button Events
        button1.onClick.RemoveAllListeners();
        button2.onClick.RemoveAllListeners();
        button3.onClick.RemoveAllListeners();
        button4.onClick.RemoveAllListeners();
        button5.onClick.RemoveAllListeners();
    }
}
