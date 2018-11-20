namespace Rest4NetCore
{
    public interface IRestContract<T>
    {
        void FromModel(T model);
        T GetModel();
    }
}
