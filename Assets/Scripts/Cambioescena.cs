using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambioescena : MonoBehaviour
{

    public string nivel;

    public void Niveles()
    {
        SceneManager.LoadScene(nivel);

    }


    public void exit()
    {
        Application.Quit();
    }
}
