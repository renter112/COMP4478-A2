using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    GameObject spawner;
    GameObject player;
    float timer = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("heroShip");
        spawner = GameObject.Find("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, 0, 0.1f);
        timer -= Time.deltaTime;
        if (timer < 0)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        spawner.GetComponent<Spawner>().currentShips -= 1;
        Destroy(other.gameObject);
        Destroy(this.gameObject);
        player.GetComponent<PlayerShip>().score += 1;
        
    }
}
