using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl_Script : MonoBehaviour
{

    public Rigidbody2D owlRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        owlRigidbody = GetComponent<Rigidbody2D>();
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z += Camera.main.nearClipPlane;
    }
    // Update is called once per frame
    void Update()
    {
        owlRigidbody.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
