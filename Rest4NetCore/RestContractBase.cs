namespace Rest4NetCore
{
    public abstract class RestContractBase<T> : IRestContract<T>
    {
        protected T Model { get; private set; }

        public virtual void FromModel(T model)
        {
            Model = model;
        }

        public T GetModel()
        {
            return Model;
        }
    }
}
