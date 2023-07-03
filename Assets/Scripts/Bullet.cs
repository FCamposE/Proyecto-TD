using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 20f;

    private Transform target;

    public void Seek(Transform _target) {
        target = _target;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame) {
            //HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        //transform.LookAt(target);
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            //Debug.Log("tiro acertado");
            enemy.TakeDamage((int)damage);
            Destroy(gameObject);
        }
    }
    /*void HitTarget() {
        // Aplica el daño al enemigo
        Enemy enemy = target.GetComponent<Enemy>();
        if (enemy != null) {
            //enemy.TakeDamage(damage);
            //Destroy(enemy);
        }

        // Destruye la bala
        Destroy(gameObject);
    }*/
}
