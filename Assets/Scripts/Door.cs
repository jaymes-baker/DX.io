using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, ITouchable
{
    public bool isDoorConditionMet = false;

    public GameObject OnTouch()
    {
        if (isDoorConditionMet)
        {
            ITransitionComponent transitionRule = gameObject.GetComponent<ITransitionComponent>();
            transitionRule.TriggerTransition();
        }
        return this.gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDoorCondition()
    {
        isDoorConditionMet = true;
    }
}
