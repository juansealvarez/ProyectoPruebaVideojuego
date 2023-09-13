using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ResultScript : MonoBehaviour
{
    public TextMeshProUGUI Apuesta;
    public TextMeshProUGUI Adversario;
    public TextMeshProUGUI Premio;
    public TextMeshProUGUI Balance;
    public TextMeshProUGUI Resultado;
    public TextMeshProUGUI Apuestas;
    private bool ganador;
    public ControladorDatos controladorDatos;
    private int balance;
    public ManagerEscena managerEscena;

    public string Escena;

    private void Start()
    {
        Apuesta.text = VariablesGlobales.SelectedApuesta.ToString();
        Adversario.text = VariablesGlobales.ApuestaAdversario.ToString();
        Premio.text = VariablesGlobales.Premio.ToString();
        balance = VariablesGlobales.SelectedApuesta - VariablesGlobales.ApuestaAdversario;
        Balance.text = balance.ToString();
        Apuestas.text = (VariablesGlobales.SelectedApuesta + VariablesGlobales.ApuestaAdversario).ToString();
        if(VariablesGlobales.SelectedApuesta > VariablesGlobales.ApuestaAdversario)
        {
            ganador = true;
        }else if(VariablesGlobales.SelectedApuesta < VariablesGlobales.ApuestaAdversario)
        {
            ganador = false;
        }else
        {
            int random = Random.Range(0,2);
            if(random == 0)
            {
                ganador = true;
            }else
            {
                ganador = false;
            }
        }
        if(ganador)
        {
            Resultado.text = "GANADOR";
        }else
        {
            Resultado.text = "PERDEDOR";
        }

        GuardarDatos();
        VariablesGlobales.ContPartidas++;
    }
    private void Update()
    {
        if (Input.anyKey)
        {
            managerEscena.ChangeScene(Escena);
        }
    }

    public void GuardarDatos()
    {
        string cadenaJSON;
        if(ganador)
        {
            DatosUsers nuevosDatos = new DatosUsers()
            {
                Nombre = VariablesGlobales.Nombre,
                Apellido = VariablesGlobales.Apellido,
                Balance = VariablesGlobales.balance + balance,
                Ganancias = VariablesGlobales.ganancias + VariablesGlobales.Premio,
            };
            cadenaJSON = JsonUtility.ToJson(nuevosDatos);
        }else
        {
            DatosUsers nuevosDatos = new DatosUsers()
            {
                Nombre = VariablesGlobales.Nombre,
                Apellido = VariablesGlobales.Apellido,
                Balance = VariablesGlobales.balance + balance,
            };
            cadenaJSON = JsonUtility.ToJson(nuevosDatos);
        }
        
        
        File.WriteAllText(controladorDatos.ArchivoGuardado, cadenaJSON);
    }
}
