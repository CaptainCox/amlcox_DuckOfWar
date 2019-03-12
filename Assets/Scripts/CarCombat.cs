using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCombat : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;

    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;

    void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();

        currentHealth = startingHealth;
    }

    void Update()
    {
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if (isDead)
            return;

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;
    }


    public void StartSinking()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        Destroy(gameObject, 2f);
    }
}
