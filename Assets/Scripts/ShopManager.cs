using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public Ghost worker;
    public Ghost village;
    public Ghost crystal;
    public Ghost tree;
    public Ghost trap;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnShopClick(string whatItem)
    {
        if (whatItem == "worker")
        {
            Instantiate(worker);
        }

        if (whatItem == "village")
        {
            Instantiate(village);
        }

        if (whatItem == "tree")
        {
            Instantiate(tree);
        }

        if (whatItem == "crystal")
        {
            Instantiate(crystal);
        }

        if (whatItem == "trap")
        {
            Instantiate(trap);
        }
    }
}
