namespace CSLGaming.API.DTO
{
    public class ProductPostDTO
    {
        // Detta skall motsvara all information vi behöver beronde på funktion (Get, Post, osv...)

        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public double Rating { get; set; }
        public int ReleaseYear { get; set; }

    }

    public class ProductPutDTO : ProductPostDTO // Put = Uppdatera existerande entitet
    {
        public int Id { get; set; }
    }

    public class ProductGetDTO : ProductPutDTO
    {
        // public List<FilterGetDTO>? Filters { get; set; } - Kommer användas för att kunna få med allt, beroende på filter
    }

    public class ProductSmallGetDTO : ProductPutDTO 
    {
        // Denna kommer användas för att hämta allt, utan filter o grejjer
    }

}
