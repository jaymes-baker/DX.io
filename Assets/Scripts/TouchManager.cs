using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Utilities;
using UnityEngine.Events;

public class TouchManager : MonoBehaviour
{

    public static TouchManager instance;
    public SwipeDirection lastSwipe = SwipeDirection.None;

    public UnityEvent OnUserSwipe = new UnityEvent();

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckForTouch();
    }

    private void CheckForTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                firstPressPos = new Vector2(touch.position.x, touch.position.y);
                Ray screenRay = Camera.main.ScreenPointToRay(touch.position);
                Debug.Log("Touch confirmed");
                RaycastHit hit;
                if (Physics.Raycast(screenRay, out hit))
                {
                    print("User tapped on game object " + hit.collider.gameObject.name);
                    HandleTap(hit.collider.gameObject);
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(touch.position.x, touch.position.y);

                //create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();

                //swipe upwards
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    Debug.Log("up swipe");
                    lastSwipe = SwipeDirection.Up;
                    OnUserSwipe.Invoke();
                }
                //swipe down
                else if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    Debug.Log("down swipe");
                    lastSwipe = SwipeDirection.Down;
                    OnUserSwipe.Invoke();
                }
                //swipe left
                else if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    Debug.Log("left swipe");
                    lastSwipe = SwipeDirection.Left;
                    OnUserSwipe.Invoke();
                }
                //swipe right
                else if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    Debug.Log("right swipe");
                    lastSwipe = SwipeDirection.Right;
                    OnUserSwipe.Invoke();
                }
                else
                {
                    lastSwipe = SwipeDirection.None;
                }
                
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Press position + " + eventData.pressPosition);
        Debug.Log("End position + " + eventData.position);
        Vector3 dragVectorDirection = (eventData.position - eventData.pressPosition).normalized;
        Debug.Log("norm + " + dragVectorDirection);
    }

    private void HandleTap(GameObject tappedObject)
    {
        ITouchable touched = tappedObject.GetComponent<ITouchable>();

        if (touched != null)
        {
            touched.OnTouch();
        }
    }
}
