using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnApuestaTutorial : MonoBehaviour
{
    public TutorialManager tutorialManager;
    public TutorialScript tutorialScript;

    public void SelectedApuesta(int apuesta)
    {
        VariablesGlobales.SelectedApuesta = apuesta;
    }
    
    public void ChangeUI()
    {
        tutorialManager.UISeleccion2Active = true;
    }
    public void HasSelectedOption()
    {
        tutorialScript.hasSelectedOption = true;
    }
}
