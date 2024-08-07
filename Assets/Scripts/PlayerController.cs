using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public RawImage crossHair;

    // Start is called before the first frame update
    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        crossHair = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
    }
}
