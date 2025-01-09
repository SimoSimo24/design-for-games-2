using UnityEngine;

public class Dragwire : MonoBehaviour
{
    public SpriteRenderer wireEnd;
    public GameObject Light;
    public GameObject lightOn;

    private Vector3 startPoint;
    private Vector3 startPosition;

    private bool isConnected = false; // Flag to check connection
    private Vector3 connectedPosition; // Stores the connected position

    // Static flags to track both wire connections
    private static bool wireplusConnected = false;
    private static bool wireminusConnected = false;

    void Start()
    {
        startPoint = transform.parent.position;
        startPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        // Mouse position to world point
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

        // Check for nearby connection points
        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, 0.25f);
        foreach (Collider2D collider in colliders)
        {
            // Make sure not my own collider
            if (collider.gameObject != gameObject)
            {
                // Update wire to the connection point position
                connectedPosition = collider.transform.position;
                UpdateWire(connectedPosition);

                // Check if the wires are the same
                if (transform.parent.name.Equals(collider.transform.parent.name))
                {
                    isConnected = true; // Mark as connected

                    // Set static flag based on wire name
                    if (transform.parent.name == "Wireplus")
                        wireplusConnected = true;
                    else if (transform.parent.name == "Wireminus")
                        wireminusConnected = true;

                    // Check if both wires are connected
                    if (wireplusConnected && wireminusConnected)
                        TurnOnLight();

                    // Finalize connection
                    collider.GetComponent<Dragwire>()?.Done();
                    Done();
                }
                return;
            }
        }

        // Update wire position while dragging
        UpdateWire(newPosition);
        isConnected = false; // Not connected during drag unless a valid connection is made
    }

    private void TurnOnLight()
    {
        // Turn on the light
        lightOn.SetActive(true);
        Debug.Log("Both wires connected! Light is on.");
    }

    void Done()
    {
        // Prevent further interaction
        Destroy(this);
    }

    private void OnMouseUp()
    {
        if (isConnected)
        {
            // If connected, lock the wire to the connected position
            UpdateWire(connectedPosition);
        }
        else
        {
            // If not connected, reset to the start position
            UpdateWire(startPosition);
        }
    }

    void UpdateWire(Vector3 newPosition)
    {
        // Update position
        transform.position = newPosition;

        // Update direction
        Vector3 direction = newPosition - startPoint;
        transform.right = direction * transform.lossyScale.x;

        // Update scale
        float dist = Vector2.Distance(startPoint, newPosition);
        wireEnd.size = new Vector2(dist, wireEnd.size.y);
    }
}
