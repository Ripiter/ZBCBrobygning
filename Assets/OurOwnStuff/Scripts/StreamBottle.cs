using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamBottle : MonoBehaviour
{
    LineRenderer lineRenderer;
    Vector3 targetPos = Vector3.zero;

    ParticleSystem splashParticle;
    Coroutine pourRoutine;

    void Awake()
    {
        lineRenderer = GetComponentInChildren<LineRenderer>();
        splashParticle = GetComponentInChildren<ParticleSystem>();
    }

    void Start()
    {
        MoveToPosition(0, transform.position);
        MoveToPosition(1, transform.position);
    }

    public void Begin()
    {
        StartCoroutine(UpdateParticle());
        pourRoutine = StartCoroutine(BeginPour());
    }

    public void End()
    {
        StopCoroutine(pourRoutine);
        pourRoutine = StartCoroutine(EndPour());
        //Destroy(gameObject);
    }

    IEnumerator BeginPour()
    {
        while (gameObject.activeSelf)
        {
            targetPos = FindEndPoint();

            MoveToPosition(0, transform.position);
            AnimateToPosition(1, targetPos);


            yield return null;
        }
    }

    IEnumerator EndPour()
    {
        while (!HasReachedPosition(0, targetPos))
        {
            AnimateToPosition(0, targetPos);
            AnimateToPosition(1, targetPos);

            yield return null;
        }

        Destroy(gameObject);
    }

    Vector3 FindEndPoint()
    {
        RaycastHit hit;

        Ray ray = new Ray(transform.position, Vector3.down);

        Physics.Raycast(ray, out hit, 4f);
        Vector3 endPoint = hit.collider ? hit.point : ray.GetPoint(2f);

        if(hit.collider != null)
            HandleStream(hit.transform.gameObject);

        return endPoint;
    }

    void MoveToPosition(int index, Vector3 targetPos)
    {
        lineRenderer.SetPosition(index, targetPos);
    }

    void AnimateToPosition(int index, Vector3 targetPos)
    {
        Vector3 currectPoint = lineRenderer.GetPosition(index);
        Vector3 newPos = Vector3.MoveTowards(currectPoint, targetPos, Time.deltaTime * 1.75f);
        lineRenderer.SetPosition(index, newPos);

    }

    bool HasReachedPosition(int index, Vector3 targetPos)
    {
        Vector3 currectPos = lineRenderer.GetPosition(index);

        // Returns true or false
        return currectPos == targetPos;
    }

    IEnumerator UpdateParticle()
    {
        while (gameObject.activeSelf)
        {
            splashParticle.gameObject.transform.position = targetPos;
            bool isHitting = HasReachedPosition(1, targetPos);
            splashParticle.gameObject.SetActive(isHitting);

            yield return null;
        }
    }


    void HandleStream(GameObject gameObject)
    {
        if (GetComponentInParent<BottleScript>() != null)
        {
            if (gameObject.GetComponent<Plate>() != null)
            {
                gameObject.GetComponent<Plate>().AddFluid(GetComponentInParent<BottleScript>().NameOfFluid);
            }
        }

        if(gameObject.GetComponent<Food>() != null && GetComponentInParent<BottleScript>() == null)
        {
            Food food = gameObject.GetComponent<Food>();

            food.SetOutLine(false);
        }

    }
}
