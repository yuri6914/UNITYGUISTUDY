using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class IEnumaeratorSample : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Button CoroutineButton;
    [SerializeField] private UnityEngine.UI.Button CoroutineButtonDispose;
    [SerializeField] private UnityEngine.UI.Image CoroutineIMG;
    [SerializeField] Vector3 MoveVector = new Vector3(0, 0, 0);
    [SerializeField] float MoveTime;
    //[SerializeField] float changeX = 0;
    //[SerializeField] float changeY = 0;
    //[SerializeField] float changeZ = 0;


    private System.IDisposable Button1Subcription = null;


    void Start()
    {

        SubscribeButton1();


        var subscription2 = CoroutineButtonDispose.OnClickAsObservable()
            .Subscribe(_ => 
            { 
                if(Button1Subcription == null)
                {
                    SubscribeButton1();
                }
                else
                {
                    Button1Subcription.Dispose();
                    Button1Subcription = null;
                }

            });

    }

    private void SubscribeButton1()
    {
            Button1Subcription =
        CoroutineButton.OnClickAsObservable()
        .Subscribe(_ => { StartCoroutine(CoroutineButtonMove()); });


    }


    private IEnumerator CoroutineButtonMove()
    {
        Debug.Log("START MOVING");
        //Vector3 position = CoroutineIMG.transform.localPosition;


        //for (a = 0; a < 300; a++)
        //{
        //    yield return null;
        //    position.x -= 1;
        //    CoroutineIMG.transform.localPosition = position;

        //}

        //Debug.Log("STOP");
        //yield return new WaitForSeconds(1.0f);
        //Debug.Log("stopped");
        //yield break;

        Vector3 initial = CoroutineIMG.transform.localPosition;
        Vector3 finale = initial + MoveVector;
        float timecounter = 0f;
        while(timecounter < MoveTime)
        {
            yield return null;
            timecounter += Time.deltaTime;

            Vector3 position = Vector3.Lerp(initial, finale, timecounter/MoveTime);
            CoroutineIMG.transform.localPosition = position;
        }

        Debug.Log("END!!");
    }


}
