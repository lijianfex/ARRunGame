using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AR 双击触碰小熊
/// </summary>
public class DoubleTouchCloseGet : MonoBehaviour {

    private float touchTime;
    private bool isFirstTouch;

    public ARImageUI imageUI;

    

    void Update()
    {
        TouchTap();
    }

    private void TouchTap()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.gameObject.tag == Tag.AR_Player)
                {
                    if (IsDoubleTouch())//双击角色
                    {
                        DoubleTouchEventHandle(hitInfo);
                        
                    }

                    if (IsLongTouch())//长按角色
                    {
                        LongTouchEventHandle(hitInfo);
                    }

                }


            }
        }
    }

    private void DoubleTouchEventHandle(RaycastHit hitInfo)
    {
        imageUI.CloseGetDoubleClick();
    }

    private void LongTouchEventHandle(RaycastHit hitInfo)
    {

    }

    //双击
    public bool IsDoubleTouch()
    {

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (Input.GetTouch(0).tapCount == 2)
            {
                return true;
            }
        }
        return false;
    }


    //长按
    public bool IsLongTouch()
    {

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                isFirstTouch = true;
                touchTime = Time.time;
            }
            else if (touch.phase == TouchPhase.Stationary)
            {
                if (isFirstTouch && Time.time - touchTime > 1f)
                {
                    isFirstTouch = false;
                    return true;
                }
            }
            else
            {
                isFirstTouch = false;
            }
        }
        return false;
    }

}
