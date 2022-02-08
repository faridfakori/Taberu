using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextmove;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        Think();

        Invoke("Think", 5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextmove, rigid.velocity.y);
    }
    void Think()
    {
        nextmove = Random.Range(-1,2);

        Invoke("Think", 5);
    }
}
