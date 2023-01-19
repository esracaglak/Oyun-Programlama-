using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PayToOpen : MonoBehaviour
{
    public float totalMetalPrice;
    private float currentMetal;
    public float katSayi;
    public TextMeshProUGUI currentMetalText, popUp;
    public GameObject Bar, Car, Train;
    bool isClick;
    MetalCreator metalCreator;
    public GameObject unlock_train;
    // Start is called before the first frame update
    void Start()
    {
        metalCreator = GameObject.Find("MetalCreator").GetComponent<MetalCreator>();
        isClick = false;
        currentMetal = 0;
        currentMetalText.text = totalMetalPrice.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "MetalCollector" )
        {
            popUp.enabled = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isClick = true;
                MetaCollector metaCollector = other.gameObject.GetComponent<MetaCollector>();
                float givenMetal = metaCollector.currMetal;

                if (currentMetal < totalMetalPrice)
                {
                    currentMetal += givenMetal;
                    if(currentMetal >totalMetalPrice)
                    {
                        currentMetal = totalMetalPrice;
                    }
                    Bar.transform.localScale = new Vector3(((currentMetal / totalMetalPrice)) * katSayi, Bar.transform.localScale.y, Bar.transform.localScale.z);
                    currentMetalText.text = (totalMetalPrice - currentMetal).ToString();
                    metaCollector.currMetal = 0;
                    foreach (var metal in metaCollector.metalList)
                    {
                        metal.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    }

                }
            }
            if(currentMetal >= totalMetalPrice)
            {
                FinishPrice(other);
                if(gameObject.name == "Collider_Car")
                {
                    Car.gameObject.SetActive(true);
                    gameObject.transform.parent.gameObject.SetActive(false);

                }
                else if(gameObject.name == "Collider_Train")
                {
                    Train.gameObject.SetActive(true);
                    gameObject.transform.parent.gameObject.SetActive(false);
                }

            }
               
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MetalCollector" )
        {
            popUp.enabled = false;
            if (isClick)
            {
                Debug.Log("sea");
                MetaCollector metaCollector = other.gameObject.GetComponent<MetaCollector>();
                List<GameObject> metals = new List<GameObject>();
                if (metaCollector.metalList.Count != 0)
                {
                    metals.AddRange(metaCollector.metalList);
                    metaCollector.metalList.RemoveRange(0, metaCollector.metalList.Count);
                    foreach (var metal in metals)
                    {
                        Debug.Log("silme");
                        if (metalCreator.metals.Contains(metal))
                        {
                            metalCreator.metals.Remove(metal);

                        }
                        Destroy(metal);
                    }
                }
                isClick = false;
            }
        }
           
    }

    public void FinishPrice(Collider other) {
        Debug.Log("sea");
        MetaCollector metaCollector = other.gameObject.GetComponent<MetaCollector>();
        List<GameObject> metals = new List<GameObject>();
        if (metaCollector.metalList.Count != 0)
        {
            metals.AddRange(metaCollector.metalList);
            metaCollector.metalList.RemoveRange(0, metaCollector.metalList.Count);
            foreach (var metal in metals)
            {
                Debug.Log("silme");
                Destroy(metal);
            }
            if(gameObject.name == "Collider_Car")
            {
                Debug.Log("train açýldý");
                unlock_train.SetActive(true);
            }
            currentMetal = 0;
        }
    }

}
