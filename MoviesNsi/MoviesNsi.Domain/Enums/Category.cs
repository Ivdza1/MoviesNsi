using Ardalis.SmartEnum;

namespace MoviesNsi.Domain.Enums;
public abstract class Category : SmartEnum<Category>
{
    public static Category SciFi = new SciFiCategory();
    public static Category Thriller = new ThrillerCategory();
    public static Category Dystopia = new DystopiaCategory();
    public static Category Apocalyptic = new ApocalypticCategory();
    public abstract string Description { get; }
    
    public abstract List<Category> Subcategories { get; }
    
    
    public Category(string name, int value) : base(name, value)
    {
    }
    
    private sealed class SciFiCategory : Category
    {
        public SciFiCategory() : base(nameof(SciFi), 1)
        {
            
        }

        public override string Description => "Naucna fantastika";
        public override List<Category> Subcategories => new () { Dystopia, Apocalyptic };
    }
    
    private sealed class ThrillerCategory : Category
    {
        public ThrillerCategory() : base(nameof(Thriller), 2)
        {
            
        }

        public override string Description => "Triler";
        public override List<Category> Subcategories => new();
    }
    
    private sealed class DystopiaCategory : Category
    {
        public DystopiaCategory() : base(nameof(Dystopia), 3)
        {
            
        }

        public override string Description => "Dystopia";
        public override List<Category> Subcategories => new();
    }
    
    private sealed class ApocalypticCategory : Category
    {
        public ApocalypticCategory() : base(nameof(Apocalyptic), 4)
        {
            
        }

        public override string Description => "Apocalyptic";
        public override List<Category> Subcategories => new();
    }
}