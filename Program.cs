using System.Collections.Generic;
using Beverage_shop;

namespace Beverage_shop{
    internal class Program
    {
        private static void Main(string[] args){
            List<Drink> drinks = new List<Drink>();

            drinks.Add(new Drink() { Name = "紅茶", Size = "小杯", Price = 30 });
            drinks.Add(new Drink() { Name = "紅茶", Size = "大杯", Price = 50 });
            drinks.Add(new Drink() { Name = "綠茶", Size = "小杯", Price = 50 });
            drinks.Add(new Drink() { Name = "綠茶", Size = "大杯", Price = 70 });
            drinks.Add(new Drink() { Name = "咖啡", Size = "小杯", Price = 30 });
            drinks.Add(new Drink() { Name = "咖啡", Size = "大杯", Price = 50 });

            for (int i = 0; i < drinks.Count; i++){
                Console.WriteLine($"{drinks[i].Name,-8}{drinks[i].Size,-6}{drinks[i].Price,4:C2}");
            }
        }
    }
}
