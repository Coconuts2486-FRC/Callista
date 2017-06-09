using System;
using System.Collections.Generic;
using System.Linq;
using WPILib;
using WPILib.SmartDashboard;
using WPILib.Extras.NavX;
namespace Robot2
{
    public class Robot2 : SampleRobot
    {
        DigitalInput button;
        public static AHRS NavX;
        public static Jaguar frontLeft;
        public static Jaguar frontRight;
        public static Jaguar backLeft;
        public static Jaguar backRight;
        Joystick joystick;
        Jaguar shooter;
        Jaguar turrent;
        Jaguar collector;
        double TH;
        double MT;
      //  turningpid turn;

        public Robot2()
        {
            button = new DigitalInput(0);
            NavX = new AHRS(SPI.Port.MXP);
            frontLeft = new Jaguar(4);
            frontRight = new Jaguar(2);
            backLeft = new Jaguar(5);
            backRight = new Jaguar(3);
            joystick = new Joystick(0);
            frontRight.Inverted = true;
            backRight.Inverted = true;
            shooter = new Jaguar(1);
            turrent = new Jaguar(0);
            collector = new Jaguar(6);
           // turn = new turningpid();
        }

        protected override void RobotInit()
        {
        }

        // This autonomous (along with the sendable chooser above) shows how to select between
        // different autonomous modes using the dashboard. The senable chooser code works with
        // the Java SmartDashboard. If you prefer the LabVIEW Dashboard, remove all the chooser
        // code an uncomment the GetString code to get the uto name from the text box below
        // the gyro.
        // You can add additional auto modes by adding additional comparisons to the if-else
        // structure below with additional strings. If using the SendableChooser
        // be sure to add them to the chooser code above as well.
        //public bool OnTarget()
        //{
        //    return ((Math.Abs(turn.Controller.Get() - turn.Controller.Setpoint)) < 5);
        //}
        //public override void Autonomous()
        //{
        //    while (IsAutonomous && IsEnabled)
        //    {
        //        turn.Controller.Setpoint = 40;
        //        turn.Controller.Enable();
        //        SmartDashboard.PutBoolean("strings", OnTarget());
        //        if (OnTarget() == true)
        //        {
        //            turn.Controller.Disable();
        //            SmartDashboard.PutBoolean("strings", true);
        //            while (button.Get() == false)
        //            {
        //                SmartDashboard.PutBoolean("string", true);
        //                Drive(.4);
        //            }
        //            SmartDashboard.PutBoolean("string", false);
        //            Drive(0);
        //        }

        //        //if (NavX.GetAngle() <= 90)
        //        //{
        //        //    Turn(.4, -.4);
        //        //}
        //        //else if (NavX.GetAngle() >= 95)
        //        //{
        //        //    Turn(-.4, .4);
        //        //}
        //        //else
        //        //{
        //        //    Turn(0, 0);
        //        //}
        //        SmartDashboard.PutNumber("Angle", NavX.GetAngle());
        //    }
        //    //Drive(-0.2);
        //    //Timer.Delay(3);
        //    //Turn(0.2, -0.2);
        //    //Timer.Delay(5);
        //}
        //public void Drive(double speed)
        //{
        //    frontLeft.Set(-speed);
        //    frontRight.Set(-speed);
        //    backLeft.Set(-speed);
        //    backRight.Set(-speed);
        //}
        //public void Turn(double right, double left)
        //{
        //    frontLeft.Set(left);
        //    frontRight.Set(right);
        //    backLeft.Set(left);
        //    backRight.Set(right);
        //}
        ///**
        //* Runs the motors with arcade steering.
        //*/
        public override void OperatorControl()
        {
            while (IsOperatorControl == true && IsEnabled)
            {
                /*
                    frontLeft.Set(joystick.GetRawAxis(1));
                    frontRight.Set(joystick.GetRawAxis(1));
                    backLeft.Set(joystick.GetRawAxis(1));
                    backRight.Set(joystick.GetRawAxis(1));
               */

                if (joystick.GetRawButton(7) == true)

                    collector.Set(.5);

                else if (joystick.GetRawButton(8))
                    collector.Set(-.8);
                else collector.Set(0.00);




                switch (joystick.GetPOV(0))
                {
                    case 0:
                        turrent.Set(0.00);
                        break;
                    case 3:
                        turrent.Set(.5);
                        break;
                    case 7:
                        turrent.Set(-.5);
                        break;
                    default:
                        turrent.Set(0);
                        break;
                }


                TH = joystick.GetRawAxis(3);
                MT = (((TH - 1) * (.30 - 0)) / (1 - 1));
                shooter.Set(MT);
                frontRight.Set(((joystick.GetRawAxis(0)) + joystick.GetRawAxis(1) + joystick.GetRawAxis(2)));
                frontLeft.Set(((-joystick.GetRawAxis(0)) + joystick.GetRawAxis(1) - joystick.GetRawAxis(2)));
                backRight.Set(((-joystick.GetRawAxis(0)) + joystick.GetRawAxis(1) + joystick.GetRawAxis(2)));
                backLeft.Set(((joystick.GetRawAxis(0)) + joystick.GetRawAxis(1) - joystick.GetRawAxis(2)));
            }
        }

        /**
         * Runs during test mode
         */
        public override void Test()
        {
        }
    }
}
