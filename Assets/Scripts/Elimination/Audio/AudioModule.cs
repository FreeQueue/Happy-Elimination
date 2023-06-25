#nullable enable

using KFramework;
using UnityEngine;

namespace Elimination.Audio
{
	public class AudioModule : IModule
	{
		private readonly AudioSource _mainAudioSource; // 主音频源
		private readonly AudioSource _audioSource; // 音频源

		public AudioModule() {
			var audioHelper = new GameObject(nameof(AudioModule));
			_mainAudioSource =audioHelper.AddComponent<AudioSource>();
			_audioSource =audioHelper.AddComponent<AudioSource>();
		}

		// 播放不循环音频
		public void PlayOneShot(string audioName) {
			AudioClip clip = LoadAudio(audioName);
			if (clip != null) {
				_audioSource.PlayOneShot(clip);
			} else {
				Debug.LogWarningFormat("Audio clip {0} not found in Resources folder.", audioName);
			}
		}

		// 循环播放主音频
		public void PlayMainAudio(string audioName) {
			AudioClip clip = LoadAudio(audioName);
			if (clip != null) {
				_mainAudioSource.clip = clip;
				_mainAudioSource.loop = true;
				_mainAudioSource.Play();
			} else {
				Debug.LogWarningFormat("Audio clip {0} not found in Resources folder.", audioName);
			}
		}

		public AudioClip LoadAudio(string name) {
			return Resources.Load<AudioClip>($"Audios/{name}");
		}
	}
}
