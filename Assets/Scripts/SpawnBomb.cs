using UnityEngine;
using System.Collections;

public class SpawnBomb : MonoBehaviour {

    public GameObject bomb;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                    Instantiate(bomb, new Vector3(hit.point.x, 6f, hit.point.z) , Quaternion.identity);
            }
        }
    }
}
