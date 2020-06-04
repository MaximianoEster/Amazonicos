using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camSet2 : MonoBehaviour
{
    private bool onShake = false;
    public Transform target;
    public float smothSpeed = 0.125f;
    public Vector3 offset;
    
    void FixedUpdate() {
        Vector3 pos = target.position + offset;
        Vector3 smoothpos = Vector3.Lerp(transform.position, pos, smothSpeed);
        transform.position = smoothpos;
    }

    public IEnumerator Shake (float duracao, float forcaShake){
        Vector3 originalPos = transform.localPosition;

        float tempo = 0.0f;

        while (tempo < duracao)
        {
            float x = (Random.Range(-1f, 1f) * forcaShake);
            float y = (Random.Range(-1f, 1f) * forcaShake);
            //float z = Random.Range(-1f, 1f) * forcaShake;

            transform.localPosition = new Vector3(x + target.position.x, y + target.position.y, originalPos.z);

            tempo += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}