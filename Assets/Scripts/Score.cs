using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score, prim, secon, tercer;
    public Text scoreText;

    private void Start()
    {
        if(!PlayerPrefs.HasKey("prim"))
        {
            PlayerPrefs.SetInt("prim", 0);
        }
        prim = PlayerPrefs.GetInt("prim");

        if (!PlayerPrefs.HasKey("secon"))
        {
            PlayerPrefs.SetInt("secon", 0);
        }
        secon = PlayerPrefs.GetInt("secon");

        if (!PlayerPrefs.HasKey("tercer"))
        {
            PlayerPrefs.SetInt("tercer", 0);
        }
        tercer = PlayerPrefs.GetInt("tercer");
    }

    void Update()
    {
        scoreText.text = "Puntos: " + score.ToString();
    }

    public void AddScore(int score)
    {
        this.score += score;
    }

    public void SaveData()
    {
        int temp1, temp2;

        PlayerPrefs.SetInt("Puntos", score);

        if (score > prim)
        {
            temp1 = prim;
            prim = score;
            temp2 = secon;
            secon = temp1;
            tercer = temp2;
            PlayerPrefs.SetInt("prim", prim);
            PlayerPrefs.SetInt("secon", secon);
            PlayerPrefs.SetInt("tercer", tercer);

        } else if (score > secon) {
            temp1 = secon;
            secon = score;
            tercer = temp1;
            PlayerPrefs.SetInt("secon", secon);
            PlayerPrefs.SetInt("tercer", tercer);

        } else if (score > tercer) {
            tercer = score;
            PlayerPrefs.SetInt("tercer", tercer);
        }
    }

}
