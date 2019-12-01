using UnityEngine;
using System.Collections;

public class Thing1Behaviour : MonoBehaviour
{

    Transform target;
    Transform enemyTransform;
    public float speed = 3f;
    public float rotationSpeed = 10f;
    Vector3 upAxis = new Vector3(0f, 0f, -1f);

    void Start()
    {

    }

    void FixedUpdate()
    {

        target = GameObject.FindWithTag("LightBandit").transform;
    }

    void Update()
    {
        //rotate to look at the player

        transform.LookAt(target.position, upAxis);
        transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z);



        //move towards the player
        enemyTransform.position += transform.up * speed * Time.deltaTime;

    }

}