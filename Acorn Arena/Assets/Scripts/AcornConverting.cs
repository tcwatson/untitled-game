using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornConverting : MonoBehaviour
{
    public GameObject lootableAcorn;
    private bool isLootable = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            StartCoroutine(StoppedMoving());
        }
        else if (collision.gameObject.tag.Equals("Player") && !isLootable)
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerController>().health--;
        }
    }

    IEnumerator StoppedMoving()
    {
        isLootable = true;
        yield return new WaitUntil(() => gameObject.GetComponent<Rigidbody2D>().velocity.x == 0 
            && gameObject.GetComponent<Rigidbody2D>().velocity.y == 0);

        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        
        gameObject.AddComponent<AcornController>();
        gameObject.tag = "Acorn";
        Destroy(gameObject.GetComponent<Rigidbody2D>());

        //Instantiate(lootableAcorn, gameObject.transform.position, gameObject.transform.rotation);
        //Destroy(gameObject);
    }
}
