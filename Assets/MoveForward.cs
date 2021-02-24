using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var old = transform.position;
        //transform.position -= Time.deltaTime * transform.position * 2;
        transform.position -= new Vector3(0, 0, Time.deltaTime * transform.position.z * 2);
        Debug.Log($"old: {old}, new: {transform.position}, deltaTime: {Time.deltaTime}");
        if (transform.position.z <= 0.1f)
        {
            Debug.Log($"Cube position is zero, cube is destroyed");
            Destroy(gameObject);
        }
    }
}
