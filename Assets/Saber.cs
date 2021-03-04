using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{
    public LayerMask layer;
    public GameObject slicedCubePrefab;

    private Vector3 previousPosition;

    void Update()
    {
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 1, layer))
        {
            var angle = Vector3.Angle(transform.position - previousPosition, hit.transform.up);
            if ( angle > 90)
            {
                GameObject cube = hit.transform.gameObject;
                
                Vector3 direction = (transform.position - cube.transform.position).normalized;
                var position = Quaternion.LookRotation(direction);
                var slicedCube = Instantiate(slicedCubePrefab, transform.position, position);
                Debug.Log($"Cube position: {cube.transform.position}, sliced cube position: {slicedCube.transform.position}, sliced cube size: {slicedCube.transform.localScale}");
                Destroy(cube, 0.0f);
                Destroy(slicedCube, 3f);
            }
        }

        previousPosition = transform.position;
    }
}
