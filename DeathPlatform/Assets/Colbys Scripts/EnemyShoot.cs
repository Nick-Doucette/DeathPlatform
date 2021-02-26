using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject fireProjectilePrefab;

    public void ShootProjectile()
    {
        Instantiate(fireProjectilePrefab);
    }
}
