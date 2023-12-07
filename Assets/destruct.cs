using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruct : MonoBehaviour
{   
    public GameObject patlama;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray,out hit,Mathf.Infinity))
            {
                if (hit.transform.gameObject.CompareTag("lavuk"))
                {
                    Destroy(hit.transform.gameObject.GetComponent<BoxCollider>());
                    GameObject efekt = Instantiate(patlama, hit.transform.position, hit.transform.rotation);

                    Transform[] bebeler = hit.transform.gameObject.GetComponentsInChildren<Transform>();

                    foreach (var bebelaklar in bebeler)
                    {
                        bebelaklar.gameObject.AddComponent<Rigidbody>();
                    }
                    Destroy(efekt, 1.5f);
                }
            }  
        }
    }
}
