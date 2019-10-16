using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public int numberOfAcorns = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            numberOfAcorns += player.numberOfAcorns;
            player.numberOfAcorns = 0;
        }
    }
}
