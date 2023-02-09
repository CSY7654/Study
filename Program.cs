using System;

namespace textRPG
{
    class program
    {
        enum Classnum   // 플레이어 클래스 열거
        {
            None = 0,
            Knight = 1,
            Archor = 2,
            Mage = 3
        }

        enum Monsternum // 몬스터 종류 열거
        {
            None = 0,
            Rat = 1,
            Pig = 2,
            Slime = 3,

        }


        struct unit
        {
            public int maxhp;
            public int nowhp;
            public int atk;
        }


        static void player(Classnum choice, out unit status)
        {
            switch (choice)
            {
                case Classnum.Knight:
                    status.maxhp = 150;
                    status.nowhp = status.maxhp;
                    status.atk = 40;
                    break;
                case Classnum.Archor:
                    status.maxhp = 100;
                    status.nowhp = status.maxhp;
                    status.atk = 25;
                    break;
                case Classnum.Mage:
                    status.maxhp = 70;
                    status.nowhp = status.maxhp;
                    status.atk = 70;
                    break;
                default:
                    status.maxhp = 0;
                    status.nowhp = status.maxhp;
                    status.atk = 0;
                    break;
            }
        }

        static void createmonster(out unit status)
        {
            Random rand = new Random();
            int randMon = rand.Next(1, 4);
            switch (randMon)
            { 
                case (int)Monsternum.Rat:
                    Console.WriteLine("쥐가 나타남");
                    status.maxhp = 10;
                    status.nowhp= status.maxhp;
                    status.atk = 5;
                    break;
                case (int)Monsternum.Pig:
                    Console.WriteLine("돼지가 나타남");
                    status.maxhp = 50;
                    status.nowhp = status.maxhp;
                    status.atk = 8;
                    break;
                case (int)Monsternum.Slime:
                    Console.WriteLine("슬라임이 나타남");
                    status.maxhp = 200;
                    status.nowhp = status.maxhp;
                    status.atk = 15;
                    break;
                default :
                    status.maxhp = 0;
                    status.nowhp = status.maxhp;
                    status.atk = 0;
                    break;
            }
                
            
        }

        static Classnum selectClass()   // 클래스 선택 함수
        {

           Console.WriteLine("직업을 선택하세요.");
           Console.WriteLine("1. Knight");
           Console.WriteLine("2. Archor");
           Console.WriteLine("3. Mage");

            Classnum choice = Classnum.None; // 클래스 넘버 

            string pick = Console.ReadLine();   // 선택 입력

           switch (pick)   // 입력에 따른 클래스 선택
           {
               case "1":
                   choice = Classnum.Knight;
                   Console.WriteLine("Knight를 선택하셨습니다.");
                   break;
               case "2":
                   choice = Classnum.Archor;
                   Console.WriteLine("Archor를 선택하셨습니다.");
                   break;
               case "3":
                   choice = Classnum.Mage;
                   Console.WriteLine("Mage를 선택하셨습니다.");
                   break;
           }

            return choice;
        }

        static void Entergame(unit play)
        {
            while(true)
            {
                System.Console.WriteLine("게임에 접속했습니다.");
                System.Console.WriteLine("1. 던전이동");
                System.Console.WriteLine("2. 로비이동");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        EnterField(play);
                        break;
                    case "2":
                        return;
                }
            }

        }

        static void fight(ref unit play, ref unit monster)
        {
            while(true)
            {
                monster.nowhp -= play.atk;
                Console.WriteLine($"몬스터체력{monster.nowhp}");
                if(monster.nowhp <= 0)
                {
                    Console.WriteLine("플레이어 승리");
                    break;
                }

                play.nowhp -= monster.atk;
                Console.WriteLine($"플레이어체력{play.nowhp}");
                if (play.nowhp <= 0)
                {
                    Console.WriteLine("플레이어 패배");
                }
            }
        }
        static void EnterField(unit play)
        {
            System.Console.WriteLine("필드에 접속했습니다.");

            unit monster;
            createmonster(out monster);
            System.Console.WriteLine("1. 공격");
            System.Console.WriteLine("2. 도주");
            string input = System.Console.ReadLine();
            if (input == "1")
            {
                fight(ref play, ref monster);
            }       
            else if( input == "2")
            {
                Random rand = new Random();
                int randValue = rand.Next(1, 100);
                if (randValue <= 33)
                {
                    Console.WriteLine("도주 성공");
                    Entergame(play);
                }
                else
                {
                    Console.WriteLine("도주 실패");
                    fight(ref play, ref monster);
                }
            }
        }

        static void Main(string[] args)
        {
            while(true)
            {
                Classnum choice = selectClass();
                if (choice != Classnum.None)
                {
                    //캐릭터 생성
                    unit play;
                    player(choice, out play);

                    Entergame(play);
                }
            }
        }


    }
    
}