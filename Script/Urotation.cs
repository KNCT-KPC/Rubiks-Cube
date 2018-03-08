using UnityEngine;
using System.Collections;

public class Urotation : MonoBehaviour {

    public GameController GaCon;
    public bool colU;
    public bool RcolU;
    bool flag;

	// Use this for initialization
	void Start () {
        flag = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Rotation(int angle)
    {
        if (GaCon.ButtonPush)
        {
            this.transform.Rotate(0, angle * 15, 0);
            yield return null;
        }
        else
        {
            for (int i = 0; i < 15; i++)
            {
                this.transform.Rotate(0, angle, 0);
                yield return new WaitForSeconds(0.01f);
            }
        }
        yield return StartCoroutine(EndRote());
    }

    IEnumerator EndRote()
    {
        this.transform.DetachChildren();
        colU = false;
        RcolU = false;
        flag = true;
        StopCoroutine("Rotation");
        StopCoroutine("EndRote");
        yield return null;
    }

    void OnTriggerStay(Collider other)
    {
        if (colU || RcolU)
        {
            other.transform.parent = this.transform;

            if (this.transform.childCount == 4 && flag)
            {
                if (colU) StartCoroutine(Rotation(6));//this.transform.Rotate(0, 90, 0);
                if (RcolU) StartCoroutine(Rotation(-6));//this.transform.Rotate(0, -90, 0);
                flag = false;
            }
        }
    }

}
