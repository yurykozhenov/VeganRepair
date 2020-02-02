using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CointsControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite gray;
    public Sprite gold;
    public GameObject cointsAnim;
    public float waitTime = 3;

    public void show(int count)
    {
        if (count < 1 || count > 3) return;
        GameObject coinAnim = Instantiate(cointsAnim, transform.position, transform.rotation);
        coinAnim.transform.SetParent(this.transform);
        coinAnim.transform.position = Vector2.zero;
        if (count == 1)
        {
            coinAnim.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = gold;
        }
        else if (count == 2)
        {
            coinAnim.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = gold;
            coinAnim.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = gold;
        }
        else if (count == 3)
        {
            coinAnim.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = gold;
            coinAnim.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = gold;
            coinAnim.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = gold;
        }
        StartCoroutine(Delete(coinAnim));
    }

    IEnumerator Delete(GameObject obj)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(obj);
    }
}