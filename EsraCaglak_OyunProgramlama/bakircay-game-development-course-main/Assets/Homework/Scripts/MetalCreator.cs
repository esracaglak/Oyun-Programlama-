using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalCreator : MonoBehaviour
{
    public Vector3 positions;
    public float creationTime;
    public float maxCreationTime;
    public GameObject metal;
    public List<GameObject> metals;
    // Start is called before the first frame update
    void Start()
    {
        metals = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        creationTime -= Time.deltaTime;
        if(creationTime  <= 0)
        {
            if(metals.Count <= 100)
            {
                positions = new Vector3(Random.Range(-95.3f, 307.6f), positions.y, Random.Range(-314.3f, 99.5f));
                GameObject clone = Instantiate(metal, positions, Quaternion.identity);
                creationTime = maxCreationTime;
                metals.Add(clone);
            }
        }
    }
}
