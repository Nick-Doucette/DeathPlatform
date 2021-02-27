using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject fireProjectilePrefab;
    public Transform shootTransform;
    public bool isFacingRight = true;
    public void ShootProjectile()
    {
        GameObject hold = Instantiate(fireProjectilePrefab, shootTransform.transform.position, Quaternion.identity);
        hold.GetComponent<Projectile>().SetMoveSpeed(-6f);

        if (isFacingRight)
        {
            hold.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            
        }

    }


}
