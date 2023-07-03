using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTurret : MonoBehaviour
{
    public GameObject turretPrefab;
    private GM gameManager;
    private int turretPrice;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GM>();
        turretPrice = 100;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown() {
        if (gameManager.getCoins()>= turretPrice)
        {
            BuildTurret();
            gameManager.DecreaseCoins(turretPrice);
        }else{
            Debug.Log("No tienes recursos suficientes");
        }
    }
    private void BuildTurret(){
        Vector3 pos = transform.position;
        pos.y = pos.y + 0.35f;
        Instantiate(turretPrefab, pos, Quaternion.identity);
        Destroy(gameObject);
    }
}
