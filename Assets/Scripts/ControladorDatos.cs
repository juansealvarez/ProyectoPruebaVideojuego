using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ControladorDatos : MonoBehaviour
{
    public static ControladorDatos Instance { private set; get; }
    public TMP_InputField Nombre;
    public TMP_InputField Apellido;
    [System.NonSerialized]
    public DatosUsers datosUsers = new DatosUsers();
    [System.NonSerialized]
    public string ArchivoGuardado;
    [System.NonSerialized]
    public string nombre;
    [System.NonSerialized]
    public string apellido;
    [System.NonSerialized]
    public bool primeraVez;
   [System.NonSerialized]
    public int balance = 100;
   [System.NonSerialized]
    public int ganancias = 0;

    private void Awake()
    {
        Instance = this;
        ArchivoGuardado = Application.dataPath + "/datosUsers.json";
    }

    public void CargarDatos()
    {
        if(File.Exists(ArchivoGuardado))
        {
            string contenido = File.ReadAllText(ArchivoGuardado);
            datosUsers = JsonUtility.FromJson<DatosUsers>(contenido);
            nombre = datosUsers.Nombre;
            apellido = datosUsers.Apellido;
            primeraVez = datosUsers.PrimeraVez;
            VariablesGlobales.balance = datosUsers.Balance;
            VariablesGlobales.ganancias = datosUsers.Ganancias;
            VariablesGlobales.PrimeraVez = primeraVez;
        }else
        {
            Debug.Log("El archivo no existe");
        }
    }

    public void GuardarDatos()
    {
        DatosUsers nuevosDatos = new DatosUsers()
        {
            Nombre = Nombre.text,
            Apellido = Apellido.text,
            PrimeraVez = true,
            Balance = balance,
            Ganancias = ganancias
        };
        string cadenaJSON = JsonUtility.ToJson(nuevosDatos);
        File.WriteAllText(ArchivoGuardado, cadenaJSON);
    }
}
