using DG.Tweening;
using UnityEngine;

public class Garbage : MonoBehaviour, IInteractable
{
    private static float duration = .2f;
    public void Interact(Character character)
    {
        if(!character.CollectGarbage())
            return;
        transform.DOScale(Vector3.zero, duration).SetEase(Ease.InBack).OnComplete(() => Destroy(gameObject)); 
    }
}