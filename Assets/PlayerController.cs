using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] MeshRenderer ren;
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed = 5f;
    [SerializeField] List<Color> color;
    Vector3 input;
    Vector3 DefaultPos;
    void Start()
    {
        DefaultPos = transform.position;
        ChangeColor();
    }

    private void OnDisable()
    {
        transform.position = DefaultPos;
    }
    private void OnEnable()
    {
        ChangeColor();
    }

    private void ChangeColor()
    {
        int i = Random.Range(0, color.Count);
        ren.material.color = color[i];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Respawn"))
        {
            if (collision.gameObject.GetComponent<MeshRenderer>().material.color.Equals(ren.material.color))
            {
                collision.gameObject.GetComponent<Ball>().Off();
                ChangeColor();
                GameManager.Instance.AddPoints();
            }
            else
            {
                //gameObject.SetActive(false);
                GameManager.Instance.Loss();
            }
        }
    }

    void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.MovePosition(transform.position + input.normalized * speed * Time.deltaTime);
    }
}
