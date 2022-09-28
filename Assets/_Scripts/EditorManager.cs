using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EditorManager : MonoBehaviour
{
    PlayerAction inputAction;

    public Camera mainCam;
    public Camera editorCam;

    public GameObject prefab1;
    public GameObject prefab2;

    GameObject item;

    public bool editorMode = false;
    bool instantiated = false;

    //new week 3 content
    Vector3 mousePos;

    Subject subject = new Subject();


    // Start is called before the first frame update
    void Start()
    {
        inputAction = PlayerInputController.controller.inputAction;

        inputAction.Editor.EnableEditor.performed += cntxt => switchCamera();

        inputAction.Editor.AddItem1.performed += cntxt => addItem(1);

        inputAction.Editor.AddItem2.performed += cntxt => addItem(2);

        inputAction.Editor.DropItem.performed += cntxt => dropItem();

        mainCam.enabled = true;
        editorCam.enabled = false;
    }

    private void switchCamera()
    {
        mainCam.enabled = !mainCam.enabled ;
        editorCam.enabled = !editorCam.enabled;
    }

    private void addItem(int itemId)
    {
        if(editorMode && !instantiated)
        {
            switch (itemId)
            {
                case 1:
                    item = Instantiate(prefab1);
                    Gem gem1 = new Gem(item, new GreenMat());
                    subject.AddObserver(gem1);
                    break;

                case 2:
                    item = Instantiate(prefab2);
                    Gem gem2 = new Gem(item, new YellowMat());
                    subject.AddObserver(gem2);
                    break;

                default:
                    break;
            }
            subject.Notify();
            instantiated = true;
        }
    }

    private void dropItem()
    {
        if (editorMode && instantiated)
        {
            item.GetComponent<Rigidbody>().useGravity = true;
            item.GetComponent<Collider>().enabled = true;

            instantiated = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCam.enabled == false && editorCam.enabled == true)
        {
            editorMode = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            editorMode = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if(instantiated)
        {
            mousePos = Mouse.current.position.ReadValue();
            mousePos = new Vector3(mousePos.x, mousePos.y, 40f);

            item.transform.position = editorCam.ScreenToWorldPoint(mousePos);
        }
    }
}
