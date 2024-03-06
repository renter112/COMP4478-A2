using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TerrainSpawner : MonoBehaviour
{
    public GameObject tile;
    public int tileN = 2;


    // Start is called before the first frame update
    void Start()
    {
            Instantiate(tile, new Vector3(-492,-4,-20),Quaternion.identity);
            Instantiate(tile, new Vector3(-492, -4, 980), Quaternion.identity);
        //f1 = GameObject.Find("Terrain");
        //GameObject newFloor = Instantiate(f1);
        //f1.transform.position = new Vector3(-111f, -1.3f, 200f);


    }

    // Update is called once per frame
    void Update()
    {
        if(tileN < 2)
        {
            Instantiate(tile, new Vector3(-492, -4, 980), Quaternion.identity);
            tileN++;
        }
    }
  
}
