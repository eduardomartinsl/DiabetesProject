using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

/*
 * Estomago:    1 
 * Intestino:   2
 * Pancreas:    3
 */

public class MenuController : MonoBehaviour {
	

	private GameObject MenuPrincipal;
	private GameObject SeletorDeFases;
    private GameObject PanelOrgaos;

    private GameObject PanelDescricaoEstagio;
    private Text descricaoDeEstagio;

    private Image OrgaoSelecionado;
    private Image TituloDeEstagioSelecionado;

    private int verificaEstagioSelecionado = 1;

	private FadeOutScript AplicadorDeFade;

    public Image[] OrgaosDestacados = new Image[3];
    public Image[] TitulosDeEstagios = new Image[3];

    public Image aaa;
    public Sprite aaaa; //halp
    
    /*
    * Nos vetores de imagens:
    * 
    * Estudar a inserção das imagens por meio da importação na pasta Resource
    * 
    * Estomago:    0 
    * Intestino:   1
    * Pancreas:    2
    */

    public void Start(){
		MenuPrincipal = GameObject.Find ("MenuPrincipal");
		SeletorDeFases = GameObject.Find("SeletorDeFases");
        PanelOrgaos = GameObject.Find("PanelEscolhaDeFases");
        PanelDescricaoEstagio = GameObject.Find("PanelDescricaoEstagio");

        OrgaoSelecionado = GameObject.Find("ImageCorpoHumano").GetComponent<Image>();
        TituloDeEstagioSelecionado = GameObject.Find("ImageCorpoHumano").GetComponent<Image>();

        descricaoDeEstagio = GameObject.Find("DescricaoDeEstagioText").GetComponent<Text>();

        AplicadorDeFade = GameObject.Find ("Canvas").GetComponent<FadeOutScript> ();
		SeletorDeFases.SetActive (false);
	}

    public void Update() {
        //adicionar o clique das telas nos numeros 7, 8, 9 e 0.
    }

    public void IniciarSelecaoDeEstagio() {
        MenuPrincipal.SetActive(false);
        SeletorDeFases.SetActive(true);
        PanelOrgaos.SetActive(true);
        PanelDescricaoEstagio.SetActive(false);
    }
    
    public void SeletorDeEstagio(){ //buttons não funcionam com ienumerator!!!
		StartCoroutine (AplicaFade ());
	}	

	public void SairDoJogo(){
		Application.Quit ();
	}

    public void SelecionaEstagioEstomago() {
        verificaEstagioSelecionado = 1;
        DescricaoEstagioFormatter();
    }

    public void SelecionaEstagioIntestino() {
        verificaEstagioSelecionado = 2;
        DescricaoEstagioFormatter();
    }

    public void SelecionaEstagioPancreas() {
        verificaEstagioSelecionado = 3;
        DescricaoEstagioFormatter();
    }

    public void DescricaoEstagioFormatter() {
        PanelOrgaos.SetActive(false);
        PanelDescricaoEstagio.SetActive(true);
        if (verificaEstagioSelecionado == 1) {
            //selecionado estomago
            descricaoDeEstagio.text = "nesta primeira fase do jogo, você deve combater os alimentos gordurosos. ATENÇÃO: Os alimentos com muito açúcar devem ser evitados de cair nos vagóes do trêm. LEMBRE-SE: frutas são bem vindas!";
            TituloDeEstagioSelecionado = TitulosDeEstagios[0];
            OrgaoSelecionado = OrgaosDestacados[0];
        } else if (verificaEstagioSelecionado == 2) {
            //selecionado intestino
            //em dev
        } else if (verificaEstagioSelecionado == 3) {
            //selecionado pancreas
            //em dev
        }
    }

    public IEnumerator AplicaFade() {
        float fadeTime = AplicadorDeFade.BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(verificaEstagioSelecionado, LoadSceneMode.Single);
    }
}
