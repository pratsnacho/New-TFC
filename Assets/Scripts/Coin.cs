using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Coin : MonoBehaviour {

    private Score scoreText;

    private void Start()
    {
        scoreText = GameObject.FindObjectOfType<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        scoreText.AddScore(50);
        Destroy(gameObject);

    }

    private void Update()
    {
        transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);
    }
}