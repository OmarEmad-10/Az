﻿using UnityEngine;
using UnityEditor;
using System.Collections;


[CustomEditor(typeof(EnglishTracingBook.Path))]
public class PathEditor : Editor {

	public override void OnInspectorGUI ()
	{
		EnglishTracingBook.Path path = (EnglishTracingBook.Path)target;//get the target

		EditorGUILayout.Separator ();
		path.fillMethod = (EnglishTracingBook.Path.FillMethod)EditorGUILayout.EnumPopup ("Fill Method",path.fillMethod);
		if (path.fillMethod == EnglishTracingBook.Path.FillMethod.Linear) {
			path.type = (EnglishTracingBook.Path.ShapeType)EditorGUILayout.EnumPopup ("Type", path.type);
			path.offset = EditorGUILayout.Slider ("Angle Offset", path.offset, -360, 360);
			path.flip = EditorGUILayout.Toggle ("Flip Direction", path.flip);
		} else if (path.fillMethod == EnglishTracingBook.Path.FillMethod.Radial) {
			path.quarterRestriction = EditorGUILayout.Toggle ("Quarter Restriction",path.quarterRestriction) ;
			path.radialAngleOffset = EditorGUILayout.Slider ("Radial Offset",path.radialAngleOffset,-360,360) ;
		}

		path.completeOffset = EditorGUILayout.Slider ("Complete Offset", path.completeOffset,0,1);
		path.firstNumber = EditorGUILayout.ObjectField ("First Number",path.firstNumber, typeof(Transform)) as Transform;
		if (path.fillMethod != EnglishTracingBook.Path.FillMethod.Point) 
			path.secondNumber = EditorGUILayout.ObjectField ("Second Number",path.secondNumber, typeof(Transform)) as Transform;

	}
}	