using System;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("LifeBars")]
    public Slider lifebarP1;
    public Image lifefillP1;
    public Slider lifebarP2;
    public Image lifefillP2;
    [Header("SuperBars")]
    public Slider superbarP1;
    public Image superfillP1;
    public Slider superbarP2;
    public Image superfillP2;
    [Header("Timer")]
    public Text timeui;
    public Text centralText;
    [Header("Gradient")]
    public Gradient lifegradient;
    public Gradient supergradient;
    [Header("Fondo")]

    private float _tiempo;
    
    private GameController gameController;

    private Canvas canvas;


    /*
      private void Start()
    {
        GameObject gameControl = GameObject.Find("GameController");
        gameController = gameControl.GetComponent<GameController>();
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = gameController.cam;
        NoMessage();
    }
     */

    public void RestartTimer(int maxtime)
    {
        _tiempo = maxtime;
    }

    internal void Timesup()
    {
        centralText.text = "¡Se Acabó!";
    }
    
    internal void Fight()
    {
        centralText.text = "¡A Luchar!";
    }
    
    internal void NoMessage()
    {
        centralText.text = "";
    }
    
    internal void Winner(string winner)
    {
        centralText.text = "¡" + winner + " ha ganado!";
    }

    public int Timer()
    {
        if ((int)_tiempo == 0)
        {
            timeui.text = "" + 0;
            return 0;
        }
        else if ((int)_tiempo == -1)
        {
            timeui.text = "∞";
            return 1;
        }
        else
        {
            _tiempo -= 1 * Time.deltaTime;
            timeui.text = "" + _tiempo.ToString("0");
            return 1;
        }
    }

    public void SetMaxHealth(int health, string playername)
    {
        if(playername == "Player1")
        {
            lifebarP1.maxValue = health;
            lifebarP1.value = health;

            lifefillP1.color = lifegradient.Evaluate(1f);
        }
        else if (playername == "Player2")
        {
            lifebarP2.maxValue = health;
            lifebarP2.value = health;

            lifefillP2.color = lifegradient.Evaluate(1f);
        }
    }

    public void SetHealth(int health, string playername)
    {
        if (playername == "Player1")
        {
            lifebarP1.value = health;

            lifefillP1.color = lifegradient.Evaluate(lifebarP1.normalizedValue);
        }
        else if (playername == "Player2")
        {
            lifebarP2.value = health;

            lifefillP2.color = lifegradient.Evaluate(lifebarP1.normalizedValue);
        }
        
    }

    public void SetMaxSuper(int super, string playername)
    {
        if (playername == "Player1")
        {
            superbarP1.maxValue = super;
            superbarP1.value = super;

            superfillP1.color = supergradient.Evaluate(1f);
        }
        else if (playername == "Player2")
        {
            superbarP2.maxValue = super;
            superbarP2.value = super;
            
            superfillP2.color = supergradient.Evaluate(1f);
        }
        
    }

    public void SetSuper(int super, string playername)
    {
        if (playername == "Player1")
        {
            superbarP1.value = super;

            superfillP1.color = supergradient.Evaluate(superbarP1.normalizedValue);
        }
        else if (playername == "Player2")
        {
            superbarP2.value = super;

            superfillP2.color = supergradient.Evaluate(superbarP2.normalizedValue);
        }
        
    }
}
