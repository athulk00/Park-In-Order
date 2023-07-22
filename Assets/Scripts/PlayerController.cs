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
    private bool played;

    [System.Obsolete]
    public void Start()
    {
        animate = GetComponent<SplineAnimate>();
        played = false;
    }
 
    public void Update()
    {
        
        if(played == true)
        {
            if (currentTime < duration)
            {
                currentTime += animate.NormalizedTime * Time.deltaTime;
                float t = Mathf.Clamp01(currentTime / duration);
                rend.material.color = Color.Lerp(Color.white, Color.black, t);
            }

        }




    }
    public void OnMouseDown()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && animate.NormalizedTime <= 0)
        {
            animate.Play();
            StartCoroutine(SetPlayed());
            animate.Loop = SplineAnimate.LoopMode.Once;
            
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && animate.NormalizedTime > 0)
        {
            animate.NormalizedTime = 0;
            rend.material.color = Color.white;
            played = false;
            currentTime = 0f;
        }
    }

    IEnumerator SetPlayed()
    {
        played = true;
        if (animate.NormalizedTime >= 2f)
            yield return null;
    }

    
}
