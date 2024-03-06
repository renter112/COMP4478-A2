using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    float shotTimer;
    bool shoot = true;
    GameObject player;
    GameObject spawner;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        shotTimer = Random.Range(0.0f, 1.0f);
        player = GameObject.Find("heroShip");
        spawner = GameObject.Find("Spawner");
        int temp = Random.Range(0, 100);
        if (temp > 30)
            shoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(shoot)
            shotTimer -= Time.deltaTime;
        
        this.transform.position -= new Vector3(0, 0, 0.3f);

        if (this.transform.position.z < player.transform.position.z)
        {
            spawner.GetComponent<Spawner>().currentShips -= 1;
            Destroy(this.gameObject);
        }
        if(shotTimer < 0 && shoot)
        {
            Instantiate(bullet, this.transform.position - new Vector3(0, 0, 2f), Quaternion.identity);
            shoot = false;
        }
    }
}
