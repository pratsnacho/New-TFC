using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private Score scoreText;
    public HealthBar healthBar;

    private void Start()
    {
        scoreText = GameObject.FindObjectOfType<Score>();
        healthBar = GameObject.FindObjectOfType<HealthBar>();
    }

    private void OnTriggerEnter(Collider other)
    {
        scoreText.AddScore(5);
        healthBar.AddHealth();
        Destroy(gameObject);

    }

    private void Update()
    {
        transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);
    }
}
