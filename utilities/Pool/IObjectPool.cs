namespace GodotExtensionatorStarter {
    public interface IObjectPool<T> {

        T Recycle();
        void ReturnObject(PoolModelWrapper<T> value);
        void ReturnObject(T value);
        void Clear();
        void DisposeObject(PoolModelWrapper<T> obj);
        void DisposeObject(T obj);

    }
}
