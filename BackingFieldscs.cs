using System;

internal class MyContext : DbContext
{
    public DbSet<Product> Products { get; set; }
}

#region BackingField
public class Product
{
    private string _validatedName;

    public int Id { get; set; }

    [BackingField(nameof(_validatedName))]
    public string Name
    {
        get { return _validatedName; }
    }

    public void SetName(string name)
    {
       

        _validatedName = name;
    }
}
#endregion
