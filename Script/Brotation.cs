using UnityEngine;
using System.Collections;

public class Brotation : MonoBehaviour {

    public GameController GaCon;
    public bool colB;
    public bool RcolB;
    bool flag;

	// Use this for initialization
	void Start (){
        flag = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Rotation(int angle)
    {
        if (GaCon.ButtonPush)
        {
            this.transform.Rotate(angle * 15, 0, 0);
            yield return null;
        }
        else
        {
            for (int i = 0; i < 15; i++)
            {
                this.transform.Rotate(angle, 0, 0);
                yield return new WaitForSeconds(0.01f);
            }
        }
        yield return StartCoroutine(EndRote());
    }

    IEnumerator EndRote(){
        this.transform.DetachChildren();
        colB = false;
        RcolB = false;
        flag = true;
        StopCoroutine("Rotation");
        StopCoroutine("EndRote");
        yield return null;
    }


    void OnTriggerStay(Collider other)
    {
        if (colB || RcolB)
        {
            other.transform.parent = this.transform;

            if (this.transform.childCount == 4 && flag) {
                if (colB) StartCoroutine(Rotation(6));//this.transform.Rotate(90, 0, 0);
                if (RcolB) StartCoroutine(Rotation(-6));//this.transform.Rotate(-90, 0, 0);
                flag = false;
            }
        }
    }
}
