using UnityEngine;
using TMPro;
using System.Collections;


namespace StocksTask.UILayer
{
    public class MessageDisplayer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI messagePrefab;
        [SerializeField] private float lifetime = 5f;
        public void DisplayMessage(string text)
        {
            TextMeshProUGUI msg = Instantiate(messagePrefab, transform);
            msg.text = text;
            StartCoroutine(DestroyMessageRoutine(msg));
        }

        IEnumerator DestroyMessageRoutine(TextMeshProUGUI msg)
        {
            yield return new WaitForSeconds(lifetime);
            Destroy(msg.gameObject);
        }
    }
}


