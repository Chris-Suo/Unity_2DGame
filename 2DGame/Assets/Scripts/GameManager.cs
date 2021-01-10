using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        SetCollision();
    }

    private void SetCollision()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("player"), LayerMask.NameToLayer("player_bullet"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("enemy"), LayerMask.NameToLayer("enemy_bullet"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("enemy"), LayerMask.NameToLayer("enemy"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("enemy_bullet"), LayerMask.NameToLayer("enemy_bullet"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("player_bullet"), LayerMask.NameToLayer("enemy_bullet"));
    }
}
