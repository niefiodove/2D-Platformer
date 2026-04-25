using UnityEngine;

public class Stalker : MonoBehaviour
{
    private Mover _mover;
    private CharacterRotater _characterRotater;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _characterRotater = GetComponent<CharacterRotater>();
    }

    public void Chase(Transform player)
    {
        float directionX = Mathf.Sign(player.position.x - transform.position.x);
        _mover.Move(directionX, player);
        _characterRotater.FlipSprite(directionX);
    }
}