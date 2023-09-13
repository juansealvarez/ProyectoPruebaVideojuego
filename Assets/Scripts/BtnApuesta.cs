using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnApuesta : MonoBehaviour
{
    public GameManager gameManager;

    public void SelectedApuesta(int apuesta)
    {
        VariablesGlobales.SelectedApuesta = apuesta;
    }
    
    public void ChangeUI()
    {
        gameManager.UISeleccion2Active = true;
    }
}
