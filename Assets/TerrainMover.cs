using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TerrainMover : MonoBehaviour
{
    GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("TerrainSpawner");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position -= new Vector3(0, 0, 0.4f);
        // if it was properly 1000 after there would be a tiny space between them, now over lapping but that seems better 
        if (this.transform.position.z <= -1010)
        {
            Destroy(this.gameObject);
            spawner.GetComponent<TerrainSpawner>().tileN -= 1;
        }
    }
}
