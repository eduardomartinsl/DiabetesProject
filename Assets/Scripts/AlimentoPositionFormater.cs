using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AlimentoPositionFormater : MonoBehaviour {
	
	public GameObject Alimento1;
	public GameObject Alimento2;
	public GameObject Alimento3;
	public GameObject Alimento4;

    public Vector3 tubo1;
    public Vector3 tubo2;
    public Vector3 tubo3;
    public Vector3 tubo4;

	private GameObject[] alimentos = new GameObject[4];

	public int tuboSelecionado = 0;

	public int contadorDeErros = 0;
    private int MargemDeErro = 4;
    public Text PainelDePontuacao;

    public GameObject tentarDeNovo;
	void Start () {
        
        tentarDeNovo.SetActive(false);
        tubo1 = new Vector3(-513.0702f, 50f, -0.7910366f);
        tubo2 = new Vector3(-491.9096f, 50f, -0.7910366f);
        tubo3 = new Vector3(-471.1787f, 50f, -0.7910366f);
        tubo4 = new Vector3(-450.5551f, 50f, -0.7910366f);
        alimentos [0] = Alimento1;
		alimentos [1] = Alimento2;
		alimentos [2] = Alimento3;
		alimentos [3] = Alimento4;

		StartCoroutine(GameObject.Find("Plane1").GetComponent<AlimentoPositionFormater>().FormataTubo(GameObject.Find("Plane1").GetComponent<AlimentoPositionFormater>().tubo1, "1"));
		StartCoroutine(GameObject.Find("Plane1").GetComponent<AlimentoPositionFormater>().FormataTubo(GameObject.Find("Plane1").GetComponent<AlimentoPositionFormater>().tubo2, "2"));
		StartCoroutine(GameObject.Find("Plane1").GetComponent<AlimentoPositionFormater>().FormataTubo(GameObject.Find("Plane1").GetComponent<AlimentoPositionFormater>().tubo3, "3"));
		StartCoroutine(GameObject.Find("Plane1").GetComponent<AlimentoPositionFormater>().FormataTubo(GameObject.Find("Plane1").GetComponent<AlimentoPositionFormater>().tubo4, "4"));

	}

	void Update(){
    }

    public void OnCollisionEnter(Collision Other) {
        if (Other.gameObject.tag == "Saudavel") {
            Debug.Log("Parabéns! " + Other.gameObject.name + " Pode entrar no trem!");
        } else if (Other.gameObject.tag == "NaoSaudavel") {
            Debug.Log("Cuidado! " + Other.gameObject.name + " Tem muito açúcar!");
            GameObject.Find("Plane1").GetComponent<AlimentoPositionFormater>().contadorDeErros++;
            AplicaPenalidade();
        }
        Destroy(Other.gameObject);
        NovaPosicaoDeSpawn();
    }

    private void AplicaPenalidade() {
        if (GameObject.Find("Plane1").GetComponent<AlimentoPositionFormater>().contadorDeErros <= MargemDeErro) {
            PainelDePontuacao.text = "Erros: " + GameObject.Find("Plane1").GetComponent<AlimentoPositionFormater>().contadorDeErros;
        } else if (GameObject.Find("Plane1").GetComponent<AlimentoPositionFormater>().contadorDeErros > 2) {
            Time.timeScale = 0;
            PainelDePontuacao.text = "FIM DE JOGO";
            GameObject.Find("Plane1").GetComponent<AlimentoPositionFormater>().tentarDeNovo.SetActive(true);
        }
    }

    public void NovaPosicaoDeSpawn (){
		if (this.gameObject.name.Contains ("1")) {
			StartCoroutine (GameObject.Find("Plane1").GetComponent<AlimentoPositionFormater>().FormataTubo (GameObject.Find("Plane1").GetComponent<AlimentoPositionFormater>().tubo1, "1"));
		}
		if (this.gameObject.name.Contains ("2")) {
			StartCoroutine (GameObject.Find("Plane1").GetComponent<AlimentoPositionFormater>().FormataTubo (GameObject.Find("Plane1").GetComponent<AlimentoPositionFormater>().tubo2, "2"));
		}
		if (this.gameObject.name.Contains ("3")) {
			StartCoroutine (GameObject.Find("Plane1").GetComponent<AlimentoPositionFormater>().FormataTubo (GameObject.Find("Plane1").GetComponent<AlimentoPositionFormater>().tubo3, "3"));
		}
		if (this.gameObject.name.Contains ("4")) {
			StartCoroutine (GameObject.Find("Plane1").GetComponent<AlimentoPositionFormater>().FormataTubo (GameObject.Find("Plane1").GetComponent<AlimentoPositionFormater>().tubo4, "4"));
		}
	}
    public IEnumerator FormataTubo(Vector3 tuboSelecionado, string posicao){
		yield return new WaitForSeconds (Random.Range(0, 2));
		GameObject newalimento = (GameObject) Instantiate (GameObject.Find("Plane1").GetComponent<AlimentoPositionFormater>().alimentos[ Random.Range (0, alimentos.Length)], tuboSelecionado, Quaternion.Euler(-30, 0, 0));
		newalimento.transform.name = newalimento.transform.name + posicao;
	}

    public void ReiniciaEstagio() {
        contadorDeErros = 0;
        Time.timeScale = 1;
        PainelDePontuacao.text = "Erros: 0";
        GameObject.Find("Plane1").GetComponent<AlimentoPositionFormater>().tentarDeNovo.SetActive(false);
    }
}