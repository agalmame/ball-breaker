using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Level : MonoBehaviour

{
    [SerializeField] int breakableBlocks;

    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroy()
    {
        if (breakableBlocks > 0)
        {
            breakableBlocks--;
            if (breakableBlocks == 0)
            {
                sceneLoader.LoadNextScene();
            }
        }
    }
}
