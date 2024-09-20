using Staff;
using System.Net.Http.Headers;

namespace Domain
{
    public sealed class Shelf : IEquatable<Shelf>
    {
        private string name;

        public Shelf(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
        }

        public Guid Id { get; }
        public string Name
        {
            get => this.name;
            set
            {
                this.name = value.TrimOrNull() ?? throw new ArgumentNullException(nameof(value));
            }
        }

        public bool Equals(Shelf? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Name == other.Name;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Shelf);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public override string ToString() => $"Название полки {this.Name}";
    }
}
