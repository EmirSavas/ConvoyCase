using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public SwipeControls swipe;
    private Vector2 swipeDelta = Vector2.zero;
    public int convoyLoc = 0;

    private void Update()
    {
        gameObject.transform.Translate(Vector3.forward * 3f * Time.deltaTime, Space.World);

        BalanceConvoyLoc();

        if (Input.GetMouseButtonUp(0))
        {
            swipe.releasePoint = Input.mousePosition;

            if (swipe.isDraging)
            {
                float dist = Vector3.Distance(swipe.firstPoint, swipe.releasePoint);


                swipeDelta = (Vector2) Input.mousePosition - swipe.firstPoint;
                
                if (Mathf.Abs(dist) > 100)
                {
                    if (swipeDelta.x > 0)
                    {
                        convoyLoc++;
                        MoveConvoy();
                    }

                    else if (swipeDelta.x <= 0)
                    {
                        convoyLoc--;
                        MoveConvoy();
                    }

                    swipe.Reset();
                }
            }
        }



        void MoveConvoy()
        {
            switch (convoyLoc)
            {
                case 0:
                    gameObject.transform.position = new Vector3(0, gameObject.transform.position.y, gameObject.transform.position.z);
                    break;
                
                case 1:
                    gameObject.transform.position = new Vector3(-22, gameObject.transform.position.y, gameObject.transform.position.z);
                    break;
                
                case -1:
                    gameObject.transform.position = new Vector3(22, gameObject.transform.position.y, gameObject.transform.position.z);
                    break;
                
            }
        }

        void BalanceConvoyLoc()
        {
            if (convoyLoc > 1)
            {
                convoyLoc = 1;
            }
            else if (convoyLoc < -1)
            {
                convoyLoc = -1;
            }
        }
    }
}
