using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text primero, segundo, tercero;

    void Start()
    {
        
    }

    void Update()
    {
        primero.text = "1� posici�n: \t" + PlayerPrefs.GetInt("prim", 0);
        segundo.text = "2� posici�n: \t" + PlayerPrefs.GetInt("secon", 0);
        tercero.text = "3� posici�n: \t" + PlayerPrefs.GetInt("tercer", 0);
    }
}
