using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class images : MonoBehaviour
{
    public Vector2 screen_size;
    private Vector2 screen_center;
    public GameObject current_image;
    private int image_num;
    private bool tapping; 
        
    // Start is called before the first frame update
    void Start()
    {
        screen_size.x = (float)Screen.width;
        screen_size.y = (float)Screen.height;
        screen_center = screen_size / 2;
        image_num = 0;
        current_image = GameObject.Find("" + image_num);
        tapping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1) // check for single finger swipe
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) // swiping?
            {
                if (!near_edge(touch.position)) tapping = true; // YES!
            }
            if (tapping)
            {
                if (touch.phase == TouchPhase.Ended)
                {
                    if (image_num == 2) image_num = 0;
                    else image_num = image_num + 1;
                    update_current_image(); // finished swiping
                }
            }
        }
    }
    void update_current_image()
    {
        tapping = false;
        current_image.GetComponent<SpriteRenderer>().enabled = false; // turn off image
        current_image = GameObject.Find("" + image_num); // update current image
        current_image.GetComponent<SpriteRenderer>().enabled = true; // turn on current image
    }
    bool near_edge(Vector2 position)
    {
        Vector2 d = position - screen_center;
        if (Mathf.Abs(d.x) > (0.4f * screen_size.x)) return true;
        if (Mathf.Abs(d.y) > (0.4f * screen_size.y)) return true;
        return false;
    }
}
