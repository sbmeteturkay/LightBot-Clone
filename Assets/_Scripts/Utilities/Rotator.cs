using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
    bool dragging = false;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ResetDrag();
        }
    }

    private void ResetDrag()
    {
        dragging = false;
        rb.angularVelocity = Vector3.zero;
    }

    private void OnMouseDrag()
    {
        dragging = true;
    }
    private void FixedUpdate()
    {
        if (!dragging)
            return;
        float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime;
        rb.AddTorque(Vector3.right*x);
    }
    private void OnDisable()
    {
        ResetDrag();
    }
}
