using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuGameOver : MonoBehaviour
{
    [SerializeField] private GameObject GameOver;
    private GM gm;

    //jugar otra vez
    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //salir al menu principal
    public void Salir(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
}
