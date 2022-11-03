using DG.Tweening;
using UnityEngine;

public class Door : MonoBehaviour
{
    private GameObject _doorMesh;
    private static readonly int Open = Animator.StringToHash("Open");
    private static readonly int Close = Animator.StringToHash("Close");

    private void Start()
    {
        _doorMesh = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        _doorMesh.transform.DORotate(Vector3.zero,.4f);
    }

    private void OnTriggerExit(Collider other)
    {
        _doorMesh.transform.DORotate(Vector3.up * 90,.4f);
    }
}
