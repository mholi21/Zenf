using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {
    
    private Animator camAnim;
    private Animator aboutAnim;
    private Animator buttonsAnim;
    GameObject camera;
    GameObject about;
    GameObject buttons;

    void Awake()
    {
        camera = GameObject.Find("Main Camera");
        about = GameObject.Find("About");
        buttons = GameObject.Find("Buttons");

        camAnim = camera.GetComponent<Animator>();
        aboutAnim = about.GetComponent<Animator>();
        buttonsAnim= buttons.GetComponent<Animator>();

    }

    // Use this for initialization
    void Start () {
		
	}

    public void StartGame() {

        camAnim.SetBool("isAnimating", true);
        buttonsAnim.SetBool("isOut", true);
        buttonsAnim.SetBool("backIn", false);

    }

    public void goBack() {

        buttonsAnim.SetBool("backIn", true);
        buttonsAnim.SetBool("isOut", false);
        aboutAnim.SetBool("isOut", true);
        aboutAnim.SetBool("isAnimating", false);

    }

    public void AboutGame() {

        buttonsAnim.SetBool("isOut", true);
        buttonsAnim.SetBool("backIn", false);
        aboutAnim.SetBool("isAnimating", true);
        aboutAnim.SetBool("isOut", false);
        

    }

    public void QuitGame() {

        Application.Quit();

    }

	// Update is called once per frame
	void Update () {
		
	}
}
