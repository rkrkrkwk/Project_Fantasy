using System;
using UnityEngine;

public class StatCurveData : ScriptableObject
{
    [Serializable]
    public struct statCurve
    {
        public double weight;
        public double stat;
    }
}
