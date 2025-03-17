using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MarbleMove : MonoBehaviour
{
    public Line line;
    private Rigidbody rb;

    public Transform cilleLike;
    public Transform arrow;
    public Camera cam;

    public Slider slider;
    public Canvas canvas;
    private int side = 1;

    private int x = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GameObject.FindAnyObjectByType<Camera>();
        line = GameObject.FindAnyObjectByType<Line>();
        //rb.AddForce(new Vector3(0, 0, 20), ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        if(x == 0)
        {
            Vector3 mousePos = Input.mousePosition;

            Vector3 mouseWorldPos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, 0, cam.transform.position.y - cilleLike.transform.position.y));

            Vector3 direction = (mouseWorldPos - cilleLike.position).normalized;

            arrow.position = cilleLike.position - direction * 2;
            arrow.forward = -direction;
        }

        //Debug.Log(slider.value);
        if(x == 1)
        {
            slider.value += side * 300f * Time.deltaTime;
            if (slider.value >= 100 || slider.value <= 0)
            {
                side *= -1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && x == 1)
        {
            rb.AddForce(new Vector3( (cilleLike.position.x - arrow.position.x) * -20, 0, (cilleLike.position.z - arrow.position.z) * -slider.value/2), ForceMode.VelocityChange);
            slider.gameObject.SetActive(false);
            arrow.gameObject.SetActive(false);
            StartCoroutine(line.TakeMarble());
            x = 2;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && x == 0)
        {
            x = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && x == 1)
        {
            x = 0;
        }
        
    }
}
