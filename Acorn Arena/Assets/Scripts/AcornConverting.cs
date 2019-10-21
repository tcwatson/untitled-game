using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornConverting : MonoBehaviour
{
    public GameObject lootableAcorn;
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
        if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerController>().health--;
        }
    }

    IEnumerator StoppedMoving()
    {
        Debug.Log("waiting?");
        yield return new WaitUntil(() => gameObject.GetComponent<Rigidbody2D>().velocity.x == 0);
        Instantiate(lootableAcorn, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
