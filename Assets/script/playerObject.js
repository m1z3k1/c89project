class playerObject extends unit{
var horizontalVec : float;
var verticalVec : float;


    function Start () {
        super();
        SetSpeed(5);
    }

    function Update () {
        var horizontalVec = Input.GetAxisRaw("Horizontal");
        var verticalVec = Input.GetAxisRaw("Vertical");
        SetVec(new Vector3(horizontalVec,0,verticalVec));
        
        super();
    }
}

