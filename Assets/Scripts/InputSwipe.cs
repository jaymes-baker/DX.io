using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
using PixelCrushers.DialogueSystem;

public class InputSwipe : MonoBehaviour, ISwipable
{
    [SerializeField]
    SwipeDirection lastSwipeDirection = SwipeDirection.None;
    DialogueSystemTrigger systemTrigger;
    [SerializeField]
    bool hasUserSwiped = false;

    // Start is called before the first frame update
    void Start()
    {
        systemTrigger = gameObject.GetComponent<DialogueSystemTrigger>();

        if(systemTrigger == null)
        {
            Destroy(this.gameObject);
        }

        TouchManager.instance.OnUserSwipe.AddListener(delegate { OnSwipe(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleHasUserSwiped()
    {
       hasUserSwiped = !hasUserSwiped;
    }

    public GameObject OnSwipe()
    {
        if (DialogueManager.isConversationActive)
        {
            return this.gameObject;
        }

        if (hasUserSwiped == true)
        {
            return this.gameObject;
        }

        lastSwipeDirection = TouchManager.instance.lastSwipe;
        Debug.Log($"Last swipe was {lastSwipeDirection}");

        switch (lastSwipeDirection)
        {
            case SwipeDirection.Up:
                DialogueLua.SetVariable("Swipe Up", true);
                hasUserSwiped = true;
                break;
            case SwipeDirection.Down:
                DialogueLua.SetVariable("Swipe Down", true);
                hasUserSwiped = true;
                break;
            case SwipeDirection.Left:
                DialogueLua.SetVariable("Swipe Left", true);
                hasUserSwiped = true;
                break;
            case SwipeDirection.Right:
                DialogueLua.SetVariable("Swipe Right", true);
                hasUserSwiped = true;
                break;
            case SwipeDirection.None:
                Debug.Log("Nothing was swiped");
                break;
            default:
                break;
        }

        systemTrigger.OnUse();
        return this.gameObject;
    }
}
