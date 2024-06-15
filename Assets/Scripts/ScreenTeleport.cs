using UnityEngine;

public class ScreenTeleport : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Collider2D coll;

    new Camera camera;

    void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        Physics2D.SyncTransforms();

        Rect rect = CameraUtility.GetOrtographicRect(camera);
        Rect objectRect = GetObjectRect();
        bool isInCameraSpace = rect.Overlaps(objectRect);

        // Vector3 position = transform.position;
        // bool isInCameraSpace =
        //    position.x > rect.xMin && position.x < rect.xMax &&
        //    position.y > rect.yMin && position.y < rect.yMax;

        if (!isInCameraSpace)
        {
            transform.position += GetTeleportOffset(rect, objectRect);
        }
    }

    Vector3 GetTeleportOffset(Rect cameraRect, Rect objectRect)
    {
        float ox = 0;
        float oy = 0;

        if (objectRect.xMax < cameraRect.xMin)
            ox = 1;
        else if (objectRect.xMin > cameraRect.xMax)
            ox = -1;
        if (objectRect.yMax < cameraRect.yMin)
            oy = 1;
        else if (objectRect.yMin > cameraRect.yMax)
            oy = -1;

        Vector3 teleportOffset = new(ox, oy);

        teleportOffset.x *= cameraRect.size.x + objectRect.size.x;
        teleportOffset.y *= cameraRect.size.y + objectRect.size.y;

        return teleportOffset;
    }

    Rect GetObjectRect()
    {
        Bounds bounds;
        if (coll != null)
            bounds = coll.bounds;
        else if (sr != null)
            bounds = sr.bounds;
        else
            bounds = new Bounds(transform.position, Vector3.zero);
         
        return new Rect(bounds.min, bounds.size);
    }

    void OnDrawGizmos()
    {
        Rect r = GetObjectRect();
        Gizmos.DrawWireCube(r.center, r.size);
    }
}
