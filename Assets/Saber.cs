using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{
    public LayerMask layer;
    private Vector3 previousPosition;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 1, layer))
        {
            //if (Vector3.Angle(transform.position - previousPosition, hit.transform.up) > 90)
            {
                Debug.Log($"Saber hit object {hit}");
                GameObject cube = hit.transform.gameObject;
                var rigidBody = cube.GetComponent<Rigidbody>();
                if(rigidBody)
                {
                    rigidBody.AddExplosionForce(10.0f, cube.transform.position, 5.0f, 1.0f, ForceMode.Impulse);
                }

                Destroy(cube, 1.0f);
            }
        }

        previousPosition = transform.position;
    }
}
