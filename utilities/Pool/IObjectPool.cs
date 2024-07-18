namespace GodotExtensionatorStarter {
    public interface IObjectPool<T> {

        T Recycle();
        void ReturnObject(PoolModelWrapper<T> value);
        void Clear();

    }
}
