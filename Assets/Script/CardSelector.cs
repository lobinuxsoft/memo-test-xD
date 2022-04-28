using System.Threading.Tasks;
using UnityEngine;

public class CardSelector : MonoBehaviour
{
    private async void OnMouseUp()
    {
        await RotateCard();
        CardComparator.Instance.SetCard(this);
    }

    public async Task RotateCard()
    {
        Quaternion targetRot = Quaternion.LookRotation(-transform.forward);
        float lerp = 0;
        
        while (Quaternion.Angle(transform.rotation, targetRot) > 0.001f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, lerp);
            lerp += Time.deltaTime;
            await Task.Yield();
        }
        
        transform.rotation = targetRot;
    }
}