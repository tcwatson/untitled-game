using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornFiring : MonoBehaviour
{
    public GameObject acornEmitter;
    public GameObject acornProjectile;
    public float acornSpeed = 600f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && gameObject.GetComponent<PlayerController>().numberOfAcorns > 0)
        {
            GameObject tempAcorn = Instantiate(acornProjectile, acornEmitter.transform.position, acornEmitter.transform.rotation);

            //multiplying by the localScale.x makes it go in the left direction if the player is facing left;
            //scale.x is -1 when facing left.
            tempAcorn.GetComponent<Rigidbody2D>().AddForce(Vector2.right * acornSpeed * transform.localScale.x);

            gameObject.GetComponent<PlayerController>().numberOfAcorns--;
        }
    }
}
