﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;

    public bool isBad;

    private Rigidbody body;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    public void shoot(float speed, Vector3 dir)
    {
        body.velocity = dir.normalized * speed;
    }

    private void Update()
    {
        if (transform.position.sqrMagnitude > 20000)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Character ch = other.GetComponent<Character>();
        if (ch != null && ch.isBad != isBad)
        {
            ch.damage(damage);
        }
        if (ch == null || ch.isBad != isBad) Destroy(gameObject);
    }
}