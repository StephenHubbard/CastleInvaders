using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableUnit : MonoBehaviour
{
    [SerializeField] GameObject draggableConjurorModel = null;
    [SerializeField] Transform goldConjurorTransform = null;

    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;
    private bool isInsideTrashBarrel = false;

    private Camera mainCamera;
    private GoldConjuror goldConjuror;

    private void Start()
    {
        mainCamera = Camera.main;

        goldConjuror = FindObjectOfType<GoldConjuror>();
    }

    private void Update()
    {
        if (isBeingHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = mainCamera.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = mainCamera.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isBeingHeld = true;
        }
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;

        if (isInsideTrashBarrel)
        {
            Destroy(gameObject);

            if (gameObject.transform.root.GetComponent<GoldConjuror>() && goldConjuror.amountOfConjurors > 0)
            {
                goldConjuror.amountOfConjurors--;
            }
        }

        if (gameObject.transform.root.GetComponent<GoldConjuror>() && !isInsideTrashBarrel)
        {
            SpawnNewConjurorModel();
            Destroy(gameObject);

        }
    }

    private void SpawnNewConjurorModel()
    {
        Vector3 newPos = new Vector3(goldConjurorTransform.position.x, goldConjurorTransform.position.y, goldConjurorTransform.position.z - 1);
        GameObject newConjuror = Instantiate(draggableConjurorModel, newPos, transform.rotation);

        newConjuror.transform.parent = goldConjurorTransform.transform.parent;

        newConjuror.GetComponent<DraggableUnit>().enabled = true;
        newConjuror.GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Barrel"))
        {
            isInsideTrashBarrel = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Barrel"))
        {
            isInsideTrashBarrel = false;
        }
    }

    

}
