using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterEnd : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            Destroy(other.gameObject);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().UI.GetComponent<UIManager>().LifeUpdate(-1);
        }
    }

}
