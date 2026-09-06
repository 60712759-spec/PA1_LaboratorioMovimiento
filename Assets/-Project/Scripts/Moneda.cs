using UnityEngine;

public class Moneda : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que toca la moneda es el Jugador (Player)
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject); // Elimina la moneda de la escena
        }
    }
}

