namespace VeriYapilari
//Linked List ( Bağlı Listeler) giriş
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node n1 = new Node(10);
            Node n2 = new Node(20);

            n1.next = n2; // n1 in nextini n2 bağladık
            
            Console.WriteLine("n1. düğümünün değeri içindeki değer : "+n1.data);
            Console.WriteLine("n2. düğümünün değeri içindeki değer : " + n2.data);
            Console.WriteLine("n2. düğümüne n1 üzerinden gidersek değeri :  : " + n1.next.data);



            Console.ReadLine();
        }
    }
}