using Ardalis.SmartEnum;

namespace MoviesNsi.Domain.Enums;
public abstract class Category : SmartEnum<Category>
{
    public static Category SciFi = new SciFiCategory();
    public static Category Thriller = new ThrillerCategory();
    
    public abstract string Description { get; }

    public abstract bool Transparent(Category category);
    
    public Category(string name, int value) : base(name, value)
    {
    }
    
    private sealed class SciFiCategory : Category
    {
        public SciFiCategory() : base(nameof(SciFi), 1)
        {
            
        }

        public override string Description => "Naucna fantastika";
        public override bool Transparent(Category category)
        {
            throw new NotImplementedException();
        }
    }
    
    private sealed class ThrillerCategory : Category
    {
        public ThrillerCategory() : base(nameof(Thriller), 2)
        {
            
        }

        public override string Description => "Triler";
        public override bool Transparent(Category category)
        {
            throw new NotImplementedException();
        }
    }
}