// Exemplo simplificado de um DialogManager
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using TMPro;


public class DialogManager : MonoBehaviour
{
    public GameObject painelDialogo;
    public Image imagemFundo;
    public Image imagemPersonagem;
    public TextMeshProUGUI textoDialogo;
    public Button botaoAvancar;
    public float velocidadeDigitacao = 0.05f;

    private Queue<DialogoUnidade> filaDeDialogos = new Queue<DialogoUnidade>();
    private bool estaDigitando = false;
    private string textoAtual = "";
    void Start()
    {
        botaoAvancar.onClick.AddListener(ExibirProximoDialogo);
    }
    public void IniciarDialogo(DialogAsset dialogoAsset)
    {
        painelDialogo.SetActive(true);

        filaDeDialogos.Clear();
        foreach (DialogoUnidade unidade in dialogoAsset.dialogos)
        {
            filaDeDialogos.Enqueue(unidade);
        }

        // Inicia a exibição do primeiro diálogo
        ExibirProximoDialogo();
    }

    public void ExibirProximoDialogo()
    {

        if (estaDigitando)
        {
            StopAllCoroutines();
            textoDialogo.text = textoAtual;
            estaDigitando = false;
            botaoAvancar.GetComponentInChildren<TextMeshProUGUI>().text = "Proximo";
            return;
        }

        if (filaDeDialogos.Count == 0)
        {
            painelDialogo.SetActive(false);
            return;
        }

        DialogoUnidade unidade = filaDeDialogos.Dequeue();
        imagemFundo.sprite = unidade.imagemFundoTexto;
        imagemPersonagem.sprite = unidade.imagemPersonagem;

        StartCoroutine(DigitarTexto(unidade.texto));
    }

    private IEnumerator DigitarTexto(string textoCompleto)
    {
        textoAtual = textoCompleto;
        botaoAvancar.GetComponentInChildren<TextMeshProUGUI>().text = ">>";
        estaDigitando = true;
        textoDialogo.text = "";

        foreach (char letra in textoCompleto.ToCharArray())
        {
            textoDialogo.text += letra;
            yield return new WaitForSeconds(velocidadeDigitacao);
        }

        estaDigitando = false;
        botaoAvancar.GetComponentInChildren<TextMeshProUGUI>().text = "Proximo";
    }


}