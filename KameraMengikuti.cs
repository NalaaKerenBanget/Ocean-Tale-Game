using UnityEngine;

public class KameraMengikuti : MonoBehaviour
{
    public Transform targetKarakter; // Kolom buat masukin Naruto
    public float jarakKeBelakang = -10f; // Jarak kamera biar ga nempel muka karakter

    void LateUpdate()
    {
        if (targetKarakter != null)
        {
            // Mengikuti posisi X dan Y Naruto, tapi posisi Z (jarak kamera) tetap di -10
            transform.position = new Vector3(targetKarakter.position.x, targetKarakter.position.y, jarakKeBelakang);
        }
    }
}