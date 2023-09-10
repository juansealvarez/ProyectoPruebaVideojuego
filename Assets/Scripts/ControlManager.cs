using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    public string Escena;
    public ManagerEscena managerEscena;
    private string nombre;
    private string apellidos;
    public TextMeshProUGUI Usuario;

    private void Start()
    {
        ControladorDatos.Instance.CargarDatos();
        nombre = ControladorDatos.Instance.nombre;
        apellidos = ControladorDatos.Instance.apellido;
        Usuario.text = nombre + " " + apellidos;
    }
    private void Update()
    {
        if (Input.anyKey)
        {
            managerEscena.ChangeScene(Escena);
        }
    }
}
