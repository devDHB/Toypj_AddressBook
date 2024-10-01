using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AddressBook
{
    class Contact
    {
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Memo { get; set; }
    }

    class Program
    {
        static List<Contact> contacts = new List<Contact>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("１。追加");
                Console.WriteLine("２。リスト確認");
                Console.WriteLine("３。検索");
                Console.WriteLine("４。削除");
                Console.WriteLine("５。閉じる");
                Console.Write("希望番号を入力 : ");
                string select = Console.ReadLine();

                switch (select)
                {
                    case "1":
                        AddContact();
                        break;
                    case "2":
                        ViewContacts();
                        break;
                    case "3":
                        SearchContacts();
                        break;
                    case "4":
                        DeleteContact();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("失敗しました");
                        break;
                }
            }
        }

        static void AddContact()
        {
            Console.Write("お名前 : ");
            string name = Console.ReadLine();

            string phoneNumber;
            int phone;
            while (true)
            {
                Console.Write("電話番号 : ");
                phoneNumber = Console.ReadLine();

                //　TryParse - intに型変換　
                if (int.TryParse(phoneNumber, out phone))
                {
                    //　変換が成功する場合
                    break;
                }
                else
                {
                    // 変換が失敗する場合
                    Console.WriteLine("数字を入力してください");
                }
            }

            Console.Write("Email : ");
            string email = Console.ReadLine();

            Console.Write("メモ : ");
            string memo = Console.ReadLine();


            contacts.Add(new Contact { Name = name, PhoneNumber = phone, Email = email,  Memo = memo });
            Console.WriteLine("追加完了");
        }

        static void ViewContacts()
        {
            Console.WriteLine("コンタクトリスト");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"姓名 : {contact.Name} | 電話番号 : {contact.PhoneNumber} | Email : {contact.Email} | メモ : {contact.Memo}");
            }
        }

        static void SearchContacts()
        {
            Console.Write("姓名で検索 : ");
            string searchName = Console.ReadLine();
            var result = contacts.FindAll(c => c.Name.Contains(searchName));

            if (result.Count > 0)
            {
                foreach (var contact in result)
                {
                    Console.WriteLine($"姓名 : {contact.Name} | 電話番号 : {contact.PhoneNumber} | Email : {contact.Email} | メモ : {contact.Memo}");
                }
            }
            else
            {
                Console.WriteLine("存在ありません");
            }
        }

        static void DeleteContact()
        {
            Console.Write("削除する姓名を入力してください");
            string DeleteName = Console.ReadLine();
            contacts.RemoveAll(c => c.Name == DeleteName);
            Console.WriteLine("削除完了");
        }
    }
}