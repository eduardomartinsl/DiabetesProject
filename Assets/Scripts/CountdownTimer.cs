using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {

    public float tempoRestante = 40f;

    private Text TextoRestante;
    //public GameObject PanelTimer;

	// Use this for initialization
	void Start () {
        //PanelTimer = GameObject.Find("PanelContador");
        TextoRestante = gameObject.GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        tempoRestante -= Time.deltaTime;
        TextoRestante.text = tempoRestante.ToString("n2");
        if (tempoRestante < 0)
        {
            Time.timeScale = 0;
        }
	}
}
