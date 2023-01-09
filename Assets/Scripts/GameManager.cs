using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public static GameManager inst;
    public Score score;
    int tiempo;

    [SerializeField] PlayerMovement playerMovement;

    private void Awake ()
    {
        inst = this;
    }

	private void Update () {
	}

}