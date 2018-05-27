using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol {
	public class BoxPress : MonoBehaviour {
		[SerializeField] AnimationCurve degreeCurve;
		private void OnMouseDown () {
			StopAllCoroutines();
			StartCoroutine(Rotate(360, 1));
		}

		IEnumerator Rotate (float degress, float time) {
			Quaternion startRotation = transform.rotation;
			float progress = 0;
			while(progress < 1) {
				progress += Time.deltaTime / time;
				yield return null;

				transform.rotation = Quaternion.Euler(startRotation.eulerAngles + Vector3.forward * degreeCurve.Evaluate(progress) * degress);
			}
			progress = 1;
			transform.rotation = startRotation;
		}
	}
}