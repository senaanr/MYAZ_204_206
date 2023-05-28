using BHeapAppwithProducts;
using Newtonsoft.Json;
using PriorityQueue;
using System.Text;

Console.WriteLine("Hello, World!");
var products = GetProducts();
foreach (var product in products)
{
    Console.WriteLine(product.productName + " " + product.price);
}
Console.WriteLine("---------------------------------");
var topList = GetTopProducts(3);
foreach (var top in topList)
{
    Console.WriteLine(top.productName + " " + top.price);

}

/* Bu metod Products.json dosyasından ürünleri 
 * okuyarak size MaxHeap<Product> türünde bir nesne vermelidir.
*/
MaxHeap<Product> GetProducts()
{
    string json = File.ReadAllText("C:\\Users\\SenaNur\\source\\repos\\MYAZ204206\\Apps\\BHeapAppwithProducts\\Products.json", encoding: Encoding.UTF8);
    //Console.WriteLine(json);
    //List<Product> productList = JsonConvert.DeserializeObject<List<Product>>(json);

    //MaxHeap<Product> maxHeap = new MaxHeap<Product>();
    //foreach (Product product in productList)
    //{
    //    maxHeap.Add(product);
    //}

    //return maxHeap;

    var productList = JsonConvert.DeserializeObject<Dictionary<string, List<Product>>>(json);

    MaxHeap<Product> maxHeap = new MaxHeap<Product>();

    foreach (Product product in productList["Products"])
    {
        maxHeap.Add(product);
    }

    return maxHeap;
}

// n sayısı kadar en pahalı ürünleri veren metot
Product[] GetTopProducts(int n)
{
    MaxHeap<Product> products = GetProducts();

    if (n > products.Count)
    {
        n = products.Count;
    }

    Product[] topProducts = new Product[n];
    for (int i = 0; i < n; i++)
    {
        topProducts[i] = products.DeleteMinMax();
    }

    return topProducts;
}

