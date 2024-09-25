using System;
using System.Runtime.CompilerServices;

class Itembox
{

    public string Name { get; set; }
    public int Stat { get; set; }
    public string Explain { get; set; }
    public int Price { get; set; }

    public Itembox( string name, int stat, string explain, int price)
    { 
        this.Name = name;
        this.Stat = stat;
        this.Explain = explain;
        this.Price = price;

    }

    public Itembox()
    {
        Console.WriteLine($"{Name} |공격력 + {Stat} | {Explain} {Price}");

    }


    

}

class Character
{
    public int Level { get; set; }
    public int BaseStr { get; set; }
    public int BaseDef { get; set; }
    public int Hp { get; set; }
    public int Gold { get; set; }
    

    public Character()
    {
        Level = 1;
        BaseStr = 10;
        BaseDef = 5;
        Hp = 100;
        Gold = 1500;
        
    }

}
class Program
{
    static Character player = new Character();
   

    public List<Itembox> items = new List<Itembox>()
    {
        new Itembox("수련자 갑옷",5,"수련에 도움을 주는 갑옷입니다.",1000)


    };
    static void ShowStatus()
    {
            
            Console.WriteLine("[상태 보기]");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine("\nLV.\t"+ player.Level);
            Console.WriteLine("임찬: \t" + "(무직)");
            Console.WriteLine("공격력:\t"+ player.BaseStr);
            Console.WriteLine("방어력:\t"+ player.BaseDef);
            Console.WriteLine("체력: \t"+ player.Hp);
            Console.WriteLine("골드: \t"+player.Gold);
            Console.WriteLine("\n0.나가기");
            Console.Write("\n원하시는 행동을 입력해주세요: \n >>");

            string Return = Console.ReadLine();                
            Console.Clear();

        if (Return == "0")
            {
                StartGame();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.\n");                
                ShowStatus();             
            }
       
    }
    
    static void ShowInventory()
    {
            
            Console.WriteLine("[인벤토리]");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("\n[아이템 목록]");
            Console.WriteLine("\n1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.Write("\n원하시는 행동을 입력해주세요: \n >>");
            string choice = Console.ReadLine();
            Console.Clear();

            if (choice == "0")
            {
                StartGame();
            }
            else if (choice == "1")
            { 
               Inventory();
            }
            else
            {
            Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.\n");
            ShowInventory();
            }

    }
    static void Inventory()
    {

     
        Console.WriteLine("[인벤토리] - 장착관리");
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
        Console.WriteLine("\n[아이템 목록]");
        Console.WriteLine();
        Console.WriteLine("0. 나가기");
        Console.Write("\n원하시는 행동을 입력해주세요: \n >>");
        string choice = Console.ReadLine();
        Console.Clear();

        if (choice == "0")
        {
            ShowInventory();
        }
        else
        {
            Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.\n");
            Inventory();
        }

    }

    static void ShowShop()
    {
            
            Console.WriteLine("[상점]");

            Console.WriteLine("\n[보유골드]");
            Console.WriteLine(player.Gold+"원");
            Console.WriteLine("\n[아이템 목록]");
       
            Console.WriteLine("\n1. 아이템 구매");
            Console.WriteLine("0. 나가기");
            Console.Write("\n원하시는 행동을 입력해주세요: \n >>");
            string choice = Console.ReadLine();
            Console.Clear(); 

            if (choice == "0")
            {
                StartGame();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.\n");
                ShowShop();
            }
        
    }

    static void Rest()
    {
        Console.WriteLine("[휴식하기]");
        Console.WriteLine("500 G 를 내면 체력을 회복할 수 있습니다."+"\t(보유골드 : "+player.Gold+"원)");
        Console.WriteLine("\n1. 휴식하기");
        Console.WriteLine("0. 나가기");
        Console.Write("\n원하시는 행동을 입력해주세요: \n >>");
        string choice = Console.ReadLine();
        Console.Clear();
        if (choice == "0")
        {
            StartGame();
        }
        else if (choice == "1") 
        {
            if (player.Gold >= 500)
            {
                Console.WriteLine("HP가 회복되었습니다\n");
                player.Gold -= 500;
                player.Hp += 100;
                Rest();
            }
            else 
            {
                Console.WriteLine("Gold가 부족합니다\n");
                Rest();
            }
        }
        else
        {
            Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.\n");
            Rest();
        }

    }
    static void StartGame()
    {
          Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 휴식하기\n");
            Console.Write("원하시는 행동을 입력해주세요: \n >>");
            string choice = Console.ReadLine();          
            Console.Clear(); 

            if (choice == "1")
            {
                ShowStatus();
            }
            else if (choice == "2")
            {
                ShowInventory();
            }
            else if (choice == "3")
            {
                ShowShop();
            }
            else if (choice == "4")
            {
                Rest();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.\n");
                StartGame();
        }
        
    }

    static void Main(string[] args)
    {
        StartGame();
    }
}