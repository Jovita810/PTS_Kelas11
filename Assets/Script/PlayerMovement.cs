using UnityEngine;
using UnityEngine.InputSystem;   // WAJIB untuk Input System

public class PlayerMovement : MonoBehaviour
{
    public float kecepatan = 5f;
    public int skor = 0;

    private Vector2 arahGerak;   // nilai dari action "Move"

    // Dipanggil OTOMATIS oleh komponen Player Input
    // saat action "Move" pada asset InputSystem_Actions aktif.
    // Nama method WAJIB: On + nama action -> OnMove
    void OnMove(InputValue value)
    {
        // TODO: ambil nilai Vector2 dari input, simpan ke arahGerak
        arahGerak = value.Get<Vector2>();
    }

    void Update()
    {
        // TODO: gerakkan objek memakai arahGerak.
        // Ingat kalikan kecepatan DAN Time.deltaTime!
        Vector3 arah = new Vector3(arahGerak.x, arahGerak.y, 0);
        transform.position += arah * kecepatan * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other) 
    { 
    // TODO: cek apakah yang disentuh punya tag "Coin" 
        if ( other.CompareTag("Coin") ) 
        { 
        // TODO: hancurkan koin yang tersentuh 
            Destroy(other.gameObject); 
            skor += 1;
            Debug.Log(skor);

            FindFirstObjectByType<GameManager>().AmbilKoin();
        } 
    }
}