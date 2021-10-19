using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Etched
{
    public class BlockAppearance : MonoBehaviour
    {
        [SerializeField] Color commonColor = Color.green;
        [SerializeField] float commonThreshold = 0.05f;
        [SerializeField] Color uncommonColor = Color.yellow;
        [SerializeField] float uncommonThreshold = 0.01f;
        [SerializeField] Color rareColor = Color.red;

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
            char c = _letterBlock.Letter;
            float chance = AlphabetFrequency.CharChance(c);
            
            SetBlockSprite();

            if (chance < uncommonThreshold) SetColor(rareColor);
            else if (chance < commonThreshold) SetColor(uncommonColor);
            else SetColor(commonColor);
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