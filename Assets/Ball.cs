using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] Collider col;
    [SerializeField] float WaitTime = 1f;
    Vector3 DefaultPos;

    private void Start()
    {
        DefaultPos = transform.position;
    }

    private void OnDisable()
    {
        transform.position = DefaultPos;
        meshRenderer.enabled = true;
        col.enabled = true;
    }

    public void Off()
    {
        meshRenderer.enabled = false;
        col.enabled = false;
        StartCoroutine(On());
    }
    IEnumerator On()
    {
        transform.position = GameManager.Instance.FindPos();
        yield return new WaitForSeconds(WaitTime);
        meshRenderer.enabled = true;
        col.enabled = true;
    }
}
