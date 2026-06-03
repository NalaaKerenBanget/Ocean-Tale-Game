using UnityEngine;

public class KoinBergerak : MonoBehaviour
{
    [Header("Pengaturan Gerakan")]
    public float kecepatanGerak = 3f;   // Seberapa cepat gelembung naik turun
    public float tinggiLompatan = 0.2f;  // Jarak melayangnya (naik-turunnya)

    private Vector3 posisiAwal;

    void Start()
    {
        // 1. Catat posisi awal koin pas game baru mulai biar dia gak kabur ke mana-mana
        posisiAwal = transform.position;
    }

    void Update()
    {
        // 2. Rumus matematika Sinus biar gelembungnya naik turun halus otomatis
        float posisiYBaru = Mathf.Sin(Time.time * kecepatanGerak) * tinggiLompatan;

        // 3. Masukkan posisi baru ke koin gelembung
        transform.position = posisiAwal + new Vector3(0, posisiYBaru, 0);
    }
}