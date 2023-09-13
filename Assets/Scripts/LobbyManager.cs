using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    private string nombre;
    private string apellidos;
    private int balance;
    private int ganancias;
    public TextMeshProUGUI Usuario;
    public TextMeshProUGUI agenteNombre;
    public TextMeshProUGUI Balance;
    public TextMeshProUGUI Ganancias;
    public TextMeshProUGUI Partidas;
    public int PartidasMaximas;

    private void Start()
    {
        ControladorDatos.Instance.CargarDatos();
        nombre = ControladorDatos.Instance.nombre;
        apellidos = ControladorDatos.Instance.apellido;
        balance = VariablesGlobales.balance;
        ganancias = ControladorDatos.Instance.ganancias;
        Usuario.text = nombre + " " + apellidos;
        agenteNombre.text = nombre;
        Balance.text = balance.ToString();
        Ganancias.text = ganancias.ToString();
        Partidas.text = VariablesGlobales.ContPartidas.ToString() + "/" + PartidasMaximas.ToString();
        VariablesGlobales.Nombre = nombre;
        VariablesGlobales.Apellido = apellidos;
        VariablesGlobales.Ganancias = ganancias;
    }
    private void Update()
    {
        if(VariablesGlobales.ContPartidas==PartidasMaximas)
        {
            Debug.Log("Error del sistema, se habilita opcion de ganar instantaneamente");
        }
    }
}
