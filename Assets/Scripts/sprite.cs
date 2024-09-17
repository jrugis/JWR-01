using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprite : MonoBehaviour
{
    public float screen_width;
    public float screen_height;
    public Vector2 image_size;

    // Start is called before the first frame update
    void Start()
    {
        screen_width = (float)Screen.width;
        screen_height = (float)Screen.height;
        image_size = gameObject.GetComponent<SpriteRenderer>().sprite.rect.size;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
