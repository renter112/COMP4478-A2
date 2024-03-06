using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerShip : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject leftbound;
    GameObject rightbound;
    public GameObject bonusL;
    public GameObject bonusR;

    public Text healthText;
    public Text scoreText;
    public Text bonusText;
    
    public GameObject bullet;
    GameObject spawner;
    GameObject tspawner;

    public int health = 5;
    public int score = 0;
    bool triShot = false;
    public float triTime = 0.0f;
    public float fireRate = 1f;
    private float nextFireTime = 0f;
    bool flipped = false;

    void Start()
    {
        leftbound = GameObject.Find("lbound");
        rightbound = GameObject.Find("rbound");
        spawner = GameObject.Find("Spawner");
        tspawner = GameObject.Find("TerrainSpawner");

        bonusL.SetActive(false);
        bonusR.SetActive(false);
        healthText.text = "Health: " + health;
        scoreText.text = "Score: 0";
        bonusText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
        if (triTime > 0f)
        {
            triTime -= Time.deltaTime;
        }
        else if(triTime <= 0f)
        {
            bonusL.SetActive(false);
            bonusR.SetActive(false);
            triShot = false;
            bonusText.text = "";
            triTime = 0;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //move left
            if (this.transform.position.x > leftbound.transform.position.x)
            {
                this.transform.position -= new Vector3(0.05f, 0f, 0f);
                if(flipped)
                    this.transform.position -= new Vector3(0.05f, 0f, 0f);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //move right
            if (this.transform.position.x < rightbound.transform.position.x)
            {
                this.transform.position += new Vector3(0.05f, 0f, 0f);
                if (flipped)
                    this.transform.position += new Vector3(0.05f, 0f, 0f);
            }
        }

        if (Input.GetKey(KeyCode.O) && Time.time >= nextFireTime && !flipped)
        {
    
            Instantiate(bullet, this.transform.position + new Vector3(0, 0, 5f), Quaternion.identity);
            if(triShot)
            {
                Instantiate(bullet, this.transform.position + new Vector3(2.5f, 0, 3f), Quaternion.identity);
                Instantiate(bullet, this.transform.position + new Vector3(-2.5f, 0, 3f), Quaternion.identity);
            }
            nextFireTime= Time.time + fireRate;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (flipped)
            {
                this.transform.eulerAngles = new Vector3(0, 0, 0);
                flipped = false;
            }
            else if (!flipped)
            {
                this.transform.eulerAngles = new Vector3(0, 0, 90);
                flipped = true;
            }

        }
        if(health < 1 )
        {
            // end game
            Time.timeScale = 0;
            spawner.GetComponent<Spawner>().StopGame();
            gameObject.SetActive(false);
            bonusText.text = "GAME OVER";
            Application.Quit();

        }
        if(score % 50 == 0 && score!=0)
        {
            GiveUpgrade();
        }
        scoreText.text = "Score: " + score;
    }
    private void GiveUpgrade()
    {
        bonusL.SetActive(true);
        bonusR.SetActive(true);
        bonusText.text = "BONUS ACTIVE";
        triShot = true;
        triTime = 2f;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        health--;
        healthText.text = "Health: " + health;
    }
}
