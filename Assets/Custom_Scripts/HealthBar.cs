using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Image currentHealth;
    public Text ratio;

    private float hitpoint = 100f;
    private float maxHitpoint = 100f;


    private void Start()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float r = hitpoint / maxHitpoint;
        currentHealth.rectTransform.localScale = new Vector3(r, 1, 1);
        ratio.text = (r * 100).ToString("0") + '%';
    }

    public void TakeDamage(float damage)
    {
        hitpoint -= damage;
        if (hitpoint < 0)
        {
            hitpoint = 0;
            Debug.Log("Dead!");
            SceneManager.LoadScene("GameOver_Lose", LoadSceneMode.Single);
        }

        UpdateHealthBar();
    }

    public void HealthDamage(float heal)
    {
        hitpoint += heal;
        if (hitpoint > maxHitpoint)
        {
            hitpoint = maxHitpoint;
        }

        UpdateHealthBar();
    }
}
