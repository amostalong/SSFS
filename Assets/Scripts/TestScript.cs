using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QGame;

public class TestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        InputGoTest();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    InputGo ipt;

    void InputGoTest()
    {
        ipt = QGame.CoreGo.GetCore(CoreEnum.InputGo) as InputGo;

        ipt.RegisterKeyAction(KeyCode.W, PrintWWW, ButtonKeyType.Down);

        Invoke("EndInputTest", 3f);
        Invoke("EndInputTest", 5f);
    }

    void PrintWWW()
    {
        Debug.Log("wwwww");
    }

    void EndInputTest()
    {
        Debug.Log("Remove key cb");
        ipt.RemoveKeyAction(KeyCode.W, PrintWWW, ButtonKeyType.Down);
    }
}
