using UnityEngine;
using UnityEngine.SceneManagement; // Wajib untuk pindah level

public class FinishPoint : MonoBehaviour
{
    // Fungsi ini mendeteksi kalau Naruto menyentuh kerang
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Cek apakah yang menabrak memiliki script player (Naruto)
        player naruto = collision.gameObject.GetComponent<player>();

        if (naruto != null)
        {
            Debug.Log("Naruto Menang! Level Selesai!");

            // Pindah otomatis ke level berikutnya berdasarkan nomor urut di Build Settings
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            // Cek apakah level berikutnya ada di Build Settings
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                Debug.Log("Hebat! Kamu sudah tamat semua level!");
            }
        }
    }
}