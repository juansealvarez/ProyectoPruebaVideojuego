using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    public string Escena;
    public string EscenaTutorial;
    public ManagerEscena managerEscena;
    private string nombre;
    private string apellidos;
    public TextMeshProUGUI Usuario;
    public TextMeshProUGUI agenteNombre;

    private void Start()
    {
        ControladorDatos.Instance.CargarDatos();
        nombre = ControladorDatos.Instance.nombre;
        apellidos = ControladorDatos.Instance.apellido;
        Usuario.text = nombre + " " + apellidos;
        agenteNombre.text = nombre;
    }
    private void Update()
    {
        if (Input.anyKey)
        {
            if(VariablesGlobales.PrimeraVez)
            {
                managerEscena.ChangeScene(EscenaTutorial);
            }else
            {
                managerEscena.ChangeScene(Escena);
            }
            
        }
    }
}
