/*
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RotateDragWithSnapEvent : BaseTouch {

    [SerializeField]
    private float rotationSpeed = 100f;
    private bool isRotating = false;
    private float startPosition;

    public GameObject[] rotateTogether;

    [SerializeField]
    private float[] snapAngles = {0, 90, 180, 270};

    private float selfYAngle;

    public UnityEvent snapEvent;

    internal override void Action(Vector3 myInput) {
        actionPersist = true;
        isRotating = true;
        gameObject.layer = LayerMask.NameToLayer("Unwalkable");
        startPosition = myInput.x;
    }

    internal override void TogglePersist() {
        # if UNITY_EDITOR || UNITY_STANDALONE
        HandleDragMouse();
        # elif UNITY_ANDROID || UNITY_IOS
        HandleDragMobile();
        # endif
    }

    void HandleDragMouse() {
        if(Input.GetMouseButtonUp(0)) {
            StopRotation();
        }
        if(isRotating) {
            Rotate(Input.mousePosition.x);
        }
    }

    void HandleDragMobile() {
        if (Input.touchCount>0 && Input.touches[0].phase == TouchPhase.Ended) {
            StopRotation();
        }
        if(isRotating) {
            Rotate(Input.touches[0].position.x);
        }
    }

    void StopRotation() {
        isRotating = false;
        gameObject.layer = LayerMask.NameToLayer("Walkable");

        actionPersist = false;
        
        float angle = (transform.eulerAngles.y + 360) % 360;

        float curMinAngle = 500f;
        int snapTo = -1;

        float parentAngle = transform.parent.eulerAngles.y;

        for(int i=0; i<snapAngles.Length; i++) {
            float temp = System.Math.Min(System.Math.Abs(angle - snapAngles[i] - parentAngle), System.Math.Abs(angle - snapAngles[i] - parentAngle - 360));
            if(temp < curMinAngle) {
                snapTo = i;
                curMinAngle = temp;
            }
        }

        float rotateTo = snapAngles[snapTo] + parentAngle;
        foreach(GameObject obj in rotateTogether) {
            obj.transform.Rotate(Vector3.up, rotateTo - transform.rotation.eulerAngles.y);
        }
        transform.Rotate(Vector3.up, rotateTo - transform.rotation.eulerAngles.y);

        // invoke event (e.g. to update node links after rotating)
        if (snapEvent != null)
        {
            snapEvent.Invoke();
        }
    }

    void Rotate(float currentPosition) {
        float movement = currentPosition - startPosition;
        transform.Rotate(Vector3.up, -movement * rotationSpeed * Time.deltaTime);
        foreach(GameObject obj in rotateTogether) {
            obj.transform.Rotate(Vector3.up, -movement * rotationSpeed * Time.deltaTime);
        }
        startPosition = currentPosition;
    }
}
*/