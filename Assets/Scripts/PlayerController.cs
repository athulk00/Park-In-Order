using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class PlayerController : MonoBehaviour
{
    private SplineAnimate animate;
    public SplineExtrude extrude;
    public Renderer rend;
    public float duration = 1f;
    public float currentTime = 0f;
    public bool played;
    public bool isSend = false;
    public ParticleSystem particle;
    public GameObject gameOverUI;
    [Header("GameEvent")]
    public GameEvent onReachedDestination;

    [System.Obsolete]
    public void Start()
    {
        animate = GetComponent<SplineAnimate>();
        played = false;
    }
 
    public void Update()
    {
        if (currentTime < duration)
        {
            currentTime += animate.NormalizedTime * Time.deltaTime;
            float t = Mathf.Clamp01(currentTime / duration);
            rend.material.color = Color.Lerp(Color.white, Color.black, t);
        }
      
    }
    public void OnMouseDown()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentTime <= 0)
        {
            animate.Play();
            StartCoroutine(SetPlayed());
            animate.Loop = SplineAnimate.LoopMode.Once;
            

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentTime >= 2)
        {
            animate.NormalizedTime = 0;
            rend.material.color = Color.white;
            played = false;
            currentTime = 0f;
            onReachedDestination.Raise(this, -1);

        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            animate.Pause();
            particle.Play();
            StartCoroutine(DisplayUI());
        }
        
    }

    IEnumerator SetPlayed()
    {
        yield return new WaitForSeconds(duration);
        played = true;
        onReachedDestination.Raise(this, 1);
        isSend = true;

    }
    IEnumerator DisplayUI()
    {
        yield return new WaitForSeconds(2f);
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        
    }

    
}
