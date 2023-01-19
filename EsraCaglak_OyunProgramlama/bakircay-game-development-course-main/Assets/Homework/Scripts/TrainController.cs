using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    public Transform[] targets;
    public float speed;

    private int current;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != targets[current].position)
        {
           transform.position = Vector3.MoveTowards(transform.position, targets[current].position, speed * Time.deltaTime);
           gameObject.transform.LookAt(targets[current].transform);
        }
        else
        {
            current = (current + 1) % targets.Length;
        }
    }
}
