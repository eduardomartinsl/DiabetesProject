using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogoManager : MonoBehaviour {
    
    /*Diálogos estágio estômago*/

    private string estomago0 = "Você sabia que o tratamento da diabetes pode ser feito de diversas maneiras?";
    private string estomago1 = "O principal método de tratamento da diabetes é cuidando da alimentação.";
    private string estomago2 = "É da alimentação que retiramos as nossas energias para pular, correr, brincar estudar, entre outras atividades do cotidiano.";
    private string estomago3 = "Mas nem todos os alimentos que comemos são saudáveis para o nosso corpo!!!";
    private string estomago4 = "Doces e frituras, por exemplo, possuem grandes quantidades de açúcar. E açúcar demais faz mal à saúde, especialmente, para as pessoas diabéticas.";
    private string estomago5 = "Então vamos combater os alimentos que nos deixam sem energia para brincar? Esses alimentos não podem ser levados para o nosso intestino (onde digerimos os alimentos).";
    private string estomago6 = "Neste primeiro estágio do jogo (Estômago) você deve combater os alimentos gordurosos. Atenção, esse tipo de alimento deve ser impedido de cair nos vagões do trem! Lembre-se: Frutas são bem vindas!";
    private string estomago7 = "Quando os alimentos chegam ao nosso estômago, começam a ser transformados em energia para brincar, andar, pensar, para o coração bater, o pulmão respirar... Então, sem energia nós não funcionamos. É como um carro sem combustível: não anda.";

    private string[] DialogosEstomago = new string[8];
    private int _DialogoAtual = 0;
    public GameObject PainelDeDialogos;     //fechar os diálogos ao iniciar o jogo, abrir painel
    public GameObject PainelDePontuacao;    //Fazer surgir ao finalizar os diálogos
    public Text TextoDeDialogos;
    public Button Avançar;
    public Button Retornar;
    
    void Start () {
        DialogosEstomago[0] = estomago0;
        DialogosEstomago[1] = estomago1;
        DialogosEstomago[2] = estomago2;
        DialogosEstomago[3] = estomago3;
        DialogosEstomago[4] = estomago4;
        DialogosEstomago[5] = estomago5;
        DialogosEstomago[6] = estomago6;
        DialogosEstomago[7] = estomago7;

        PainelDePontuacao.SetActive(false);
        Time.timeScale = 0;
        TextoDeDialogos.text = DialogosEstomago[0];
    }

    void Update () {
        if (_DialogoAtual == 0) {
            Retornar.gameObject.SetActive(false) ;
        }else {
            Retornar.gameObject.SetActive(true);
        }
    }

    public void AvancaDialogo() {
        _DialogoAtual++;
        DialogoShow();
    }
        
    public void RetornaDialogo() {
        _DialogoAtual--;
        DialogoShow();
    }

    public void DialogoShow() {
        if(_DialogoAtual == DialogosEstomago.Length) {
            PainelDeDialogos.SetActive(false);
            PainelDePontuacao.SetActive(true);
            Time.timeScale = 1;
        }
        TextoDeDialogos.text = DialogosEstomago[_DialogoAtual];
    }
}
