using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Wall : MonoBehaviour, IInteractable
{
    [SerializeField] private MeshRenderer[] meshRenderer;
    [SerializeField] private float colorSwapDuration = 1;
    [SerializeField] private Color old_color;
    [SerializeField] private Color new_color;
    private Material[] materials;

    void Start()
    {
        materials = new Material[meshRenderer.Length];

        for (int i = 0; i < meshRenderer.Length; i++)
        {
            materials[i] = meshRenderer[i].materials[0];
            materials[i].color = old_color;
        }
    }

    public void Interact(Character character)
    {
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].DOColor(new_color, colorSwapDuration);
        }
    }
}