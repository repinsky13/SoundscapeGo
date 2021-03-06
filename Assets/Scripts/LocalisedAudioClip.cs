﻿using System;
using System;
using System.Threading;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using System.Net;
using System.Text;
using System.IO;
using System.Threading;
using Mapbox.Unity;
using Mapbox.Unity.Map;
using Mapbox.Utils;

public class LocalisedAudioClip {
	private AudioClip audioFile;
	private Vector3 unityLocation;

	public LocalisedAudioClip (AudioClip audioclip, Vector3 unityLocation) {
		this.audioFile = audioclip;
		this.unityLocation = unityLocation;
	}


	public static LocalisedAudioClip nullLocalisedAudioClip()
	{
		AudioClip nullaudio = AudioClip.Create("nullclip", 10, 1, 16000, false);
		Vector3 nullLocation = new Vector3(0, 0, 0);
		return new LocalisedAudioClip(nullaudio, nullLocation);
	}

	public AudioClip AudioFile {
		get  { return this.audioFile; }
	}

	public Vector3 UnityLocation {
		get  { return this.unityLocation; }
	}

}


