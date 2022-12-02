using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Transform cam;

    [SerializeField] private LayerMask ignoreLayer;


    void Awake()
    {
        cam= Camera.main.transform;
    }

    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit, 100f, ignoreLayer))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.green);

            Vector3 hitPosition = hit.point;

            string hitName = hit.transform.name;

            string hitTag = hit.transform.tag;

            float hitDistance = hit.distance;
        }
        else
        {
            Color orange = new Color(255, 115, 0);

            Debug.DrawRay(transform.position, transform.forward * 100f, orange);
        }

        if(Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit rayHit;

            if(Physics.Raycast(ray, out rayHit))
            {
                if(rayHit.transform.name == "Cube 1")
                {
                    Debug.Log(rayHit.transform.name);
                    Invoke("LoadScene1", 5f);
                }

                if(rayHit.transform.name == "Cube 2")
                {
                    Debug.Log(rayHit.transform.name);
                    Invoke("LoadScene2", 5f);
                }

                if(rayHit.transform.name == "Sphere")
                {
                    Debug.Log(rayHit.transform.name);
                    Invoke("LoadScene3", 5f);
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
    }

    private void LoadScene1()
    {
        SceneManager.LoadScene(1);
    }

    private void LoadScene2()
    {
        SceneManager.LoadScene(2);
    }

     private void LoadScene3()
    {
        SceneManager.LoadScene(3);
    }
        
}
