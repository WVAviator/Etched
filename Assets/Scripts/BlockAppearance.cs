using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Etched
{
    public class BlockAppearance : MonoBehaviour
    {

        [SerializeField] List<Sprite> blockSprites;

        SpriteRenderer _spriteRenderer;
        LetterBlock _letterBlock;
        TextMeshProUGUI _tmp;

        void Awake()
        {
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            _letterBlock = GetComponent<LetterBlock>();
            _tmp = GetComponentInChildren<TextMeshProUGUI>();
        }

        void Start()
        {
            SetBlockSprite();
        }

        void SetColor(Color co)
        {
            //_spriteRenderer.color = co;
            _tmp.color = co;
        }

        void SetBlockSprite()
        {
            _spriteRenderer.sprite = blockSprites[Random.Range(0, blockSprites.Count)];
        }
    }
}