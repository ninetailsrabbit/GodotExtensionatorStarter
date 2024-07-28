using Extensionator;
using System;

namespace GodotExtensionatorStarter {
    public static class TorCurve {
        public static double Pinch(double value) => Pinch(value);
        public static float Pinch(float value) => (float)Math.Pow(value, 2) * (value < 0.5f ? -1 : 1);
        public static double Run(float x, float a = 0, float b = 0.5f, float c = 0) {
            c = Pinch(c);
            x = Math.Max(0, Math.Min(1, x));

            var s = Math.Exp(a);
            var s2 = 1f / (s + MathExtension.CommonEpsilon);
            var t = Math.Max(0, Math.Min(1, b));
            var u = c;

            var result = 0d;
            var c1 = 0d;
            var c2 = 0d;
            var c3 = 0d;

            if (x < t) {
                c1 = (t * x) / (x + s * (t - x) + MathExtension.CommonEpsilon);
                c2 = t - Math.Pow(1 / (t + MathExtension.CommonEpsilon), s2 - 1) * Math.Pow(Math.Abs(x - t), s2);
                c3 = Math.Pow(1 / (t + MathExtension.CommonEpsilon), s - 1) * Math.Pow(x, s);
            }
            else {
                c1 = (1 - t) * (x - 1) / (1 - x - s * (t - x) + MathExtension.CommonEpsilon) + 1;
                c2 = Math.Pow(1 / ((1 - t) + MathExtension.CommonEpsilon), s2 - 1) * Math.Pow(Math.Abs(x - t), s2) + t;
                c3 = 1 - Math.Pow(1 / ((1 - t) + MathExtension.CommonEpsilon), s - 1) * Math.Pow(1 - x, s);
            }

            if (u <= 0)
                result = (-u) * c2 + (1 + u) * c1;
            else
                result = (-u) * c3 + (1 - u) * c1;


            return result;
        }
    }
}
