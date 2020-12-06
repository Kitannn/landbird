using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawner : MonoBehaviour
{
    [SerializeField]
    public GameManager gameManager;

    public float maxTime = 1;
    private float timer = 0;
    public GameObject obstacle;
    public float position;
    public GameObject scriptObj;
    private MovePoints Script;
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
        Script = scriptObj.AddComponent<MovePoints>();
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
        //Debug.Log(timer);
    }

    public void PressStart()
    {
        //startButton.gameObject.SetActive(false);
        buttonPress = true;
    }
}
