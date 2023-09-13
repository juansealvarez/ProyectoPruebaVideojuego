using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [System.NonSerialized]
    public bool UISeleccion2Active;
    public GameObject seleccion1;
    public GameObject seleccion2;
    public TextMeshProUGUI ganancias;
    private void Start()
    {
        ganancias.text = VariablesGlobales.ganancias.ToString();
    }

    
    void Update()
    {
        if (UISeleccion2Active)
        {
            seleccion1.SetActive(false);
            seleccion2.SetActive(true);
        }
    }
}
