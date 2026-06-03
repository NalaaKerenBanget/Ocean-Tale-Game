using UnityEngine;

public class Koin : MonoBehaviour
{
    // Fungsi bawaan Unity yang otomatis jalan kalau mendeteksi tabrakan Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Cek apakah yang menyentuh koin adalah si Player (Naruto)
        // Kita cek lewat nama script "player" yang nempel di Naruto
        if (collision.GetComponent<player>() != null)
        {
            // Hilangkan objek koin dari game
            Destroy(gameObject);
        }
    }
}