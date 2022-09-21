using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnWallEnter : MonoBehaviour
{
    [SerializeField] private Object _fogEffect;

    public Color DefaultColor;
    public Color EndColor;
    public Vector3 MinScale;
    public Vector3 MaxScale;
    public float Speed = 2f;
    public float Duration = 1f;
    
    private void Start()
    {
        MinScale = transform.localScale;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("Wall"))
        {
            var hitPlane = Instantiate(_fogEffect, collision.contacts[0].point, Quaternion.LookRotation(collision.contacts[0].normal));
            Destroy(hitPlane, 1f);

            StartCoroutine(ChangSize(MinScale, MaxScale, Duration));
            StartCoroutine(ChangSize(MaxScale, MinScale, Duration));
            StartCoroutine(ChangeColorToDefault(Duration));
        }
    }

    public IEnumerator ChangSize(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * Speed;
        while(i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(a, b, i);
            GetComponent<Renderer>().material.color = Color.Lerp(DefaultColor, EndColor, i);
            
            yield return null;
        }
    }

    public IEnumerator ChangeColorToDefault(float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * Speed;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            
            GetComponent<Renderer>().material.color = Color.Lerp(EndColor, DefaultColor, i);
            
            yield return null;
        }
    }
}
