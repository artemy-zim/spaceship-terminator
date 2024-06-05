using UnityEngine;

public class PlayerShipTracker : MonoBehaviour
{
    [SerializeField] private PlayerShip _ship;
    [SerializeField] private float _offsetX;

    private void LateUpdate()
    {
        ChangePosition();
    }

    private void ChangePosition()
    {
        float positionX = _ship.transform.position.x + _offsetX;
        
        transform.position = new Vector2(positionX, transform.position.y);
    }
}
