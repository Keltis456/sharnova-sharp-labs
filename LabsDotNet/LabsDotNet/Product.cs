namespace LabsDotNet
{
    struct Product
    {
        public string Name;
        public string Date;
        public float Mass;
        public float Price;
        public string Supplier;
        public string ShelfLife;

        public Product(string Name, string Date, float Mass,
            float Price, string Supplier, string ShelfLife)
        {
            this.Name      = Name;
            this.Date      = Date;
            this.Mass      = Mass;
            this.Price     = Price;
            this.Supplier  = Supplier;
            this.ShelfLife = ShelfLife;
        }
    }
}