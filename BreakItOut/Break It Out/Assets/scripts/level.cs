using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour
{
    [SerializeField] int BreakableBlocks;
    SceneLoader sceneloader;

    // Start is called before the first frame update
    void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CountBlocks()
    {
        BreakableBlocks++;
    }
    public void BlocksDestroyed()
    {
        BreakableBlocks--;
        if(BreakableBlocks<=0)
        {
            sceneloader.LoadNextScene();
        }
    }
}
