using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class EnemyMovement : MonoBehaviour
{
    public Transform[] movementPoints;
    private int currentPointIndex = 0;
    public float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        GameObject wp = GameObject.Find("Waypoints");
        movementPoints = wp.GetComponentsInChildren<Transform>(true);
        movementPoints = movementPoints.Where(t => t.gameObject != wp).ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == movementPoints[currentPointIndex].position)
        {
            currentPointIndex = (currentPointIndex + 1) % movementPoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, movementPoints[currentPointIndex].position, speed * Time.deltaTime);

        if (currentPointIndex == movementPoints.Length-1)
        {
            Destroy(gameObject, 0.8f);
            //Debug.Log("destruir");
        }
    }
}
