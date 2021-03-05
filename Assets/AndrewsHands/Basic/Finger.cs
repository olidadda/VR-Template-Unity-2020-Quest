public enum FingerType
{
    None,
    Thumb,
    Index,
    Middle,
    Ring,
    Pinky
}

public class Finger
{
    public FingerType fingerType = FingerType.None;

    public float current = 0;
    public float target = 0;

    public Finger(FingerType fingerType)
    {
        this.fingerType = fingerType; //constructor where we set the type

    }


}
