using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] public int breakableBlocks;

    private NextScene loader;

    private void Start()
    {
        loader = FindObjectOfType<NextScene>();
    }
    
    public void IncrementBreakCount()
    {
        breakableBlocks++;
    }

    public void DecrementBreakCount()
    {
        breakableBlocks--;
        
        if (breakableBlocks <= 0)
            loader.GetNextScene();
    }
}
