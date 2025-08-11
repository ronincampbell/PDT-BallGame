using UnityEngine;

public class Paddle : MonoBehaviour
{
    private HingeJoint2D hinge;
    private JointMotor2D motor;

    public float hitSpeed = 1000f;
    public float returnSpeed = 800f;
    public KeyCode activationKey = KeyCode.LeftArrow;

    private float lowerLimit;
    private float upperLimit;

    [SerializeField] bool isLeftPaddle;

    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
        hinge.useMotor = true;
        hinge.useLimits = true;

        lowerLimit = hinge.limits.min;
        upperLimit = hinge.limits.max;

        motor = hinge.motor;
        motor.motorSpeed = 0;
        motor.maxMotorTorque = 10000; 
        hinge.motor = motor;
    }

    void Update()
    {
        float currentAngle = hinge.jointAngle;

        if (isLeftPaddle)
        {
            if (Input.GetKey(activationKey))
            {
                if (currentAngle > lowerLimit)
                {
                    motor.motorSpeed = -hitSpeed;
                }
                else
                {
                    motor.motorSpeed = 0;
                }
            }
            else
            {
                if (currentAngle < upperLimit)
                {
                    motor.motorSpeed = returnSpeed;
                }
                else
                {
                    motor.motorSpeed = 0;
                }
            }
        }

        else if (!isLeftPaddle)
        {
            if (Input.GetKey(activationKey))
            {
                if (currentAngle < upperLimit)
                { 
                    motor.motorSpeed = hitSpeed;
                }
                else
                {
                    motor.motorSpeed = 0;
                }
            }
            else
            {
                if (currentAngle > lowerLimit)
                {
                    motor.motorSpeed = -returnSpeed;
                }
                else
                {
                    motor.motorSpeed = 0;
                }
            }
        }

        hinge.motor = motor;
    }
}
