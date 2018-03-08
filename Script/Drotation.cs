using UnityEngine;
using System.Collections;

public class Drotation : MonoBehaviour {

    public GameController GaCon;
    public bool colD;
    public bool RcolD;
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
        colD = false;
        RcolD = false;
        flag = true;
        StopCoroutine("Rotation");
        StopCoroutine("EndRote");
        yield return null;
    }

    void OnTriggerStay(Collider other)
    {
        if (colD || RcolD) {
            other.transform.parent = this.transform;

            if (this.transform.childCount == 4 && flag) {
                if (colD)  StartCoroutine(Rotation(-6));    //this.transform.Rotate(0, -90, 0);
                if (RcolD) StartCoroutine(Rotation(6)); //this.transform.Rotate(0, 90, 0);
                flag = false;
            }
        }
    }
}
