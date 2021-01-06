using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellHandler : MonoBehaviour
{
    public bool isExplosionSpellUnlocked = false;

    [SerializeField] private GameObject explosionImage = null;
    [SerializeField] GameObject explosionFX = null;
    [SerializeField] public int explosionSpells = 1;
    [SerializeField] Button explosionButton = null;

    private bool isExplosionSpellActive = false;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        CheckIfExplosionSpellActive();
        ExplosionSpellsLeft();
    }

    private void ExplosionSpellsLeft()
    {
        if (explosionSpells <= 0)
        {
            explosionButton.interactable = false;
        }
        else
        {
            explosionButton.interactable = true;
        }
    }

    private void CheckIfExplosionSpellActive()
    {
        if (isExplosionSpellActive)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = mainCamera.ScreenToWorldPoint(mousePos);

            mousePos = new Vector3(mousePos.x, mousePos.y, explosionImage.transform.position.z);

            explosionImage.transform.position = mousePos;

            if (Input.GetMouseButtonDown(0))
            {
                GameObject explosionGO =  Instantiate(explosionFX, mousePos, Quaternion.identity);
                isExplosionSpellActive = false;
                explosionImage.SetActive(false);
                explosionSpells--;
                StartCoroutine(shortDelayDestroy(explosionGO));
            }
        }
    }

    private IEnumerator shortDelayDestroy(GameObject explosionGO)
    {
        yield return new WaitForSeconds(.5f);
        explosionGO.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(2f);
        Destroy(explosionGO);
    }

    public void CheckIfUnlocked()
    {
        if (isExplosionSpellUnlocked == false)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    public void ExplosionSpellButton()
    {
        isExplosionSpellActive = true;

        explosionImage.SetActive(true);
    }

}
