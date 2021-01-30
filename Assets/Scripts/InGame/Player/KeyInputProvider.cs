using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class KeyInputProvider : MonoBehaviour, IInputProvider {
    private Subject<Vector2> _moveDirection = new Subject<Vector2> ();
    // private ReactiveProperty<bool> _hogeButtonDown = new ReactiveProperty<bool> ();

    public IObservable<Vector2> MoveDirection { get { return _moveDirection; } }
    // public IReadOnlyReactiveProperty<bool> AttackButtonDown { get { return _hogeButtonDown; } }

    public void OnAwake () {

        this.UpdateAsObservable ()
            .Select (_ => new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical")))
            .Subscribe (x => _moveDirection.OnNext (x))
            .AddTo (this.gameObject);

        // this.UpdateAsObservable ()
        //     .Select (_ => Input.GetKeyDown (KeyCode.Space))
        //     .DistinctUntilChanged ()
        //     .Subscribe (x => _hogeButtonDown.Value = x)
        //     .AddTo (this.gameObject);
    }
}