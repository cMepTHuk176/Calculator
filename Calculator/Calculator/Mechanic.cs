using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class Mechanic
    {
        public static double AverageSpeed(double S, double t)
        {
            return S / t;
        }

        public static double EquidistantMotion(double x0, double Vx, double t)
        {
            return x0 + (Vx * t);
        }

        public static double Acceleration_projection(double V0x, double Vx, double t)
        {
            return (Vx - V0x) / t;
        }

        public static double Moving_with_equidistant_motion(double V0x, double t, double a)
        {
            return (V0x * t) + (a * t * t / 2);
        }

        public static double equidistant_motion_point(double x0, double V0x, double t, double a)
        {
            return x0 + (V0x * t) + (a * t * t / 2);
        }

        public static double CenterAcceleration_w(double w, double radius)
        {
            return w * w * radius;
        }

        public static double CenterAcceleration_v(double v, double radius)
        {
            return v * v / radius;
        }

        public static double LinearVelocity(double radius, double period)
        {
            return 2 * Math.PI * radius / period;
        }

        public static double AccelerateMotion(double x0, double V0, double a, double t)
        {
            return x0 + (V0 * t) + (a * t * t / 2);
        }
    }


}