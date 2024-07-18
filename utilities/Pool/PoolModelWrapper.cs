using Godot;
using GodotExtensionator;
using System;

namespace GodotExtensionatorStarter {
    public class PoolModelWrapper<T>(T value, IObjectPool<T> pool) : IDisposable {

        private readonly T _value = value;
        private readonly IObjectPool<T> _currentPool = pool;

        public T Unwrap() => _value;

        public void Dispose() {
            if (_value is Node node)
                node.Disable();

            _currentPool.ReturnObject(this);
        }
    }
}
