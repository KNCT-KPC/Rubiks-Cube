using UnityEngine;
using System.Collections;

public class Rrotation : MonoBehaviour {

    public GameController GaCon;
    public bool colR;
    public bool RcolR;
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
            this.transform.Rotate(0, 0, angle * 15);
            yield return null;
        }
        else
        {
            for (int i = 0; i < 15; i++)
            {
                this.transform.Rotate(0, 0, angle);
                yield return new WaitForSeconds(0.01f);
            }
        }
        yield return StartCoroutine(EndRote());
    }

    IEnumerator EndRote()
    {
        this.transform.DetachChildren();
        colR = false;
        RcolR = false;
        StopCoroutine("Rotation");
        StopCoroutine("EndRote");
        flag = true;
        yield return null;
    }

    void OnTriggerStay(Collider other)
    {
        if (colR || RcolR) {
            other.transform.parent = this.transform;

            if (this.transform.childCount == 4 && flag)
            {
                if (colR)  StartCoroutine(Rotation(-6));//this.transform.Rotate(0, 0, -90);
                if (RcolR) StartCoroutine(Rotation(6));//this.transform.Rotate(0, 0, 90);
                flag = false;
            }
        }
    }
}
