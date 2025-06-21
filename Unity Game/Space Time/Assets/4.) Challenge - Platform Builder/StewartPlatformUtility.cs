using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StewartPlatformUtility : MonoBehaviour
{
    [SerializeField] float platformSideLength; // top triangle side length
    [SerializeField] float platformPointSpacing; // top spacing between points
    [SerializeField] float baseSideLength; // bottom triangle side length
    [SerializeField] float basePointSpacing; // bottom spacing between points

    //[SerializeField] TextMeshProUGUI[] basePointFields;
    //[SerializeField] TextMeshProUGUI[] platformPointFields;
    //[SerializeField] TMP_InputField inputFieldSideLength;
    //[SerializeField] TMP_InputField inputFiedPointSpacing;

    void Start()
    {
        CalcualteTopPoints(platformSideLength, platformPointSpacing);
        CalcualteBasePoints(baseSideLength, basePointSpacing);
    }
    //public void DoCalc()
    //{
    //    float t1, t2;
    //    string s1 = inputFieldSideLength.text;
    //    string s2 = inputFiedPointSpacing.text;

    //    bool b1 = float.TryParse(s1, out t1);
    //    bool b2 = float.TryParse(s2, out t2);

    //    if (b1 && b2) 
    //    {
    //        //CalcualtePlatformPoints(74.15f, 12.9f, 96.5f, 37.5f);
    //       Vector3[] points = CalcualteBasePoints(t1, t2);// 96.5f, 37.5f);

    //        for (int i = 0; i < basePointFields.Length; i++)
    //        {
    //            basePointFields[i].text = points[i].ToString("F2");
    //        }
    //    }
    //    else
    //    {
    //        for (int i = 0; i < basePointFields.Length; i++)
    //        {
    //            basePointFields[i].text = "--------";
    //        }
    //    }

    //}

    //void CalcualteAllPoints(float topLength, float topSpacing, float botLength, float botSpacing)
    //{
    //    float topCircumradius, topAngle;
    //    UtilityLib.GetRadiusAndOffset(topLength, topSpacing, out topCircumradius, out topAngle);
    //    Vector3[] platformPoints = UtilityLib.CalculatePlatformPoints(topCircumradius, topAngle);
    //    UtilityLib.ConvertV3ToCppSyntax(platformPoints, "platformPoints");

    //    float botCircumradius, botAngle;
    //    UtilityLib.GetRadiusAndOffset(botLength, botSpacing, out botCircumradius, out botAngle);
    //    Vector3[] basePoints = UtilityLib.CalculateBasePoints(botCircumradius, botAngle);
    //    UtilityLib.ConvertV3ToCppSyntax(basePoints, "basePoints");

    //    UtilityLib.ConvertV3ToCSharpSyntax(platformPoints, "platformPoints");
    //    UtilityLib.ConvertV3ToCSharpSyntax(basePoints, "basePoints");
    //}

    public Vector3[] CalcualteBasePoints(float sideLength, float spacing)
    {
        float circumradius, angle;
        UtilityLib.GetRadiusAndOffset(sideLength, spacing, out circumradius, out angle);
        Vector3[] points = UtilityLib.CalculateBasePoints(circumradius, angle);
        UtilityLib.ConvertV3ToCppSyntax(points, "Base Points");
        UtilityLib.ConvertV3ToCSharpSyntax(points, "Base Points");
        return points;
    }

    public Vector3[] CalcualteTopPoints(float sideLength, float spacing)
    {
        float circumradius, angle;
        UtilityLib.GetRadiusAndOffset(sideLength, spacing, out circumradius, out angle);
        Vector3[] points = UtilityLib.CalculatePlatformPoints(circumradius, angle);
        UtilityLib.ConvertV3ToCppSyntax(points, "Platform Points");
        UtilityLib.ConvertV3ToCSharpSyntax(points, "Platform Points");
        return points;
    }
}
