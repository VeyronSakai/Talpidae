using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public interface IInputProvider {
    void OnAwake();
    IObservable<Vector2> MoveDirection { get; }

    // Input要素が他にあったら、ここに足す
    // IReadOnlyReactiveProperty<bool> SetHogeBottunDown { get; }
}