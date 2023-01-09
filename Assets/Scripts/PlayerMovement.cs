using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour 
{

    float Horizontal;
    public float Forward;
    public float MaxLeft, MaxRight;

    public Transform Pivot;

    public AnimationCurve slideCurve;
    private bool Sliding = false;
    public float SlideDuration = 1f;
    public float SlideUpDownDuration = 1f;
    public float Slide = -90f;

    public AnimationCurve jumpCurve;
    private bool Jumping = false;
    public float Jump = 7f;
    public float JumpDuration = 1f;
    public float Speed;

    float yOrigin;
    float yOffset;
    float xRotation;

    internal Transform tr;
    internal Animator anim;

    GameManager gameManager;
    Score score;
    bool alive = true;

    void Awake()
    {
        tr = transform;
        anim = GetComponentInChildren<Animator>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        score = GameObject.FindObjectOfType<Score>();
        yOrigin = tr.position.y;
        Forward = tr.position.z;

    }

    void Update()
    {
        if(alive)
        {
            Horizontal += Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
            Forward += Speed * Time.deltaTime;

            if (!Jumping && !Sliding && Input.GetButtonDown("Jump"))
                StartCoroutine(fly());

            if (!Jumping && !Sliding && Input.GetButtonDown("Fire1"))
                StartCoroutine(slide());

            Horizontal = Mathf.Clamp(Horizontal, MaxLeft, MaxRight);

            tr.position = new Vector3(Horizontal, yOrigin + yOffset, Forward);
            Pivot.rotation = Quaternion.Euler(xRotation, 0, 0);
            
            if(Speed < 20)
                Speed += 0.01f * Time.deltaTime;
        }

    }

    public IEnumerator fly()
    {
        Jumping = true;
        anim.CrossFade("Jump", .1f);
        float d = 0;
        while (d < JumpDuration)
        {
            d += Time.deltaTime;
            yOffset = jumpCurve.Evaluate(d / JumpDuration) * Jump;

            yield return null;

        }
        anim.CrossFade("Run", .1f);
        Jumping = false;

    }

    public IEnumerator slide()
    {
        Sliding = true;
        float d = 0;
        anim.CrossFade("Slide", .1f);
        while (d < SlideUpDownDuration)
        {
            d += Time.deltaTime;
            xRotation = slideCurve.Evaluate(d / SlideDuration) * Slide;
            yield return null;

        }

        yield return new WaitForSeconds(SlideDuration);

        while (d > 0)
        {
            d -= Time.deltaTime;
            xRotation = slideCurve.Evaluate(d / SlideDuration) * Slide;
            yield return null;

        }
        Sliding = false;

    }

    public void Die()
    {
        alive = false;
        score.SaveData();
        Invoke("CargarPuntuacion", 0.7f);
    }

    public void CargarPuntuacion()
    {
        SceneManager.LoadScene("Puntuaciones");

    }
}