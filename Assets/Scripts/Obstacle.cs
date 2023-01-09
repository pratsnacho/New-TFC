using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Obstacle : MonoBehaviour {

    public PlayerMovement playerMovement;

	private void Start () 
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter (Collider other)
    {
        playerMovement.Die();
    }
}