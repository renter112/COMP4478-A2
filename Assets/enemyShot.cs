using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShot : MonoBehaviour
{
    float timer = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position -= new Vector3(0, 0, 0.5f);
        timer -= Time.deltaTime;
        if (timer < 0)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log(other.name);


    }
}
