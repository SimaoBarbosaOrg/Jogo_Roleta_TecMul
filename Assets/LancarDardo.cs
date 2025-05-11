using UnityEngine;

public class LancaDardo: MonoBehaviour
{
    public GameObject prefabDardo;
    public Transform pontoLancar;

    public float forca = 0f;
    public float forcaMaxima = 500f;
    public float acumulacaoPorSegundo = 300f;

    private bool preparando = false;
    private GameObject dardoAtual;
    private Rigidbody rbDardo;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PrepararNovoDardo();
        }

        if (Input.GetMouseButton(0) && preparando)
        {
            forca += acumulacaoPorSegundo * Time.deltaTime;
            if (forca > forcaMaxima)
                forca = forcaMaxima;
        }

        if (Input.GetMouseButtonUp(0) && preparando)
        {
            AtirarDardo();
        }
    }

    void PrepararNovoDardo()
    {
        dardoAtual = Instantiate(prefabDardo, pontoLancar.position, pontoLancar.rotation);
        rbDardo = dardoAtual.GetComponent<Rigidbody>();

        if (rbDardo != null)
        {
            rbDardo.isKinematic = true;
            preparando = true;
            forca = 0f;
        }
    }

    void AtirarDardo()
    {
        if (rbDardo == null) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 direcao = ray.direction;

        rbDardo.isKinematic = false;
        rbDardo.useGravity = true;
        rbDardo.AddForce(direcao.normalized * forca, ForceMode.Impulse);
        dardoAtual.transform.forward = direcao; // aponta o dardo

        preparando = false;
        forca = 0f;
    }
}
