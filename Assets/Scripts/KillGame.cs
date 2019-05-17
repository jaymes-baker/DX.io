using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGame : MonoBehaviour, ITransitionComponent
{
    public GameObject[] objects;
    public void TriggerTransition()
    {
        foreach (GameObject item in objects)
        {
            item.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
