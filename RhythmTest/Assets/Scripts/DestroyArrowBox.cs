using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArrowBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Arrow")
        {
            Destroy(other.gameObject);
            GameController.contoller.misses += 1;
        }
    }





}
