using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    [Header("Pergerakan Naruto")]
    public float KecepatanJalan = 10f;
    public float KekuatanLompat = 7f;
    private Rigidbody2D rb;

    // --- LOGIKA LOMPAT 2 KALI ---
    private int sisaLompatan = 2;
    public int BatasLompatanMax = 2;

    // --- LOGIKA BALIK BADAN ---
    private bool faceRight = true;

    [Header("Sistem Nyawa & Game Over")]
    public GameObject[] ObjekNyawa;
    private int sisaNyawa;
    public Button TombolUlangi;

    // Sistem Respawn & Jeda Kebal
    private Vector2 posisiAwal;
    public float jedaKebal = 1f;
    private float waktuBisaKenaDamage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sisaNyawa = ObjekNyawa.Length;
        posisiAwal = transform.position;
        sisaLompatan = BatasLompatanMax;

        if (TombolUlangi != null)
        {
            TombolUlangi.gameObject.SetActive(false);
            TombolUlangi.onClick.AddListener(UlangiGame);
        }
    }

    void Update()
    {
        // 1. Gerak Kanan-Kiri yang Sangat Responsif
        float inputX = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(inputX * KecepatanJalan, rb.linearVelocity.y);

        // --- FITUR BALIK BADAN ---
        if (inputX > 0 && !faceRight)
        {
            BalikBadan();
        }
        else if (inputX < 0 && faceRight)
        {
            BalikBadan();
        }

        // 2. Fitur Lompat 2 Kali
        if (Input.GetKeyDown(KeyCode.Space) && sisaLompatan > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, KekuatanLompat);
            sisaLompatan--;
        }
    }

    void BalikBadan()
    {
        faceRight = !faceRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    // --- RESET JATAH LOMPAT PAS MENYENTUH BASE LANTAI/PIPA ---
    private void OnCollisionEnter2D(Collision2D collision)
    {
        sisaLompatan = BatasLompatanMax;

        // --- DETEKSI BULU BABI OVERPOWER (Anti-Gagal) ---
        // Mengecek Tag, Nama Huruf Besar, Huruf Kecil, atau Script BuluBabi yang menempel
        string namaObjek = collision.gameObject.name.ToLower();
        bool adaScriptBuluBabi = collision.gameObject.GetComponent("BuluBabi") != null;

        if (collision.gameObject.CompareTag("BuluBabi") ||
            namaObjek.Contains("bulu") ||
            namaObjek.Contains("babi") ||
            adaScriptBuluBabi)
        {
            Respawn();
        }
    }

    // --- FUNGSI RESPAWN ---
    public void Respawn()
    {
        if (Time.time >= waktuBisaKenaDamage)
        {
            if (sisaNyawa > 0)
            {
                sisaNyawa--;
                ObjekNyawa[sisaNyawa].SetActive(false);

                if (sisaNyawa <= 0)
                {
                    ProsesGameOver();
                }
                else
                {
                    // Balik ke posisi awal tiang pipa
                    transform.position = posisiAwal;
                    rb.linearVelocity = Vector2.zero;
                    waktuBisaKenaDamage = Time.time + jedaKebal;
                }
            }
        }
    }

    void ProsesGameOver()
    {
        if (TombolUlangi != null)
        {
            TombolUlangi.gameObject.SetActive(true);
        }
        gameObject.SetActive(false);
    }

    void UlangiGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}