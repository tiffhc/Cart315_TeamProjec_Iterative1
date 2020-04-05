﻿using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Image currentHealth;
    public Image LowHealth;
    public Text ratio;
    //public GameObject red;


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
        LowHealth.rectTransform.localScale = new Vector3(r, 1, 1);
        ratio.text = (r * 100).ToString("0") + '%';
    }

    public void TakeDamage(float damage)
    {
        if (hitpoint < 20)
        {
            LowHealth.SetActive(true);
        }

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
