
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISample : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image TargetImage;

    [SerializeField]
    private UnityEngine.UI.Button TargetButton;

    [SerializeField]
    private UnityEngine.UI.Button AccelButton;
    
    float UpdateSpeed;
    bool move = false;
    bool speed = false;
    int a = 0;

    void Start()
    {

        TargetButton.onClick.AddListener(taskonclick);
        AccelButton.onClick.AddListener(taskonclick2);
        //TargetImage.color = new Color(1f, 1f, 1f, 0f);
    }

    void taskonclick2()
    {
        speed = !speed;


    }

    void taskonclick()
    {
        move = !move;
        /*
        Color c = TargetImage.color;
        c.a += 0.01f;
        TargetImage.color = c;
        */
    }


    void Update()
    {
        Vector3 position = TargetImage.transform.localPosition;
        if (move)
        {
                position.x -= 1f;
            if (speed)
            {
                a += 1;
                position.x -= 1f + a;

            }
                TargetImage.transform.localPosition = position;
        }
    }

}
