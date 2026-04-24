using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeaLeafController : MonoBehaviour
{
    Rigidbody rb;
    XRGrabInteractable grab;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        grab = GetComponent<XRGrabInteractable>();

        grab.selectEntered.AddListener(OnGrab);
        grab.selectExited.AddListener(OnRelease);

        // 🌱 初始：在树上
        SetTreeState();
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        // ✋ 延迟一帧，让XR先改完
        StartCoroutine(ForceGrabState());
    }

    System.Collections.IEnumerator ForceGrabState()
    {
        yield return null; // 等XR执行完

        rb.useGravity = false;
        rb.isKinematic = false;
    }

    void OnRelease(SelectExitEventArgs args)
    {
        StartCoroutine(ForceDropState());
    }

    System.Collections.IEnumerator ForceDropState()
    {
        yield return null;

        rb.useGravity = true;
        rb.isKinematic = false;
    }

    void SetTreeState()
    {
        rb.useGravity = false;
        rb.isKinematic = true;
    }
}