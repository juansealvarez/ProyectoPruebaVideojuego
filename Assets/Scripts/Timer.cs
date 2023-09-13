using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time = 30f;
    public TextMeshProUGUI timer;
    public List<int> ApuestaAdversario;
    public List<int> Premio;
    private int randomPremio;
    private int randomApuestaAversario;
    private void Start()
    {
        randomApuestaAversario = Random.Range(0,ApuestaAdversario.Count);
        randomPremio = Random.Range(0,Premio.Count);
        VariablesGlobales.ApuestaAdversario = ApuestaAdversario[randomApuestaAversario];
        VariablesGlobales.Premio = Premio[randomPremio];
    }

    private void Update()
    {
        time -= Time.deltaTime;
        timer.text = Mathf.Round(time).ToString();
    }
}
