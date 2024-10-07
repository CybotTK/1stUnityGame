using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResourceManager : MonoBehaviour
{

    public int wood;
    public int blood;
    public int crystal;

    public TMP_Text woodDisplay;
    public TMP_Text bloodDisplay;
    public TMP_Text crystalDisplay;

    public static ResourceManager instance;

    public int numberOfWorkersSacrificed;
    public TMP_Text sacrificedText;

    public int sacrificedGoal;

    private void Awake() //happens before the start function, the start of the game
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddResource(string resourceType, int amount)
    {

        if (resourceType == "wood")
        {
            wood += amount;
            woodDisplay.text = wood.ToString();
        }

        if (resourceType == "blood")
        {
            blood += amount;
            bloodDisplay.text = blood.ToString();
        }

        if (resourceType == "crystal")
        {
            crystal += amount;
            crystalDisplay.text = crystal.ToString();
        }

    }

    public void AddSacrificedWorkers()
    {
        numberOfWorkersSacrificed++;
        sacrificedText.text = numberOfWorkersSacrificed + "/" + sacrificedGoal;

        if (numberOfWorkersSacrificed >= sacrificedGoal)
        {
            print("Damn How do you feel sacrificing so many people");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
