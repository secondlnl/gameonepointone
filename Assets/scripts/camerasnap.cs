using System;
using UnityEngine;
using UnityEngine.UIElements;

public class camerasnap : MonoBehaviour
{
    [SerializeField] private float offsetY = 0f;
    [SerializeField] private float offsetX = 0f;
    [SerializeField] private float Zoomfactor = 0f;
    [SerializeField] private bool ReturnCamera = true;


    private camerafollow camerafollow;
    void Start()
    {
        camerafollow = GameObject.FindWithTag("MainCamera").GetComponent<camerafollow>();
        print("sv: " + camerafollow.offset);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            camerafollow.offset = new Vector3(offsetX, offsetY, -10f * Zoomfactor);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (ReturnCamera)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                camerafollow.offset = new Vector3(0, 0, -10f);
            }
        }
    }

}
