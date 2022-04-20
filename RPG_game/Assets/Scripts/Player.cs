using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
		private BoxCollider2D boxCollider;
		private Vector3 moveDelta;   // per quale motivo non si usa un Vector2?
		private RaycastHit2D hit;   // player collider
    // Start is called before the first frame update
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // FixedUpdate è chiamata 50 volte al secondo , usata per quello che riguarda la fisica
    private void FixedUpdate()  
    {
        

				float x = Input.GetAxisRaw("Horizontal");  // movimento del personaggio
				float y = Input.GetAxisRaw("Vertical");
				
				// Reset moveDelta
				moveDelta = new Vector3(x, y, 0);

				// direzione del player
				if (moveDelta.x > 0) 
					transform.localScale = Vector3.one;
				else if (moveDelta.x < 0)
					transform.localScale = new Vector3(-1, 1, 1); 
			
				hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

				if (hit.collider == null) // il player può muoversi
				{
					// movimento
                    transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
				 }
				
				hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

				if (hit.collider == null) // il player può muoversi
				{
					// movimento
					transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
				 }
			

    }
}