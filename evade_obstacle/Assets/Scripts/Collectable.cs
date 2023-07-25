using UnityEngine;

public class Collectable : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.gameObject.CompareTag("Player"))
      {
         GameManager.Instance.Score();
         Destroy(gameObject);
      }
   }
}
