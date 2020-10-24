using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPreFab;
    public Button fireButton;
    public Animator fireGunAnimator;

    public float bulletForce = 10f;
    public float fireGunAnimationDuration = 0.2f;

    void Start()
    {
        fireButton.onClick.AddListener(shoot);
    }
    void Update()
    {

    }

    void shoot()
    {
        fireGunAnimator.SetBool("fire", true);
        Invoke("stopFireGunAnimator", fireGunAnimationDuration);
        GameObject bullet = Instantiate(bulletPreFab, firePoint.position, firePoint.rotation);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        rbBullet.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 5f);
    }

    void stopFireGunAnimator(){
        fireGunAnimator.SetBool("fire", false);
    }

}
