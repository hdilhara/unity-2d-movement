using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject bulletHitVFX;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(Instantiate(bulletHitVFX, transform.position, transform.rotation), 0.2f);
        Destroy(gameObject);
    }

}
