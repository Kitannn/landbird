using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    //Animator thisAnim;
    public float speed = 3;
    private bool buttonPress = false;
    // Start is called before the first frame update
    private IEnumerator Start()
    {
        this.enabled = false;
        while (!Input.GetButton("Jump") || !buttonPress)
        {
            yield return null;
        }

        this.enabled = true;
        //thisAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        //Debug.DrawRay(transform.position, Vector2.left);
    }

    public void PressStart()
    {
        //startButton.gameObject.SetActive(false);
        buttonPress = true;
    }
}
