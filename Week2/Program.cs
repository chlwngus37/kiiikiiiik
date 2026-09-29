using System;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        GameManager game = new GameManager();
        game.Start();
    }
}


class GameManager
{
    private Player player;
    private Enemy enemy;


    public void Start()
    {
        CreateCharacters();

        while (!player.IsDead() && !enemy.IsDead())
        {
            ShowStatus();

            int choice = InputMenu();

            if (choice == 1)
            {
                player.Attack(enemy);
            }
            else if (choice == 2)
            {
                player.ShowInventory();
            }

            if (!enemy.IsDead())
            {
                enemy.Attack(player);
            }
        }

        ShowResult();
    }


    private void CreateCharacters()
    {
        player = new Player("용사");
        enemy = new Enemy("슬라임");

        player.AddItem(new Item("검"));
        player.AddItem(new Item("체력 포션"));
    }


    private void ShowStatus()
    {
        Console.WriteLine();

        player.ShowStatus();
        enemy.ShowStatus();

        Console.WriteLine();
    }


    private int InputMenu()
    {
        Console.WriteLine("1. 공격");
        Console.WriteLine("2. 인벤토리");
        Console.Write("선택 : ");

        return int.Parse(Console.ReadLine());
    }


    private void ShowResult()
    {
        if (player.IsDead())
        {
            Console.WriteLine("패배했습니다.");
        }
        else
        {
            Console.WriteLine("승리했습니다!");
        }
    }
}


class Character
{
    public string Name { get; protected set; }
    public int HP { get; protected set; }
    public int AttackPower { get; protected set; }


    public Character(string name, int hp, int attackPower)
    {
        Name = name;
        HP = hp;
        AttackPower = attackPower;
    }


    public void Attack(Character target)
    {
        Console.WriteLine($"{Name}이(가) {target.Name}을 공격했습니다.");
        target.TakeDamage(AttackPower);
    }


    public void TakeDamage(int damage)
    {
        HP -= damage;

        if (HP < 0)
        {
            HP = 0;
        }

        Console.WriteLine($"{Name}이(가) {damage} 데미지를 받았습니다.");
    }


    public bool IsDead()
    {
        return HP <= 0;
    }


    public void ShowStatus()
    {
        Console.WriteLine($"{Name} HP : {HP}");
    }
}


class Player : Character
{
    private List<Item> inventory;


    public Player(string name)
        : base(name, 100, 20)
    {
        inventory = new List<Item>();
    }


    public void AddItem(Item item)
    {
        inventory.Add(item);
    }


    public void ShowInventory()
    {
        Console.WriteLine("===== 인벤토리 =====");

        foreach (Item item in inventory)
        {
            Console.WriteLine(item.Name);
        }
    }
}


class Enemy : Character
{
    public Enemy(string name)
        : base(name, 80, 15)
    {

    }
}


class Item
{
    public string Name { get; private set; }


    public Item(string name)
    {
        Name = name;
    }
}
