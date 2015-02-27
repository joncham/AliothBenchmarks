using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class TestRunner : MonoBehaviour
{
	class TestData
	{
		public string Name;
		public System.Action<string[]> Main;
		public string[] Args;
		public string Milliseconds;
	}

	List<TestData> tests;
	Stopwatch stopwatch;

	// Use this for initialization
	void Start ()
	{
		stopwatch = new Stopwatch ();
		tests = new List<TestData> ();
		tests.Add (new TestData() {Name = "NBody", Main=NBody.Main, Args=new[] {"50000000"}});
		tests.Add (new TestData() {Name = "FannkuchRedux", Main=FannkuchRedux.Main, Args=new[] {"12"}});
		//tests.Add (new TestData() {Name = "pidigits", Main=pidigits.Main, Args=new[] {"12"}});
		//tests.Add (new TestData() {Name = "Mandelbrot", Main=FannkuchRedux.Main, Args=new[] {"12"}});
		tests.Add (new TestData() {Name = "FastaRedux", Main=FastaRedux.Main, Args=new[] {"25000000"}});
		tests.Add (new TestData() {Name = "BinaryTrees", Main=BinaryTrees.Main, Args=new[] {"20"}});
		tests.Add (new TestData() {Name = "Fasta", Main=Fasta.Main, Args=new[] {"25000000"}});
		//tests.Add (new TestData() {Name = "revcomp", Main=revcomp.Main, Args=new[] {"25000000"}});
		tests.Add (new TestData() {Name = "SpectralNorm", Main=SpectralNorm.Main, Args=new[] {"5500"}});
		//tests.Add (new TestData() {Name = "regexdna", Main=SpectralNorm.Main, Args=new[] {"5500"}});
	}
	
	// Update is called once per frame
	void Update () {
		//NBody.Main (new string[] {"50000000"});
	}

	void OnGUI()
	{
		for (var i = 0; i < tests.Count; i++)
		{
			var test = tests [i];
			if (GUILayout.Button (test.Name)) {
				System.GC.Collect ();
				stopwatch.Reset ();
				stopwatch.Start ();
				test.Main (test.Args);
				stopwatch.Stop ();
				test.Milliseconds = "Ellapsed MS: " + stopwatch.ElapsedMilliseconds.ToString ();
			}
			GUILayout.Label (test.Milliseconds);
		}
	}
}
