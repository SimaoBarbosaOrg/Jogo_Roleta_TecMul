using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{
    public GameObject Instrucoes;

    public void MudarCena()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void MostrarInstrucoes()
    {
        Instrucoes.SetActive(true);
    }
}
