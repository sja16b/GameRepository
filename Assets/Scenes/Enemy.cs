using System.Collections;

using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform Player;
    public Transform enemy;
    float MoveSpeed = 1;
    int MaxDist = 2;
    int MinDist = 5;
    double range;

    private Animator animator;
    private Rigidbody2D body2d;



    void Start()
    {
        animator = GetComponent<Animator>();
        body2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        range = Vector2.Distance(transform.position, Player.position);
        Debug.DrawLine(Player.position, enemy.position, Color.red);

        if (range < MaxDist)
        {
            float step = (MoveSpeed/2) * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, Player.position, step);

        }

        if (range > MaxDist)
        {
            //nothing
        }


        if (Player.position.x > transform.position.x)
        {
            //face right
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Player.position.x < transform.position.x)
        {
            //face left
            transform.localScale = new Vector3(-1, 1, 1);
        }



    }
}