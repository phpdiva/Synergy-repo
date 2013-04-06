using UnityEngine;
using System.Collections;

public class Bounce : InteractableObject
{
    public float bouncePower = 10.0f;
    // Use this for initialization

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Player")
        {
            Player player = collider.gameObject.GetComponent<Player>();

            if (player.velocity.y < -1 && isCorrupt == false)          //is it minus? Has to be minus one to ignore the small fluxtuating - number.
            {
				player.transform.position = new Vector3(player.transform.position.x, this.transform.position.y+1, player.transform.position.z);
                player.velocity.y = bouncePower;
                player.shroomJump = true;
                Corrupt();
            }
        }
    }

    public override void TriggerObject(Player player)
    {

    }
}
