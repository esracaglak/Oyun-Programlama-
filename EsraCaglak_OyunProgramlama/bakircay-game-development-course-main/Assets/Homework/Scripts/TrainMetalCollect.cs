using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMetalCollect : MonoBehaviour
{
    public int maxMetalCount;
    public int currentMetalCount;
    public List<GameObject> metals;

    // Start is called before the first frame update
    void Start()
    {
        metals = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Metal")
        {
            if (currentMetalCount < maxMetalCount)
            {
                metals.Add(other.gameObject);
                currentMetalCount++;
                other.gameObject.SetActive(false);
            }

        }

       
    }
}
