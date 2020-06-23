using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{

    [SerializeField]
    float _moveDuration = 1.0f;

    bool isWalked = false;
    public bool IsWalked { get { return isWalked; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector2 deltaPos)
    {
        StartCoroutine(MoveBy(deltaPos));
    }
    

    /// <summary>
    /// 現在の位置から指定したベクトルで移動する
    /// </summary>
    /// <param name="duration">移動にかかる時間 [sec]</param>
    /// <param name="deltaPos">移動ベクトル</param>
    /// <returns></returns>
    private IEnumerator MoveBy(Vector2 deltaPos)
    {
        isWalked = false;

        Vector2 startPosition = transform.position;
        Vector2 endPosition = startPosition + deltaPos;
        float startTime = Time.time;

        while (true)
        {
            float t = (Time.time - startTime) / _moveDuration;
            Vector2 newPosition = Vector2.Lerp(startPosition, endPosition, t);
            transform.position = newPosition;

            if(t >= 1.0f)
            {
                transform.position = endPosition;
                isWalked = true;
                break;
            }

            yield return null;
        }
    }

    private void faceTo()
    {

    }
}
