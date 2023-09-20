using System.Collections.Generic;
using System.Runtime.InteropServices;
using Beverage_shop;

namespace Beverage_shop{
    internal class Program
    {
        private static void Main(string[] args)
        {

            List<Drink> drinks = new List<Drink>();
            List<OrderItem> orders = new List<OrderItem>();
            //新增飲料品項
            AddNewDrink(drinks);

            //顯示飲料清單
            DisplayDrinkMenu(drinks);

            //訂購飲料
            PlaceOrder(orders, drinks);

            //計算售價
            Calculateprice(orders, drinks);



        }

        private static void Calculateprice(List<OrderItem> myorders, List<Drink> mydrinks) {
            double total = 0.0;
            string message = "";
            double sellPrice = 0.0;
            foreach (var order in myorders) total += order.SubTotal;
            if (total >= 500) {
                message = "訂購滿500元以上打8折";
                sellPrice = total * 0.8;
            } else if (total >= 300){
                message = "訂購滿500元以上打85折";
                sellPrice = total * 0.85;
            } else if (total >= 20){
                message = "訂購滿500元以上打9折";
                sellPrice = total * 0.9;
            } else {
                message = "訂購未滿200不打折";
                sellPrice = total ;
            }

            Console.WriteLine();
            Console.WriteLine($"您總訂購{myorders.Count}項飲料，總計{total}元。{message}，合計需付款{sellPrice}元");
            Console.WriteLine("訂購完成，案任意鍵結束..");
            Console.ReadLine();

        }

        private static void PlaceOrder(List<OrderItem> myorders, List<Drink> mydrinks){
            Console.WriteLine("開始訂購飲料，按下X鍵後離開...");
            string s;
            int index, quantity, subtotal;
            while (true){
                Console.Write("請輸入您所需要的品項編號?");
                s = Console.ReadLine();
                if (s == "x") break;
                else index = Convert.ToInt32(s);
                Console.Write("請輸入你要的杯數?");
                s = Console.ReadLine();
                if (s == "x") break;
                else quantity = Convert.ToInt32(s);
                Drink drink = mydrinks[index];
                subtotal = drink.Price * quantity;
                Console.Write($"您訂購{drink.Name}{drink.Size}{quantity}杯，每杯{drink.Price}元，小記{subtotal}元");
                myorders.Add(new OrderItem() { Index = index, Quantity = quantity,SubTotal = subtotal});
                Console.Write("\n");
            }
          
        }

        private static void DisplayDrinkMenu(List<Drink> drinks)
        {
            Console.WriteLine("飲料清單");
            Console.WriteLine("----------------------");
            int j = 1;
            Console.WriteLine(String.Format("{0,-4}{1,-5}{2,-5}{3,-5}","編號","品名","大小","價格"));
            
            for (int i = 0; i < drinks.Count; i++)
            {
                Console.WriteLine($"{j,-6}{drinks[i].Name,-5}{drinks[i].Size,-5}{drinks[i].Price,5:C2}");
                j++;
            }
            Console.WriteLine("----------------------");
        }

        private static void AddNewDrink(List<Drink> mydrnks)
        {
            mydrnks.Add(new Drink() { Name = "紅茶", Size = "小杯", Price = 30 });
            mydrnks.Add(new Drink() { Name = "紅茶", Size = "大杯", Price = 50 });
            mydrnks.Add(new Drink() { Name = "綠茶", Size = "小杯", Price = 50 });
            mydrnks.Add(new Drink() { Name = "綠茶", Size = "大杯", Price = 70 });
            mydrnks.Add(new Drink() { Name = "咖啡", Size = "小杯", Price = 30 });
            mydrnks.Add(new Drink() { Name = "咖啡", Size = "大杯", Price = 50 });
        }
    }
}
