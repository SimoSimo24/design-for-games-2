using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class dontdestroy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < Object.FindObjectsByType<dontdestroy>(FindObjectsSortMode.None).Length; i++)
        {
            if (Object.FindObjectsByType<dontdestroy>(FindObjectsSortMode.None)[i] != this)
            {
                if (Object.FindObjectsByType<dontdestroy>(FindObjectsSortMode.None)[i].name == gameObject.name)
                {
                    Destroy(gameObject);
                }
            }
            
        }
        
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
