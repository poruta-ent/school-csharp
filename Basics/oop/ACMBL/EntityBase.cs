namespace ACMBL
{
    public enum EntityStateOption
    {
        Active,
        Deleted
    }

    public abstract class EntityBase
    {
        public EntityStateOption EntityState { get; set; }
        public bool IsValid => Validate();
        public bool HasChanges { get; set; }
        public bool IsNew { get; private set; }

        public abstract bool Validate();
    }
}