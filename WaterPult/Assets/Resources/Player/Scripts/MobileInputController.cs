using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MobileInputController : MonoBehaviour
{
    private Controls controls;

    private InputAction mouseClick;
    private InputAction mousePosition;

    private Camera camera;

    private Catapult catapult;

    DragAndDrop2D dragAndDrop;


    public enum State
    {
        Get,
        Hold,
        Release,
        Wait
    }

    public void Enable()
    {
        state = State.Get;
    }

    public void Disable()
    {
        state = State.Wait;
    }

    private State state;

    private void Awake()
    {
        controls = new Controls();
        mouseClick = controls.Commands.Press;
        mousePosition = controls.Commands.Position;
    }

    private void OnEnable()
    {
        mousePosition.Enable();
        mouseClick.Enable();
    }

    private void OnDisable()
    {
        mouseClick.Disable();
        mousePosition.Disable();
    }

    private void Start()
    {
        catapult = this.GetComponent<Catapult>();
        camera = Camera.main;
        state = State.Get;
        dragAndDrop = this.GetComponent<DragAndDrop2D>();
    }


    private void Update()
    {
        //SpawnBullet();
        switch (state)
        {
            case State.Get:
                GetState();
                break;
            case State.Hold:
                HoldState();
                break;
            case State.Release:
                ReleaseState();
                break;
        }

    }

    public void GetState()
    {
        Vector2 mousePos = mousePosition.ReadValue<Vector2>();
        if (mouseClick.IsPressed() && dragAndDrop.Get(mousePos))
        {
            state = State.Hold;
        }
        else state = State.Get;
    }

    public void HoldState()
    {
        Vector2 mousePos = mousePosition.ReadValue<Vector2>();
        if (mouseClick.IsPressed() && dragAndDrop.Hold(mousePos))
            state = State.Hold;
        else state = State.Release;
    }

    public void ReleaseState()
    {
        catapult.Shoot();
        dragAndDrop.Release();

        state = State.Wait;
    }

    private void SpawnBullet()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            catapult.Load();
        }
    }
}
