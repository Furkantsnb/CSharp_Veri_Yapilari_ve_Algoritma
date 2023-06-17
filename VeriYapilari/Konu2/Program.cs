using System.ComponentModel.Design;

namespace LinkedList3
    //Linked list başa ekle, sona ekleme  ve yazma metotları
    //linked List baştan silme, sondan silme metotları
    //Linked List Araya elman ekleme metotları
    //Linked List Aradan eleman silme metodu 
    //Eleman sayısını göster metodu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Listemiz tekYonluList = new Listemiz();
            int sayi, indis;
            int secim = Menu();
          
            while(secim != 0)
            {
                switch(secim)
                {
                    case 1: Console.Write("sayı : "); sayi = int.Parse(Console.ReadLine());
                        tekYonluList.basaEkle(sayi);
                        break;
                    case 2:
                        Console.Write("sayı : "); sayi = int.Parse(Console.ReadLine());
                        tekYonluList.sonaEkle(sayi);
                        break;
                    case 3:
                        Console.Write("Indis : "); indis = int.Parse(Console.ReadLine());
                        Console.Write("sayı : "); sayi = int.Parse(Console.ReadLine());
                        tekYonluList.arayaEkle(indis,sayi);
                        break;
                    case 4:
                        tekYonluList.bastanSil();
                        break;
                    case 5:
                        tekYonluList.sondanSil();
                        break;
                    case 6:
                        Console.Write("Indis : "); indis = int.Parse(Console.ReadLine());
                        tekYonluList.aradannSil(indis);
                        break;
                    case 7:
                        tekYonluList.elamanSayısı();
                        break;
                    case 0: break;
                    default: Console.WriteLine("hatalı seçim yaptınız..."); break;
                
                    
        
                }
                Console.Clear();
                tekYonluList.yazdir();
                secim= Menu();  
            }
            Console.WriteLine("Programdan çıkılıyor....");
          

            Console.ReadLine();
        }

        private static int Menu()
        {
            int secim;
            Console.WriteLine("\n1- basa ekle");
            Console.WriteLine("2- sona ekle");
            Console.WriteLine("3- Araya ekleme");
            Console.WriteLine("4- bastan sil");
            Console.WriteLine("5- sondan sil");
            Console.WriteLine("6- aradan sil");
            Console.WriteLine("7- Eleman sayısı");
            Console.WriteLine("0- programı");
            Console.Write("seçiminiz : ");

            secim = int.Parse(Console.ReadLine());
            return secim;
        }
    }


    // Node sınıfı
    class Node
    {
        public int data;
       public  Node next;
        public Node(int data)
        {
            this.data = data;
            next = null;
        }

    }


    //Liste sınıfı
    class  Listemiz
    {
        public Node head;
        public Listemiz()
        {
            head = null;
        }



        public void sonaEkle(int data) // sona ekleme metodu
        {
            Node eleman = new Node(data);

            if(head ==null) 
            { 
                head = eleman;
                Console.WriteLine("Liste oluşturuldu, ilk düğüm eklendi");
            }
            else
            {
                Node temp = head;
                while(temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = eleman;
                Console.WriteLine("Son eleman eklendi");
            }
        }



        public void basaEkle(int data) // basa ekleme metodu
        {
            Node eleman = new Node( data);
            if (head==null)
            {
                head = eleman;
                Console.WriteLine("Liste oluşturuldu, ilk düğüm eklendi");

            }
            else
            {
                eleman.next = head; // listenin başına eleman eklendi
                head = eleman; // eklenen düğümün ismini head
                Console.WriteLine("başa eleman eklendi");

            }
        }

        public void arayaEkle(int indis, int data) // araya ekleme metodu
        {
            Node eleman = new Node(data);
            bool sonuc = false;

            if (head == null && indis ==0)
            {
                head = eleman;
                Console.WriteLine("Ekleme yapıldı...");
                sonuc = true;
            }
            else if (indis == 0)
            {
                basaEkle(data);
                sonuc = true;
            }
            else
            {
                int i = 0;
                Node temp = head;
                Node temp2 = temp;

                while (temp.next != null)
                {
                    if (i == indis)
                    {
                        sonuc = true;
                        temp2.next = eleman;
                        eleman.next= temp;
                        Console.WriteLine("Araya eklendi");
                        i++;
                        break;

                    }
                    temp2 = temp;
                    temp = temp.next;
                    i++; 
                }

                if (i == indis)
                {
                    sonuc = true;
                    temp2.next = eleman;
                    eleman.next = temp;
                    Console.WriteLine("Araya eklendi");
                }
               
               
            }
            if(sonuc == false)
            {
                Console.WriteLine("Hatalı indis seçimi yaptınız...");
            }
        }




        public void bastanSil()  //Baştan silme metodu
        {
            if(head== null)
            {
                Console.WriteLine("Liste oluşturuldu");
            }

            else
            {
                head = head.next; // baştan düğüm sildik
                Console.WriteLine("baştan eleman silindi...");
            }
        }


        public void sondanSil()  //sondan silme metodu
        {
            if (head == null)
            {
                Console.WriteLine("Liste oluşturuldu");
            }
            else if (head.next == null)
            {
                head = null;
                Console.WriteLine("Listedeki kalan son düğümde silindi...");
            }
            else
            {
                Node temp = head;
                Node temp2 = temp;

                while(temp.next != null)
                {
                    temp2 = temp;
                    temp = temp.next;
                }
                temp2.next = null;
                Console.WriteLine("Sondaki düğüm silindi ");
            }

        }



        public void aradannSil(int indis)  //Aradan silme metodu
        {
            bool sonuc = false;

            if (head == null)
            {
                sonuc= true;
                Console.WriteLine("Liste boş");
            }

            else if (head.next == null && indis==0)
            {
                sonuc = true;
                head = null;
                Console.WriteLine("Listedeki kalan son elemanı da sildiniz...");
            }

            else if (head.next != null && indis == 0)
            {
                sonuc = true;
                bastanSil();
                Console.WriteLine("Eleman sildiniz...");
            }
            else
            {
                int i = 0;
                Node temp = head;
                Node temp2 = temp;

                while (temp.next != null)
                {
                    if(i == indis)
                    {
                        sonuc = true;
                        temp2.next = temp.next;
                        Console.WriteLine("aradan eleman silindi");
                        i++;
                        break;

                    }
                    temp2 = temp;
                    temp = temp.next;
                    i++;
                }
                if (i == indis)
                {
                    //sondanSil();
                    sonuc = true;
                    temp2.next = null;
                    Console.WriteLine("aradan eleman silindi");
                    i++;
                    

                }

            }
            if (sonuc == false)
                Console.WriteLine("Hatalı bir indis  giriş yaptınız");

        }



        public void yazdir() // Listeyi yazdırma metodu
        {
            Node temp = head;
            if (head == null)
            {
                Console.WriteLine("Liste boş");
            }
            else
            {
                Console.Write("baş -->");
                while (temp.next != null)
                {
                    Console.Write(temp.data + "-->");
                    temp = temp.next;
                }
                Console.Write(temp.data + "son");
            }
        }


        public void elamanSayısı() // Listeyi yazdırma metodu
        {
            int sayac = 0;
            if (head == null)
            {
                Console.WriteLine("Eleman sayısı : "+ sayac);
            }
            else
            {
                 Node temp = head;
              ;
                while (temp.next != null)
                {
                    sayac++;
                    temp = temp.next;

                }
                sayac++;
                Console.WriteLine("Eleman sayısı : " + sayac);

            }
        }
    }

}