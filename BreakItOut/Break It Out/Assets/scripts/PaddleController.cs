using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] float ScreenWidthInUnits= 16f;
    [SerializeField] float clampXmax = 15f;
    [SerializeField] float clampyXmin = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousepos = Input.mousePosition.x / Screen.width * ScreenWidthInUnits;
        Vector2 paddlepos = new Vector2(transform.position.x, transform.position.y);
        paddlepos.x = Mathf.Clamp(mousepos, clampyXmin, clampXmax);
        transform.position = paddlepos;
    }
}
