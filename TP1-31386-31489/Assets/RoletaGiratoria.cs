using UnityEngine;

public class RoletaGiratoria : MonoBehaviour
{
    public float velocidade = 100f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.forward, velocidade * Time.deltaTime);
    }
}
