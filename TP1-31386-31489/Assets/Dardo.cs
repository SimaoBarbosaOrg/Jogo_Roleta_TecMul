using UnityEngine;

public class Dardo : MonoBehaviour
{
    private bool colado = false;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("M�todo de colis�o foi chamado!");
        Debug.Log("Colidiu com: " + other.gameObject.name);

        if (colado) return;

        if (other.CompareTag("Setor"))
        {
            Debug.Log("Colidiu com setor!");

            // Define a posi��o do dardo no ponto de contato
            transform.position = other.ClosestPointOnBounds(transform.position);
            transform.SetParent(other.transform);

            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Zera a velocidade antes de marcar o Rigidbody como Kinematic
                rb.linearVelocity = Vector3.zero; // Para o movimento do dardo
                rb.angularVelocity = Vector3.zero; // Para a rota��o do dardo

                // Marca o Rigidbody como Kinematic
                rb.isKinematic = true;

                // Desativa a gravidade
                rb.useGravity = false;
            }

            // Desabilita o Collider do dardo
            Collider col = GetComponent<Collider>();
            if (col != null)
                col.enabled = false;

            GameObject objetoAtingido = other.gameObject;

            Renderer renderer = objetoAtingido.GetComponentInChildren<Renderer>();

            if (renderer == null) return;

            Color cor = renderer.material.color;

            Debug.Log(cor);

            int pontos = 0;

            if (cor == Color.red)
            {
                pontos += 10;
            }

            colado = true;
        }
    }
}