using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using PixelCrushers.DialogueSystem;
using UnityEngine.Events;
using Utilities;

public class InteractableTouchTrigger : MonoBehaviour, ITouchable
{
    protected Collider col;
    protected DialogueSystemTrigger systemTrigger;
    protected Sequencer sequencer;

    public virtual GameObject OnTouch()
    {
        systemTrigger.OnUse();
        
        return this.gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        systemTrigger = gameObject.GetComponent<DialogueSystemTrigger>();
        col = gameObject.GetComponent<Collider>();

        if (col == null || systemTrigger == null)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
