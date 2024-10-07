using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    public float speed;

    public float minX, maxX, minY, maxY;

    Vector3 currentTarget;

    public GameObject blood;
    public GameObject bloodEffect;

    Animator camAnim;



    // Start is called before the first frame update
    void Start()
    {
        camAnim = Camera.main.GetComponent<Animator>();

        currentTarget = GetRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, currentTarget) > 0.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }
        else
        {
            currentTarget = GetRandomPosition();
        }
        
    }

    Vector3 GetRandomPosition() 
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        return randomPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision) //when it collides with a gameObject it stores it in the
                                                        //collision variable 
    {
        if (collision.tag == "Altar")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // it restarts from this scene
        }
        else if (collision.tag == "Trap")
        {
            Instantiate(bloodEffect, transform.position, Quaternion.identity);
            camAnim.SetTrigger("shake");
            
            Destroy(collision.gameObject);
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (collision.tag == "Human")
        {
            Worker worker = collision.GetComponent<Worker>();

            if (worker != null) //&& worker.IsWorkerHeld() == false) //if i want to make it so that the worker can be held
                                //with the mouse and not die
            {
                Instantiate(worker.deathSound);
                camAnim.SetTrigger("shake");
                Instantiate(blood, collision.transform.position, Quaternion.identity);
                Instantiate(bloodEffect, collision.transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
            }
        }
    }


}
