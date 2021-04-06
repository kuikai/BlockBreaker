using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SliderDrag : MonoBehaviour, IPointerUpHandler
{
   [SerializeField] int AudioMixNumber;
    public void OnPointerUp(PointerEventData eventData)
    {

        switch (AudioMixNumber)
        {
            case 1:
                FindObjectOfType<Optiones>().PlayAudioVolumeidecater(AudioMixNumber);
                break;
            case 2:
                FindObjectOfType<Optiones>().PlayAudioVolumeidecater(AudioMixNumber);
                break;
            case 3:
                FindObjectOfType<Optiones>().PlayAudioVolumeidecater(AudioMixNumber);
                break;
            case 4:
                FindObjectOfType<Optiones>().PlayAudioVolumeidecater(AudioMixNumber);
                break;
            case 5:
                FindObjectOfType<Optiones>().PlayAudioVolumeidecater(AudioMixNumber);
                break;
            case 6:
                FindObjectOfType<Optiones>().PlayAudioVolumeidecater(AudioMixNumber);
                break;

        }
     
    }
}
