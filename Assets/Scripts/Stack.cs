using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stack : MonoBehaviour
{
    public GameObject previousTile;
    public GameObject currentTile;
    public GameObject tilePrefab;

    [Space]
    public Transform playerTransform;

    [Space]
    public GameObject playerParent;

    [Range(0, 50)]
    public float stackFallDistance;
    public List<GameObject> stackObjects = new List<GameObject>();


    [ContextMenu("SimpleMove")]
    void MoveForward()
    {
        //playerParent.transform.DOScale(2, 1);
    }

    

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "stackObject")
        {
            Destroy(other.gameObject);

            if (currentTile == null)
            {
                currentTile = Instantiate(tilePrefab, previousTile.transform.position + new Vector3(0, -0.4f, 0), previousTile.transform.rotation);
                stackObjects.Add(currentTile);
                currentTile.transform.parent = playerParent.transform;
                playerTransform.transform.position += new Vector3(0, 0.2f, 0);
            }
            else
            {
                previousTile = currentTile;
                currentTile = Instantiate(tilePrefab, previousTile.transform.position + new Vector3(0, stackFallDistance, 0), previousTile.transform.rotation);

                //Vector3 nScale = new Vector3(currentTile.transform.localScale.x + 0.2f, currentTile.transform.localScale.y + 0.2f, currentTile.transform.localScale.z + 0.2f);
                //currentTile.transform.DOPunchScale(nScale, 0.3f);

                stackObjects.Add(currentTile);
                currentTile.transform.parent = playerParent.transform;
                playerTransform.position += new Vector3(0, stackFallDistance, 0);
            }
        }

        for (int i = 0; i < stackObjects.Count; i++)
        {
            if(stackObjects[i].GetComponent<Collider>().enabled)
            stackObjects[i].GetComponent<Collider>().enabled = false;
        }

    }

    public void GetObjects(GameObject cube, int startPoint)
    {
        for (int i = startPoint; i < stackObjects.Count; i++)
        {
            float value = stackObjects[i].transform.localPosition.y - stackFallDistance;
            Vector3 newPosition = new Vector3(0, value, 0);
            //stackObjects[i].GetComponent<MeshRenderer>().material.color = Color.red;
            stackObjects[i].transform.localPosition = newPosition;
        }
        //Destroy(cube);
        //stackObjects.RemoveAt(startPoint);
    }
}
