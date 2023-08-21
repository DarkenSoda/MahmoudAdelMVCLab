namespace MahmoudAdelMVCLab01.Models;

public class ProductBL {
    private static readonly List<Product> productList = new List<Product>();
    static ProductBL() {
        productList.Add(new Product() {
            Id = 1,
            Name = "IPhone",
            Price = 15000,
            Image = "IPhone.png"
        });
        productList.Add(new Product() {
            Id = 2,
            Name = "Laptop",
            Description = "A Modern High-End Laptop with great specs.",
            Price = 7500,
            Image = "Laptop.jpg"
        });
        productList.Add(new Product() {
            Id = 3,
            Name = "Router",
            Description = "Router to connect to the Internet.",
            Price = 600,
            Image = "Router.jpg"
        });
    }

    public static IEnumerable<Product> GetAll() {
        return productList.OrderBy(prod => prod.Id);
    }

    public static Product GetByID(int id) {
        return productList.Where(prod => prod.Id == id).First();
    }
}
