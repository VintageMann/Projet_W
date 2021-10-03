using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    private float update;
    public float framerate;
    public float frameSize;
    public bool playOnce;
    Renderer rend;
    private float offset = 0;    
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void Awake()
    {
        update = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        update += Time.deltaTime;
        if (update > framerate)
        {
            update = 0.0f;
            offset += frameSize;
        }       
        
        if (playOnce)
        {
            if (offset > 1 - frameSize)
            {
                offset = 1;
            }
        }
        else
        {
            if (offset > 1 - frameSize)
            {
                offset = 0;
            }
        }
       

        rend.material.SetTextureOffset("_MainTex", new Vector2(offset,0));
    }
}
