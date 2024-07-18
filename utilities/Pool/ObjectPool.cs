using System;
using System.Collections.Generic;

namespace GodotExtensionatorStarter {
    /// <summary>
    /// Save memory & CPU cycles
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObjectPool<T> : IObjectPool<T> where T : new() {

        public required int MaximumCapacity {
            get => _maximumCapacity;
            set { _maximumCapacity = Math.Max(2, value); }
        }
        public required int PreAllocationSize {
            get => _preAllocationSize;
            set { _preAllocationSize = Math.Min(MaximumCapacity, value); }
        }

        public required int FillPoolWhenCountBelow {
            get => _fillPoolWhenCountBelow;
            set { _fillPoolWhenCountBelow = Math.Clamp(value, 1, PreAllocationSize); }
        }

        public Queue<PoolModelWrapper<T>> Pool { get; set; } = default!;

        public event Action? FillRequest;

        private int _maximumCapacity = 2;
        private int _preAllocationSize = 2;
        private int _fillPoolWhenCountBelow = 1;

        public ObjectPool(int maximumCapacity = 2, int preAllocationSize = 2, int fillPoolWhenCountBelow = 1) {
            MaximumCapacity = maximumCapacity;
            PreAllocationSize = preAllocationSize;
            FillPoolWhenCountBelow = fillPoolWhenCountBelow;

            Pool = new Queue<PoolModelWrapper<T>>();
            FillRequest += OnFillRequest;
            FillPool();
        }

        public ObjectPool<T> ChangeMaximumCapacity(int capacity) {
            MaximumCapacity = capacity;

            return this;
        }

        public ObjectPool<T> ChangePreAllocationSize(int size) {
            PreAllocationSize = size;

            return this;
        }

        public ObjectPool<T> ChangeFillPoolWhenCountBelow(int amount) {
            FillPoolWhenCountBelow = amount;

            return this;
        }

        public T Recycle() {
            if (Pool.Count < FillPoolWhenCountBelow)
                FillRequest?.Invoke();

            if (Pool.Count == 0)
                Pool.Enqueue(new PoolModelWrapper<T>(new T(), this));

            return Pool.Dequeue().Unwrap();
        }

        public void ReturnObject(PoolModelWrapper<T> obj) {
            if (Pool.Count < MaximumCapacity)
                Pool.Enqueue(obj);
        }

        public void Clear() {
            Pool.Clear();
        }

        private void FillPool(int? size = null) {
            size ??= PreAllocationSize;

            if (Pool.Count < MaximumCapacity) {
                size = Math.Min(MaximumCapacity - Pool.Count, (int)size);

                for (int i = 0; i < size; i++) {
                    Pool.Enqueue(new PoolModelWrapper<T>(new T(), this));
                }
            }
        }

        private void OnFillRequest() {
            FillPool(MaximumCapacity);
        }
    }
}
