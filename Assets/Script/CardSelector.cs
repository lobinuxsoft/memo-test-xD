using UnityEngine;

public class CardSelector : MonoBehaviour
{
    private void OnMouseUp()
    {
        RotateCard();
        CardComparator.instance.SetCard(this);
    }

    public void RotateCard()
    {
        transform.rotation = Quaternion.LookRotation(-transform.forward);
    }
}
