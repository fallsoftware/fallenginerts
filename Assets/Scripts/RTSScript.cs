using UnityEngine;
using System.Collections;

public class RTSScript : MonoBehaviour {
    public int ScrollArea = 5;
    public float ScrollSpeed = 500;
    public float DragSpeed = 20;
    public float MinZoom = 150;
    public float MaxZoom = 30;
    public float ZoomSensitivity = 10000000;
    public GameObject Battleground;
    private Bounds _maxSize;
    private Camera _camera;

    void Start() {
        this._maxSize = this.Battleground.GetComponent<Collider2D>().bounds;
        this._camera = this.GetComponent<Camera>();
    }

    void Update() {
        float mPosX = Input.mousePosition.x;
        float mPosY = Input.mousePosition.y;

        // Mouse position
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


        // Keyboard
        this.transform.Translate(
            new Vector3(Input.GetAxis("Horizontal") 
                * this.ScrollSpeed * Time.deltaTime, 
            Input.GetAxis("Vertical") 
                * this.ScrollSpeed * Time.deltaTime, 0));

        // Holding down option / Middle mouse button
        if ((Input.GetKey("left alt") 
            || Input.GetKey("right alt")) 
            || Input.GetMouseButton(2)) {
            this.transform.Translate(-new Vector3(
                Input.GetAxis("Mouse X") * this.DragSpeed, 
                Input.GetAxis("Mouse Y") * this.DragSpeed, 0));
        }

        // Checking bounds
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

        // Checking zoom
        float newZoom = this._camera.orthographicSize;

        if (Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")) > 0) {
            int a = 1;
        }

        newZoom += Input.GetAxis("Mouse ScrollWheel") * this.ZoomSensitivity;
        newZoom = Mathf.Clamp(newZoom, this.MaxZoom, this.MinZoom);
        this._camera.orthographicSize = newZoom;
    }
}