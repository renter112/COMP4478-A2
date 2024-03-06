using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyship;
    GameObject lbound;
    GameObject rbound;


    public bool done = false;
    public int startingShips = 10;
    public int currentShips = 0;

    // Start is called before the first frame update
    void Start()
    {
        lbound = GameObject.Find("lbound");
        rbound = GameObject.Find("rbound");

        for (int i = 0; i < startingShips; ++i)
        {
            currentShips++;
            Instantiate(enemyship, new Vector3(Random.Range(lbound.transform.position.x, rbound.transform.position.x), 0, Random.Range(200, 350)), Quaternion.identity);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentShips < 10 && !done)
        {
            Instantiate(enemyship, new Vector3(Random.Range(lbound.transform.position.x, rbound.transform.position.x), 0, Random.Range(200, 350)), Quaternion.identity);
            currentShips++;
        }
    }

    public void StopGame()
    {
        done = true;
    }
}
