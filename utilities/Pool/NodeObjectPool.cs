using Godot;
using GodotExtensionator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GodotExtensionatorStarter {
    public class NodeObjectPool<T> : IObjectPool<T> where T : Node {

        public int MaximumCapacity {
            get => _maximumCapacity;
            set { _maximumCapacity = Math.Max(2, value); }
        }
        public int PreAllocationSize {
            get => _preAllocationSize;
            set { _preAllocationSize = Math.Min(MaximumCapacity, value); }
        }

        public int FillPoolWhenCountBelow {
            get => _fillPoolWhenCountBelow;
            set { _fillPoolWhenCountBelow = Math.Clamp(value, 1, PreAllocationSize); }
        }

        public Queue<PoolModelWrapper<T>> Pool { get; set; } = default!;

        public event Action? FillRequest;

        private PackedScene PreparedPackedScene { get; set; } = null!;
        private int _maximumCapacity = 2;
        private int _preAllocationSize = 2;
        private int _fillPoolWhenCountBelow = 1;

        public NodeObjectPool(int maximumCapacity = 2, int preAllocationSize = 2, int fillPoolWhenCountBelow = 1) {
            MaximumCapacity = maximumCapacity;
            PreAllocationSize = preAllocationSize;
            FillPoolWhenCountBelow = fillPoolWhenCountBelow;

            Pool = new Queue<PoolModelWrapper<T>>();
            FillRequest += OnFillRequest;
        }

        public NodeObjectPool<T> PrepareScene(Func<PackedScene> callback) {
            PreparedPackedScene = callback?.Invoke();
            Clear();
            FillPool();

            return this;
        }

        public NodeObjectPool<T> ChangeMaximumCapacity(int capacity) {
            MaximumCapacity = capacity;

            return this;
        }

        public NodeObjectPool<T> ChangePreAllocationSize(int size) {
            PreAllocationSize = size;

            return this;
        }

        public NodeObjectPool<T> ChangeFillPoolWhenCountBelow(int amount) {
            FillPoolWhenCountBelow = amount;

            return this;
        }

        public T Recycle() {
            if (Pool.Count < FillPoolWhenCountBelow)
                FillRequest?.Invoke();

            if (Pool.Count == 0)
                Pool.Enqueue(new PoolModelWrapper<T>(PreparedPackedScene.Instantiate<T>(), this));

            var poolableObject = Pool.Dequeue().Unwrap();
            poolableObject.Enable();

            return poolableObject;
        }

        public void ReturnObject(T obj) {
            if (Pool.Where(wrapper => wrapper.Unwrap().Equals(obj)).First() is PoolModelWrapper<T> wrapper)
                ReturnObject(wrapper);
        }

        public void ReturnObject(PoolModelWrapper<T> obj) {
            if (Pool.Count < MaximumCapacity)
                Pool.Enqueue(obj);
        }

        public void DisposeObject(PoolModelWrapper<T> obj) {
            Pool.FirstOrDefault(obj.Equals)?.Dispose();
        }
        public void DisposeObject(T obj) {
            Pool.Where(wrapper => wrapper.Unwrap().Equals(obj)).First()?.Dispose();
        }

        public void Clear() {
            Pool.Clear();
        }

        private void FillPool(int? size = null) {
            size ??= PreAllocationSize;

            if (Pool.Count < MaximumCapacity) {
                size = Math.Min(MaximumCapacity - Pool.Count, (int)size);

                for (int i = 0; i < size; i++) {
                    Pool.Enqueue(new PoolModelWrapper<T>(PreparedPackedScene.Instantiate<T>(), this));
                }
            }
        }
        private void OnFillRequest() {
            FillPool(MaximumCapacity);
        }
    }
}
