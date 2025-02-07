using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Brick : MonoBehaviour
{
    [SerializeField] SpriteRenderer icon;
    [SerializeField] GameObject gift;
    [SerializeField] Sprite block;
    bool isActive;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gift != null)
        {
            if (!isActive)
            {
                isActive = true;
                var temp = Instantiate(gift);
                temp.transform.position = this.transform.position;
                temp.transform.DOMoveY(transform.position.y + 1.2f, 0.5f);
                icon.sprite = block;
            }
        }
        else
        {
            Destroy(this.gameObject);
            Debug.LogError("Da vo");
        }
    }
}
