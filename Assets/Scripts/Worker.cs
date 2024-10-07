using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class Worker : MonoBehaviour
{

    bool isSelected;

    public LayerMask resourceLayer;
    public float collectDistance;
    Resources currentResource;

    public float timeBetweenCollect;
    float nextCollectTime;
    public int collectAmount;

    GameObject bloodAltar;

    public float distanceToAltar;

    public GameObject resourcePopUp;

    private AudioSource source;
    public GameObject deathSound;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        bloodAltar = GameObject.FindGameObjectWithTag("Altar");
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected == true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            transform.position = mousePos;
        } 
        else
        {

            if (Vector3.Distance(transform.position, bloodAltar.transform.position) <= distanceToAltar)
            {
                Instantiate(deathSound);
                ResourceManager.instance.AddSacrificedWorkers();
                Destroy(gameObject);
            }


            Collider2D col = Physics2D.OverlapCircle(transform.position, collectDistance, resourceLayer);
            if (col != null && currentResource == null)
            {
                currentResource = col.GetComponent<Resources>();
            }
            else
            {
                currentResource = null;
            }


            if (currentResource != null)
            {
                if (Time.time > nextCollectTime)
                {
                    Instantiate(resourcePopUp, transform.position, Quaternion.identity);
                    nextCollectTime = Time.time + timeBetweenCollect;
                    currentResource.resourceAmount -= collectAmount;
                    ResourceManager.instance.AddResource(currentResource.resourceType, collectAmount);
                }
            }
        }
            
    }

    public bool IsWorkerHeld()
    {
        return isSelected;
    }

    private void OnMouseDown()
    {
        source.Play();
        isSelected = true;
    }

    private void OnMouseUp()
    {
        isSelected = false;
    }

}
