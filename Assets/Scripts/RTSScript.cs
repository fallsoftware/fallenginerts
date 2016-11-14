using UnityEngine;
using System.Collections;
/// <summary>
/// camera that work for RTS-based games
/// </summary>
public class RTSScript : MonoBehaviour {
    public int ScrollArea = 5; // used to translate the camera when moving the
    // mouse
    public float ScrollSpeed = 500;
    public float DragSpeed = 20;
    public float MinZoom = 150;
    public float MaxZoom = 70;
    public float ZoomSensitivity = 10000000;
    public GameObject Battleground;
    private Bounds _maxSize;
    private Camera _camera;

    void Start() {
        this._maxSize = this.Battleground.GetComponent<Collider2D>().bounds;
        this._camera = this.GetComponent<Camera>();
    }

    /// <summary>
    /// the camera's updated at each frame
    /// </summary>
    void Update() {
        float mPosX = Input.mousePosition.x;
        float mPosY = Input.mousePosition.y;

        // Mouse position will move the camera
        if (mPosX < this.ScrollArea) {
            this.transform.Translate(
                Vector3.right * -this.ScrollSpeed * Time.deltaTime);
        }

        if (mPosX >= Screen.width - this.ScrollArea) {
            this.transform.Translate(
                Vector3.right * this.ScrollSpeed * Time.deltaTime);
        }

        if (mPosY < this.ScrollArea) {
            this.transform.Translate(
                Vector3.up * -this.ScrollSpeed * Time.deltaTime);
        }

        if (mPosY >= Screen.height - this.ScrollArea) {
            this.transform.Translate(
                Vector3.up * this.ScrollSpeed * Time.deltaTime);
        }


        // Keyboard will be able to move it as well with the arrow keys
        this.transform.Translate(
            new Vector3(Input.GetAxis("Horizontal") 
                * this.ScrollSpeed * Time.deltaTime, 
            Input.GetAxis("Vertical") 
                * this.ScrollSpeed * Time.deltaTime, 0));

        // Holding down option / Middle mouse button too
        if ((Input.GetKey("left alt") 
            || Input.GetKey("right alt")) 
            || Input.GetMouseButton(2)) {
            this.transform.Translate(-new Vector3(
                Input.GetAxis("Mouse X") * this.DragSpeed, 
                Input.GetAxis("Mouse Y") * this.DragSpeed, 0));
        }

        // Checking bounds to prevent the camera from going away the battle
        float x;
        float y;
        float z = this.transform.position.z;
        float height = 2f * this._camera.orthographicSize;
        float width = height * this._camera.aspect;

        height = height/2;
        width = width/2;

        if (this.transform.position.x - width < this._maxSize.min.x) {
            x = this._maxSize.min.x + width;
        } else {
            x = this.transform.position.x;
        }

        if (x + width > this._maxSize.max.x) {
            x = this._maxSize.max.x - width;
        }

        if (this.transform.position.y - height < this._maxSize.min.y) {
            y = this._maxSize.min.y + height;
        } else {
            y = this.transform.position.y;
        }

        if (y + height > this._maxSize.max.y) {
            y = this._maxSize.max.y - height;
        }

        this.transform.position = new Vector3(x, y, z);

        // Checking the zoom level
        float newZoom = this._camera.orthographicSize;
        newZoom += -Input.GetAxis("Mouse ScrollWheel") * this.ZoomSensitivity;
        newZoom = Mathf.Clamp(newZoom, this.MaxZoom, this.MinZoom);
        this._camera.orthographicSize = newZoom;
    }
}