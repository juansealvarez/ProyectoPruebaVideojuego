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
    public DatosUsers datosUsers = new DatosUsers();
    public string ArchivoGuardado;
    [System.NonSerialized]
    public string nombre;
    [System.NonSerialized]
    public string apellido;

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
            Debug.Log("Hola " + nombre + " " + apellido);
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
            Apellido = Apellido.text
        };
        string cadenaJSON = JsonUtility.ToJson(nuevosDatos);
        File.WriteAllText(ArchivoGuardado, cadenaJSON);
        Debug.Log("Archivo guardado");
    }
}
