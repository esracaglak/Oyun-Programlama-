using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Station : MonoBehaviour
{
    public float currentMetalCount;
    [SerializeField] TextMeshProUGUI totalMetalCountText;
    MetalCreator metalCreator;
    // Start is called before the first frame update
    void Start()
    {
        metalCreator = GameObject.Find("MetalCreator").GetComponent<MetalCreator>();
    }

    // Update is called once per frame
    void Update()
    {
        totalMetalCountText.text = currentMetalCount.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Train")
        {
            Debug.Log("station");
            List<GameObject> temp = new List<GameObject>();
            currentMetalCount+=  other.gameObject.GetComponent<TrainMetalCollect>().currentMetalCount;
            other.gameObject.GetComponent<TrainMetalCollect>().currentMetalCount = 0;
            temp.AddRange(other.gameObject.GetComponent<TrainMetalCollect>().metals);
            metalCreator.metals.RemoveRange(0, metalCreator.metals.Count);
            other.gameObject.GetComponent<TrainMetalCollect>().metals.RemoveRange(0, other.gameObject.GetComponent<TrainMetalCollect>().metals.Count);

            foreach (var metal in temp)
            {
                Destroy(metal);
            }
        }
    }
}
