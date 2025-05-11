using UnityEngine;
using UnityEngine.UI;

public class SetorPontuacao : MonoBehaviour
{
    public static int pontuacao = 0;
    public int adicao;
    public GameObject texto;
    public Text pontuacaoTexto; // Referência ao texto da UI


    void Start()
    {
        AtualizarTexto();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("dagger"))
        {
            pontuacao += adicao;

            Debug.Log($"Acertou o setor com a dagger! Adicionou: {adicao}, Total: {pontuacao}");

            AtualizarTexto();

            if (pontuacao >= 100)
            {
                texto.SetActive(true);
            }
        }
    }

    void AtualizarTexto()
    {
        pontuacaoTexto.text = "Pontuação: " + pontuacao;
    }
}