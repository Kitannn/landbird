using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{


    public bool isGameActive;

    public float maxTime = 1;
    private float timer = 0;
    public GameObject Ground9;
    public GameObject Ground8;
    public GameObject Ground7;
    public GameObject Ground6;
    public GameObject Ground5;
    public GameObject Ground4;
    public GameObject Ground3;
    public GameObject Ground2;
    public GameObject Ground1;

    public int groundType = 0;

    public float position;
    public bool buttonPress = false;
    // Start is called before the first frame update
    private IEnumerator Start()
    {
        this.enabled = false;
        while (!Input.GetButton("Jump") || !buttonPress)
        {
            Debug.Log("gtest ");
            yield return null;
        }
        Debug.Log("post test");
        this.enabled = true;

        GameObject newGround9 = Instantiate(Ground9);
        GameObject newGround8 = Instantiate(Ground8);
        GameObject newGround7 = Instantiate(Ground7);
        GameObject newGround6 = Instantiate(Ground6);
        GameObject newGround5 = Instantiate(Ground5);
        GameObject newGround4 = Instantiate(Ground4);
        GameObject newGround3 = Instantiate(Ground3);
        GameObject newGround2 = Instantiate(Ground2);
        GameObject newGround1 = Instantiate(Ground1);

        newGround9.transform.position = transform.position + new Vector3(Random.Range(-position, position), 0, 0);
        newGround8.transform.position = transform.position + new Vector3(Random.Range(-position, position), 0, 0);
        newGround7.transform.position = transform.position + new Vector3(Random.Range(-position, position), 0, 0);
        newGround6.transform.position = transform.position + new Vector3(Random.Range(-position, position), 0, 0);
        newGround5.transform.position = transform.position + new Vector3(Random.Range(-position, position), 0, 0);
        newGround4.transform.position = transform.position + new Vector3(Random.Range(-position, position), 0, 0);
        newGround3.transform.position = transform.position + new Vector3(Random.Range(-position, position), 0, 0);
        newGround2.transform.position = transform.position + new Vector3(Random.Range(-position, position), 0, 0);
        newGround1.transform.position = transform.position + new Vector3(Random.Range(-position, position), 0, 0);
    }
    
    // Update is called once per frame
    void Update()
    {
        GameObject newGround;
        if (timer > maxTime)
        {
            float randomNum = Random.Range(1.0f, 9.0f);
            groundType = (int)randomNum; 
            switch (groundType)
            {
                case 9:
                    newGround = Instantiate(Ground9);
                    newGround.SetActive(true);
                    newGround.transform.position = transform.position + new Vector3(Random.Range(-position, position), 0, 0);
                    Destroy(newGround, 5);
                    timer = 0;
                    break;

                case 8:
                    newGround = Instantiate(Ground8);
                    newGround.SetActive(true);
                    newGround.transform.position = transform.position + new Vector3(Random.Range(-position, position), 0, 0);
                    Destroy(newGround, 5);
                    timer = 0;
                    break;

                case 7:
                    newGround = Instantiate(Ground7);
                    newGround.SetActive(true);
                    newGround.transform.position = transform.position + new Vector3(Random.Range(-position, position), 0, 0);
                    Destroy(newGround, 5);
                    timer = 0;
                    break;

                case 6:
                    newGround = Instantiate(Ground6);
                    newGround.SetActive(true);
                    newGround.transform.position = transform.position + new Vector3(Random.Range(-position, position), 0, 0);
                    Destroy(newGround, 5);
                    timer = 0;
                    break;

                case 5:
                    newGround = Instantiate(Ground5);
                    newGround.SetActive(true);
                    newGround.transform.position = transform.position + new Vector3(Random.Range(-position, position), 0, 0);
                    Destroy(newGround, 5);
                    timer = 0;
                    break;

                case 4:
                    newGround = Instantiate(Ground4);
                    newGround.SetActive(true);
                    newGround.transform.position = transform.position + new Vector3(Random.Range(-position, position), 0, 0);
                    Destroy(newGround, 5);
                    timer = 0;
                    break;

                case 3:
                    newGround = Instantiate(Ground3);
                    newGround.SetActive(true);
                    newGround.transform.position = transform.position + new Vector3(Random.Range(-position, position), 0, 0);
                    Destroy(newGround, 5);
                    timer = 0;
                    break;

                case 2:
                    newGround = Instantiate(Ground2);
                    newGround.SetActive(true);
                    newGround.transform.position = transform.position + new Vector3(Random.Range(-position, position), 0, 0);
                    Destroy(newGround, 5);
                    timer = 0;
                    break;

                default:
                    newGround = Instantiate(Ground1);
                    newGround.SetActive(true);
                    newGround.transform.position = transform.position + new Vector3(Random.Range(-position, position), 0, 0);
                    Destroy(newGround, 5);
                    timer = 0;
                    break;
            }
        }

        timer += Time.deltaTime;
    }

    public void PressStart()
    {
        //startButton.gameObject.SetActive(false);
        Debug.Log("button pressed");
        buttonPress = true;
    }
}
