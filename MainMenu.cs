using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    Controls controls;

    int menu;
    int prevMenu;
    /*
        0: Main Menu
            1: New Game
            2: Continue
            3: Level Select
            4: Options
            5: Leave
    */
    int selection;
    int maxSelect;

    int moveCD;
    bool noGame;
    bool popUp;
    bool zoomingIn;

    public GameObject cursor;
    float selectionTo;
    float selectTo;
    float fixedCursor;

    public GameObject fade;
    
    void Start()
    {
        controls = new Controls();
        controls.UI.Enable();
        controls.UI.Select.started += _ => Select();
        controls.UI.Select.canceled += _ => Cancel();

        maxSelect = 5;
        noGame = false;
    }

    //Select
    void Select()
    {
        zoomingIn = true;
        switch (menu)
        {
            case 0:
                //prevMenu = menu;
                //menu = selection + 1;
                break;
            case 1:
                
                break;
            case 2:

                break;
            case 3:

                break;
            case 4:

                break;
            case 5:

                break;
        }
    }

    //Back
    void Cancel()
    {

    }

    //Keyboard / Controller Navigation
    void Navigation()
    {
        if (Mathf.Abs(controls.UI.Navigate.ReadValue<Vector2>().y) < 0.5f)
        {
            moveCD = 25;
        }
        else if (moveCD >= 25)
        {
            gameObject.transform.GetChild(menu + 1).GetChild(selection).GetChild(0).GetComponent<TextMeshProUGUI>().color
                = new Color(1, 1, 1, 190f / 255);

            if (controls.UI.Navigate.ReadValue<Vector2>().y < 0)
            {
                selection++;
                if (noGame && menu == 0 && selection == 1) selection += 2;
            }
            else
            {
                selection--;
                if (noGame && menu == 0 && selection == 2) selection -= 2;
            }

            selection %= maxSelect;
            if (selection < 0) selection += maxSelect;
            moveCD = 0;
        }
    }

    //Mouse Hover Navigation
    public void Selection(int s)
    {
        selection = s;
        Debug.Log("test");
    }

    void CursorMovement()
    {
        if (zoomingIn)
        {
            cursor.transform.localPosition = new Vector3(0, selectionTo);
        }
        else
        {
            transform.GetChild(menu).transform.localScale +=
                    new Vector3((1f - transform.GetChild(menu).transform.localScale.x) / 15, (1f - transform.GetChild(prevMenu + 1).transform.localScale.y) / 15, 0);
            cursor.transform.localPosition += new Vector3(0, (selectionTo - cursor.transform.localPosition.y) / 5);
        }
    }
    
    void FixedUpdate()
    {
        Debug.Log(selection);
        if (moveCD < 25) moveCD++;

        //Selection Transitions
        switch (menu)
        {
            case 0:
                switch (selection)
                {
                    case 0:
                        selectionTo = 58.3f;
                        break;
                    case 1:
                        selectionTo = -11.2f;
                        break;
                    case 2:
                        selectionTo = -75.8f;
                        break;
                    case 3:
                        selectionTo = -148.6f;
                        break;
                    case 4:
                        selectionTo = -213.4f;
                        break;
                }
                Navigation();
                CursorMovement();
                break;
            case 1:

                break;
            case 2:

                break;
            case 3:

                break;
            case 4:

                break;
        }
    }
}