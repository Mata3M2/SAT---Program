using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject moguraPrefab; // Reference to the Mogura prefab
    // Start is called before the first frame update
    void Start()
    {
        Appearance();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, 10f);

        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider)
            {
                Destroy(hit.collider.gameObject);
                Appearance();
            }
        }
    
    
    }

    private void Appearance()
    {
        // Instantiate the Mogura prefab at a specific position and rotation
        Vector3 randomMoguraPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), transform.position.z); // Change this to your desired position
        Instantiate(moguraPrefab, randomMoguraPosition, Quaternion.identity);
    }
}
