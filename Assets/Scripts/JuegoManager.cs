using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JuegoManager : MonoBehaviour
{
    private string nombre;
    private string apellidos;
    private int ganancias;
    public TextMeshProUGUI Usuario;
    public TextMeshProUGUI agenteNombre;
    public TextMeshProUGUI Ganancias;
    public GameManager gameManager;
    private int randomNombre;
    private int randomApellido;
    private string nombreAdversario;
    private string apellidoAdversario;
    public TextMeshProUGUI Adversario;
    public TextMeshProUGUI AdversarioNombre;
    public TextMeshProUGUI agenteAdversario;
    [System.NonSerialized]
    public int adversarioGanancias;
    public TextMeshProUGUI AdversarioGananciasTexto;

    private void Start()
    {
        nombre = VariablesGlobales.Nombre;
        apellidos = VariablesGlobales.Apellido;
        ganancias = VariablesGlobales.Ganancias;
        Usuario.text = nombre + " " + apellidos;
        agenteNombre.text = nombre;
        Ganancias.text = ganancias.ToString();
        randomNombre = Random.Range(0,gameManager.Nombre.Count);
        randomApellido = Random.Range(0,gameManager.Apellido.Count);
        nombreAdversario = gameManager.Nombre[randomNombre];
        apellidoAdversario = gameManager.Apellido[randomApellido];
        Adversario.text = nombreAdversario + " " + apellidoAdversario;
        AdversarioNombre.text = nombreAdversario + " " + apellidoAdversario;
        agenteAdversario.text = nombreAdversario;
        adversarioGanancias = Random.Range(100, 100000);
        AdversarioGananciasTexto.text = adversarioGanancias.ToString();
    }
}
