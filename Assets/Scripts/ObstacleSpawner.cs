using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float maxTime = 5;
    private float timer = 0;
    public GameObject obstacle;
    public float position;
    private bool buttonPress = false;
    // Start is called before the first frame update
    private IEnumerator Start()
    {
        this.enabled = false;
        while (!Input.GetButton("Jump"))
        {
            yield return null;
        }

        this.enabled = true;
        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.position = transform.position + new Vector3(Random.Range(-position, position), 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            GameObject newObstacle = Instantiate(obstacle);
            newObstacle.SetActive(true);
            newObstacle.transform.position = transform.position + new Vector3(Random.Range(-position, position), 0, 0);
            Destroy(newObstacle, 5);
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    public void PressStart()
    {
        //startButton.gameObject.SetActive(false);
        buttonPress = true;
    }
}
