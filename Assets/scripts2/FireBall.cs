using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float damage = 10;

    private void Start()
    {
        Invoke("DestroyFireBall", lifetime);
    }

    void FixedUpdate()
    {
        MoveFixetUpdate();
    }

    private void MoveFixetUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }



    private void DestroyFireBall()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        DamageEnemy(collision);
        DestroyFireBall();
    }


    private void DamageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
        }
    }
}
