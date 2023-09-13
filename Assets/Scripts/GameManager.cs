using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [System.NonSerialized]
    public bool startRound = false;

    public GameObject UIWaiting;
    public GameObject UICountDown;
    public List<string> Nombre;
    public List<string> Apellido;
    public Timer timer;

    public GameObject UIGame;
    public GameObject UIResults;
    [System.NonSerialized]
    public bool UISeleccion2Active;

    public GameObject Seleccion1;
    public GameObject Seleccion2;
    private float secondsToStartGame;

    private void Start()
    {
        secondsToStartGame = UnityEngine.Random.Range(5f, 15f);
        UISeleccion2Active = false;
        StartCoroutine(StartGame());
    }

    private void Update()
    {
        if(startRound && UICountDown!=null)
        {
            UIWaiting.SetActive(false);
            UICountDown.SetActive(true);
        }
        if (timer.time <= 0f) {
            UIGame.SetActive(false);
            UIResults.SetActive(true);
            if(VariablesGlobales.SelectedApuesta == 0)
            {
                VariablesGlobales.SelectedApuesta = 10;
            }
        }
        if(UISeleccion2Active)
        {
            Seleccion1.SetActive(false);
            Seleccion2.SetActive(true);
        }
    }
    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(secondsToStartGame);
        startRound = true;
    }
}
