using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBoxController : MonoBehaviour
{
    public bool arrowInBox;
    public GameObject objInBox;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Arrow")
        {
            arrowInBox = true;
            objInBox = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Arrow")
        {
            arrowInBox = false;
        }    
    }
}
