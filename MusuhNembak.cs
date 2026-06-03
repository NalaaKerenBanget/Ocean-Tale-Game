using UnityEngine;

public class MusuhNembak : MonoBehaviour
{
    public GameObject peluruMusuhPrefab;
    public Transform tempatNembakMusuh;
    public float kecepatanPeluru = -10f; // Minus artinya melesat ke kiri (ke arah Naruto)
    public float jedaNembak = 2f;       // Nembak otomatis setiap 2 detik
    private float waktuNembak;

    void Update()
    {
        if (Time.time >= waktuNembak)
        {
            Nembak();
            waktuNembak = Time.time + jedaNembak;
        }
    }

    void Nembak()
    {
        GameObject peluru = Instantiate(peluruMusuhPrefab, tempatNembakMusuh.position, Quaternion.identity);
        Rigidbody2D rb = peluru.GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(kecepatanPeluru, 0f);
        Destroy(peluru, 3f);
    }

    // Kalau Spongebob kena peluru Naruto, Spongebob langsung mati/hancur
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PeluruNaruto"))
        {
            Destroy(collision.gameObject); // Hancurkan pelurunya
            Destroy(gameObject);           // Spongebob mati
        }
    }
}