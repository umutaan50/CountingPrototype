using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour 
    { 

    // TODO: Solve issue about collision and spawning more than a ball at the same time.

    [SerializeField] Texture2D releasedState;
    [SerializeField] Texture2D pressedState;

    [SerializeField] Vector2 _hotspot = Vector2.zero;
    [SerializeField] CursorMode _cursorMode = CursorMode.Auto;

    private void Start()
    {
        Cursor.SetCursor(releasedState, _hotspot, _cursorMode);
    }

    // I had an issue when I used FixedUpdate in this position instead:
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(pressedState, _hotspot, _cursorMode);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(releasedState, _hotspot, _cursorMode);
        }
    }


    //public Texture2D onBallTexture;
    //public Texture2D exitTexture;
    //public CursorMode cursorMode = CursorMode.Auto;
    //public Vector2 hotspot = Vector2.zero;

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //private void OnMouseEnter()
    //{
    //    if (gameObject.CompareTag("BallForPlayer"))
    //    {
    //        Cursor.SetCursor(onBallTexture, hotspot, cursorMode);
    //    }
    //}

    //private void OnMouseExit()
    //{
    //    Cursor.SetCursor(exitTexture, hotspot, cursorMode);
    //}
}
