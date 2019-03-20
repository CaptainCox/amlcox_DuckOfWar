using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitator : MonoBehaviour
{
    //adjust this to change speed
    float speed = 1f;
    //adjust this to change how high it goes
    float height = 1.0f;

    float xPosition;
    float zPosition;

    // Start is called before the first frame update
    void Start()
    {
        xPosition = transform.position.x;
        zPosition = transform.position.z;
    }
    void Update()
    {
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed);
        newY += 2f;
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(xPosition, newY * height, zPosition);
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}