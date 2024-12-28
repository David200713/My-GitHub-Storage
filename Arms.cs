using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arms : MonoBehaviour
{
    public int isLeftOrRight;
    public float speed = 300f;
    public Camera cam;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 mousePos = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y, 0f);
        Vector3 diff = mousePos - transform.position;
        float rotationZ = Mathf.Atan2(diff.x, -diff.y) * Mathf.Rad2Deg;

        if(Input.GetMouseButton(isLeftOrRight))
        {
            rb.MoveRotation(Mathf.LerpAngle(rb.rotation, rotationZ, speed * Time.deltaTime));
        }
    }
}
