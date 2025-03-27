using UnityEngine;
using TMPro;

public class PlayerDeath : MonoBehaviour
{
    public int vidas = 3;
    public TextMeshProUGUI livesText;

    void Start()
    {
        UpdateLivesUI();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            vidas--;
            UpdateLivesUI();
            
            if (vidas <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = " " + vidas;
        }
    }
}
