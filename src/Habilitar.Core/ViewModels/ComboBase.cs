namespace Habilitar.Core.ViewModels
{
    public record ComboBase<T>
    {
        public T Value { get; init; }
        public string Text { get; init; }
    }
}
