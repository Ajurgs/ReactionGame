using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneController : MonoBehaviour
{

    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject toSpwan;
    [SerializeField] ArrowBoxController arrowBox;
    public bool arrowInBox = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (arrowBox.arrowInBox)
        {
            arrowInBox = true;
        }
        else
        {
            arrowInBox = false;
        }
    }

    public void CheckBox()
    {
        if (arrowInBox)
        {
            if (arrowBox.objInBox != null)
            {
                DistanceToArrow(arrowBox.objInBox);
                Destroy(arrowBox.objInBox);
            }
        }
        else
        {
            Debug.Log(name + "  miss");
            GameController.contoller.misses += 1;
        }
    }

    public void DistanceToArrow(GameObject arrow)
    {
        float distance = Vector3.Distance(arrow.transform.position, arrowBox.transform.position);
        Debug.Log(name +" : "+distance);
        if (distance < .1)
        {
            Debug.Log(name + " perfect");
            GameController.contoller.score += 100;
        }
        else if(distance >=.1 && distance< .25)
        {
            Debug.Log(name + " Excelent");
            GameController.contoller.score += 75;
        }
        else if (distance >= .25 && distance < .75)
        {
            Debug.Log(name + " Good");
            GameController.contoller.score += 50;
        }
        else if(distance < 1 && distance >= .75)
        {
            Debug.Log(name + " Bad");
            GameController.contoller.score += 25;
        }
        else if (distance >= 1)
        {
            Debug.Log(name + "  miss");
            GameController.contoller.misses += 1;
        }
    }
    public void SpawnArrow()
    {
       GameObject spawned =  Instantiate(toSpwan, spawnPoint);
        spawned.GetComponent<ArrowFall>().dropSpeed = GameController.contoller.arrowSpeed;
    }
}
