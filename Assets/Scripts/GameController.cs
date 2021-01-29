using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool isPaused;

    public int maxtime = 60;

    public Camera cam;
    
    public GameObject ui;
    private UIController uiController;
    //private GameObject uiclone;
    public GameObject mainMenu;
    private GameObject mmclone;
    public GameObject mapSel;
    private GameObject msclone;

    private bool MatchRunning;
    
    public GameObject player1;
    public GameObject player2;
    
    private PlayerController _player1Controller;
    private PlayerController _player2Controller;

    public GameObject coliseo;
    public GameObject carniceria;
    public GameObject bosque;

    private GameObject background;

    private void OnEnable()
    {
        Screen.SetResolution(1920, 1080, true);
        _player1Controller = player1.GetComponent<PlayerController>();
        _player2Controller = player2.GetComponent<PlayerController>();
    }

    void Start()
    {
        mmclone = Instantiate(mainMenu);
    }

    private void Update()
    {
        if (!isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // mostrar interfaz de pausa
                isPaused = true;
            }
        }
        else if (isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // quitar interfaz de pausa
                isPaused = true;
            }
        }
    }

    private void LateUpdate()
    {
        if (MatchRunning)
        {
            UpdatePlayerLife();
            EndMatch();
        }
    }

    private void StartRound()
    {
        player1.transform.position = new Vector3(-3, 1, 0);
        player2.transform.position = new Vector3(3, 1, 0);

        uiController.SetMaxHealth(_player1Controller.GetMaxLife, _player1Controller.GetPlayerName);
        uiController.SetMaxHealth(_player2Controller.GetMaxLife, _player2Controller.GetPlayerName);
        
        _player1Controller.ResetCurrentLife = 1000;
        _player2Controller.ResetCurrentLife = 1000;
        
        uiController.RestartTimer(maxtime);
        
        uiController.SetHealth(_player1Controller.GetCurrentLife, _player1Controller.GetPlayerName);
        //uiController.SetSuper(_player1Controller.GetCurrentSuper, _player1Controller.GetPlayerName);
        uiController.SetHealth(_player2Controller.GetCurrentLife, _player2Controller.GetPlayerName);
        //uiController.SetSuper(_player2Controller.GetCurrentSuper, _player2Controller.GetPlayerName);
    }
    
    private void EndMatch()
    {
        if (uiController.Timer() != 1)
        {
            uiController.Timesup();
            Time.timeScale = 0;
            if (_player1Controller.GetCurrentLife > _player2Controller.GetCurrentLife)
                uiController.Winner(_player1Controller.GetPlayerName);
            else if (_player2Controller.GetCurrentLife > _player1Controller.GetCurrentLife)
                uiController.Winner(_player2Controller.GetPlayerName);
            MatchRunning = false;
            StartCoroutine(nameof(EndRoundCoroutine));
        }
        else if (_player1Controller.GetCurrentLife == 0)
        {
            uiController.Timesup();
            Time.timeScale = 0;
            uiController.Winner(_player1Controller.GetPlayerName);
            MatchRunning = false;
            StartCoroutine(nameof(EndRoundCoroutine));
        }
        else if (_player2Controller.GetCurrentLife == 0)
        {
            uiController.Timesup();
            Time.timeScale = 0;
            uiController.Winner(_player2Controller.GetPlayerName);
            MatchRunning = false;
            StartCoroutine(nameof(EndRoundCoroutine));
        }
    }

    private void UpdatePlayerLife()
    {
        uiController.SetHealth(_player1Controller.GetCurrentLife, _player1Controller.GetPlayerName);
        //uiController.SetSuper(_player1Controller.GetCurrentSuper, _player1Controller.GetPlayerName);
        uiController.SetHealth(_player2Controller.GetCurrentLife, _player2Controller.GetPlayerName);
        //uiController.SetSuper(_player2Controller.GetCurrentSuper, _player2Controller.GetPlayerName);
    }
    
    public void StartGame()
    {
        Destroy(mmclone);
        msclone = Instantiate(mapSel);
    }

    public void SetBackground(string fondo)
    {
        switch (fondo)
        {
            case "Coliseo":
                background = Instantiate(coliseo);
                break;
            case "Carniceria":
                background = Instantiate(carniceria);
                break;
            case "Bosque":
                background = Instantiate(bosque);
                break;
        }
    }
    
    public void StartMatch()
    {
        Destroy(msclone);
        //uiclone = Instantiate(ui);
        uiController = ui.GetComponent<UIController>();
        maxtime = 60;
        MatchRunning = true;
        StartRound();
    }
    
    public void BackToMM()
    {
        Destroy(msclone);
        mmclone = Instantiate(mainMenu);
    }

    public void BackToMS()
    {
        uiController.NoMessage();
        //Destroy(uiclone);
        Destroy(background);
        msclone = Instantiate(mapSel);
    }

    IEnumerator EndRoundCoroutine()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(3);
        BackToMS();
    }
    
}
