using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaCollector : MonoBehaviour
{
    public float maxMetal;
    public float currMetal;
    public GameObject collectPlace,collectPlace2;
    public List<GameObject> metalList;
    // Start is called before the first frame update
    void Start()
    {
        currMetal = 0;
        metalList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
   
        if (other.gameObject.tag == "Metal")
        {
            if (currMetal < maxMetal)
            {

                currMetal++;
                metalList.Add(other.gameObject);
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                other.gameObject.GetComponent<MeshCollider>().enabled = false;
                //other.gameObject.SetActive(false);
                PlaceMetals();
                

            }

        }
    }
    public void PlaceMetals()
    {
        float counter = 0f;
        float counterCar1 = 0f;
        float counterCar2 = 0f;
        foreach (var metal in metalList)
        {
            if(collectPlace.name == "CollectPlaceCar")
            {
                if(collectPlace.transform.childCount < 5)
                {
                    metal.gameObject.transform.SetParent(collectPlace.gameObject.transform);
                    metal.gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                    metal.gameObject.transform.localPosition = new Vector3(0, 3.55f, 0); 
                    metal.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    metal.gameObject.transform.localPosition = new Vector3(metal.transform.localPosition.x, metal.transform.localPosition.y , metal.transform.localPosition.z + counterCar1);
                    counterCar1 = counterCar1 - 0.84f;
                }
                else
                {
                    metal.gameObject.transform.SetParent(collectPlace2.gameObject.transform);
                    metal.gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                    metal.gameObject.transform.localPosition = new Vector3(0, 3.55f, 0);
                    metal.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    metal.gameObject.transform.localPosition = new Vector3(metal.transform.localPosition.x, metal.transform.localPosition.y , metal.transform.localPosition.z + counterCar2);
                    counterCar2 = counterCar2 - 0.84f;
                }
            }
            else
            {
                metal.gameObject.transform.SetParent(collectPlace.gameObject.transform);
                metal.gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                metal.gameObject.transform.localPosition = Vector3.zero;
                metal.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
                metal.gameObject.transform.localPosition = new Vector3(metal.transform.localPosition.x, metal.transform.localPosition.y + counter, metal.transform.localPosition.z);
                counter = counter + 0.55f;
            }
           
        }
    }
  
}
