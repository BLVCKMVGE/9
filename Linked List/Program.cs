using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures {
	class Node {
		public int value;
		public Node next = null;
		public Node previous = null;

		public Node(Node previous, Node next, int value) {
			this.previous = previous;
			this.next = next;
			this.value = value;
		}

		public Node() {}
	}

	class LinkedList {
		Node head = null;
		Node tail = null;

		public LinkedList() {}

		public void Add(int value) {
			if (head == null){
				head = tail = new Node(null, null, value);
			} else {
				Node toAdd = new Node(tail, null, value);
				tail.next = toAdd;
				tail = toAdd;
			}
		}

		public Node Find(int value) {
			Node pointer = head;
			while (pointer != null) {
				if (pointer.value == value)
					return pointer;
				pointer = pointer.next;
			}
			return null;
		}

		public bool Delete(int value) {
			Node toDelete = Find(value);
			if (toDelete == null)
				return false;

			if (toDelete == head)
				head = toDelete.next;
			if (toDelete == tail)
				tail = toDelete.previous;

			if (toDelete.previous != null)
				toDelete.previous.next = toDelete.next;

			if (toDelete.next != null)
				toDelete.next.previous = toDelete.previous;

			return true;
		}

		public void Print() {
			Node pointer = head;
			while (pointer != null) {
				Console.Write("{0} ", pointer.value);
				pointer = pointer.next;
			}
			Console.WriteLine();
		}
	}
}

namespace Linked_List
{
	class Program
	{
		static void Main(string[] args)
		{
            Console.WriteLine("Введите n");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Ошибка ввода! Введите целое число n");
            }
            Structures.LinkedList list = new Structures.LinkedList();
			for (int i = 1; i <= n; i++)
				list.Add(i);
			list.Print();

			string console;
            Console.WriteLine("Функции программы:");
            Console.WriteLine("Введите info получения доп. сведений");
            Console.WriteLine("Введите done - для выхода из программы");
            while ((console = Console.ReadLine()) != "done")
            {
				string[] temp = console.Split(' ');
                switch (temp[0]) {
					case "info": {
						Console.WriteLine("Введите find <value> - для поиска элемента в списке.");
						Console.WriteLine("Введите delete <value> - для удаление элемента из списка.");
						Console.WriteLine("Введите print - для печати списка");
                        Console.WriteLine("Введите done - для выхода из программы");
                    } break;

					case "find": {
						if (list.Find(Convert.ToInt32(temp[1])) == null)
							Console.WriteLine("Такой элемент не найден");
						else
							Console.WriteLine("Элемент найден");
					} break;

					case "delete": {
						if (list.Delete(Convert.ToInt32(temp[1])))
							Console.WriteLine("Элемент удалён");
						else
							Console.WriteLine("Элемент не найден");
					} break;

					case "print": {
						list.Print();
					} break;
				}
			}

		}
    }
}
