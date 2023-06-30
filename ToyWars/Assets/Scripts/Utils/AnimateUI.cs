using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class AnimateUI : MonoBehaviour
{
    [SerializeField] private int _intervalSpeed = 250;
    private Image _imageUI;
    [SerializeField] private Sprite[] _sprites;
    private int _currentSprite = 0;
    
    private void Start()
    {
        _imageUI = GetComponent<Image>();
        StartCoroutine(Animate());
    }
    
    private IEnumerator Animate()
    {
        while (true)
        {
            _imageUI.sprite = _sprites[_currentSprite];
            _currentSprite = (_currentSprite + 1) % _sprites.Length;
            yield return new WaitForSeconds(_intervalSpeed / 1000f);
        }
    }

}
