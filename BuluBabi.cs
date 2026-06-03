using UnityEngine;

public class BuluBabi : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Cek apakah yang nabrak itu Naruto
        player naruto = collision.gameObject.GetComponent<player>();

        if (naruto != null)
        {
            // Panggil fungsi respawn milik Naruto
            naruto.Respawn();
        }
    }
}