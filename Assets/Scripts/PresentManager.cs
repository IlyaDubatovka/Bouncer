using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PresentManager : MonoBehaviour
{
    [SerializeField] private GameObject _present;
    [SerializeField] private int _countPresents = 6;
    [SerializeField] private Color[] _colors;
    private GameObject[] _presents;

    private void Awake()
    {
        _presents = new GameObject[_countPresents];
        for (int i = 0; i < _countPresents; i++)
        {
            var generatedColor = _colors[GetColor()];
            _presents[i]=Instantiate(_present, GetPresentPosition(), GetRotation());
            var renderers = _presents[i].GetComponentsInChildren<MeshRenderer>();
            for (var j = 0; j < renderers.Length; j++)
            {
                var recoloringMaterial = renderers[j].materials[1];
                recoloringMaterial.color=generatedColor;
            }

        }
    }

    private Vector3 GetPresentPosition()
    {
        return new Vector3(Random.Range(-9.5f,9.5f),0.1f,Random.Range(-9.5f,9.5f));
    }

    private Quaternion GetRotation()
    {
        var rotation= Random.rotation;
        rotation.x = 0;
        rotation.z = 0;
        return rotation;
    }

    private int GetColor()
    {
        return Random.Range(0, _colors.Length);
    }
}
