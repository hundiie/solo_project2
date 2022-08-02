using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed = 1;

    private void Start()
    {
        Destroy(gameObject, 3.0f);
    }
    void Update()
    {
        transform.Translate(0, 0, BulletSpeed );
    }
}
