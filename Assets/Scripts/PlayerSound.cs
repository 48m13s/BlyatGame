using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour {

//ссылочная переменная для аудио-файла
public AudioClip footsteps;

//публичная функция, получим доступ к ней из аниматора
public void FootStepsAudio () {
//воспроизвести заданный звук на позиции крысы
AudioSource.PlayClipAtPoint (footsteps, transform.position);
}

public AudioClip footsteps2;
//публичная функция, получим доступ к ней из аниматора
public void FootStepsAudio2 () {
//воспроизвести заданный звук на позиции крысы
AudioSource.PlayClipAtPoint (footsteps2, transform.position);
}

public AudioClip hit;
//публичная функция, получим доступ к ней из аниматора
public void Hit () {
//воспроизвести заданный звук на позиции крысы
AudioSource.PlayClipAtPoint (hit, transform.position);
}

public AudioClip jump;
//публичная функция, получим доступ к ней из аниматора
public void Jump () {
//воспроизвести заданный звук на позиции крысы
AudioSource.PlayClipAtPoint (jump, transform.position);
}

public AudioClip jump2;
//запустится если было касание другого Collider2D
void OnCollisionEnter2D (Collision2D coll) {
//проверка тэга на тэг "Ground"
if (coll.gameObject.tag == "Ground") {
//воспроизвести заданный звук на позиции крысы
AudioSource.PlayClipAtPoint (jump2, transform.position);
}
}

}
