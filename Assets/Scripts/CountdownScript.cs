using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownScript : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public GameObject UIJuego;
    private float time;
    public GameManager gameManager;

    private void Start()
    {
        time = 3f;
    }

    // Update is called once per frame
    private void Update()
    {
        time -= Time.deltaTime;
        timer.text = Mathf.Round(time).ToString();
        if(time <= 0f)
        {
            UIJuego.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
