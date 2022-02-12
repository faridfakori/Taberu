using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextmove;
    SpriteRenderer rend;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        Invoke("Think", 5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
     
        if(nextmove == -1)
        {
            rend.flipX = false;
        }
        else if (nextmove == 1)
        {
            rend.flipX = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            rigid.velocity = new Vector2(nextmove, rigid.velocity.y);

        }
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
    void Think()
    {
        nextmove = Random.Range(-1,2);
        Invoke("Think", 5);
    }
}
