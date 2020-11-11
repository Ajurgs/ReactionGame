using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFall : MonoBehaviour
{
    public float dropSpeed = 10;

    private void FixedUpdate()
    {

        transform.Translate(Vector3.down * dropSpeed*Time.deltaTime);
    }
}
