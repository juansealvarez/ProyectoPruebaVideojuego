using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
    public List<string> textoTutorial;
    public TextMeshProUGUI Tutorial;
    private int contadorConvesacion = 0;
    private float time = 0f;
    public Animator panelAnimation;
    public GameObject resultado;
    public GameObject tutorial;
    public GameObject frameResult;
    public ControladorDatos controladorDatos;
    public GameObject Dark;
    public TextMeshProUGUI apuestas;
    public TextMeshProUGUI ganancias;
    public TextMeshProUGUI apuestaJugador;
    [System.NonSerialized]
    public bool hasSelectedOption;
    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject transparent;
    public GameObject dark2;
    public TextMeshProUGUI textoContinuar;

    private void Start()
    {
        Tutorial.text = textoTutorial[0];
        contadorConvesacion++;
        time = 1f;
    }
    private void Update()
    {
        if(contadorConvesacion!=4)
        {
            textoContinuar.text = "Haz click en cualquier lugar para continuar";
        }else if(contadorConvesacion==4 && !hasSelectedOption)
        {
            textoContinuar.text = "Selecciona una opción para continuar";
        }else
        {
            textoContinuar.text = "Haz click en cualquier lugar para continuar";
        }
        time -= Time.deltaTime;
        if(Input.anyKey && time <= 0f && contadorConvesacion < textoTutorial.Count)
        {
            if(contadorConvesacion==4 && hasSelectedOption)
            {
                Tutorial.text = textoTutorial[contadorConvesacion];
                contadorConvesacion++;
                time = 1f;
            }else if(contadorConvesacion!=4)
            {
                Tutorial.text = textoTutorial[contadorConvesacion];
                contadorConvesacion++;
                time = 1f;
            }
            
        }else if(Input.anyKey && time <= 0f)
        {
            SceneManager.LoadScene("PreLobby");
            VariablesGlobales.PrimeraVez = false;
            GuardarDatos();
        }
        if(contadorConvesacion==2)
        {
            panelAnimation.Play("1");
            arrow1.SetActive(true);
            Dark.SetActive(false);
        }else if (contadorConvesacion == 3)
        {
            arrow1.SetActive(false);
            arrow2.SetActive(true);
        }else if (contadorConvesacion == 4)
        {
            arrow2.SetActive(false);
            transparent.SetActive(false);
            dark2.SetActive(true);
            panelAnimation.Play("2");            
        }else if (contadorConvesacion == 7)
        {
            dark2.SetActive(false);
            resultado.SetActive(true);
            tutorial.SetActive(false);
            apuestaJugador.text = VariablesGlobales.SelectedApuesta.ToString();
            apuestas.text = (VariablesGlobales.SelectedApuesta+10).ToString();
            ganancias.text = (VariablesGlobales.SelectedApuesta-10).ToString();
            panelAnimation.Play("3");
        }else if (contadorConvesacion == 9)
        {
            Dark.SetActive(true);
            panelAnimation.Play("4");
            frameResult.SetActive(false);
        }
    }

    public void GuardarDatos()
    {
        string cadenaJSON;

        DatosUsers nuevosDatos = new DatosUsers()
        {
            Nombre = VariablesGlobales.Nombre,
            Apellido = VariablesGlobales.Apellido,
            Balance = VariablesGlobales.balance,
            Ganancias = VariablesGlobales.ganancias,
            PrimeraVez = VariablesGlobales.PrimeraVez,
        };
        cadenaJSON = JsonUtility.ToJson(nuevosDatos);
        
        
        
        File.WriteAllText(controladorDatos.ArchivoGuardado, cadenaJSON);
    }
}
