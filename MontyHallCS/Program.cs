using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHallCS
{
	class Program
	{
		// 試行回数
		const int Max = 10000000;
		const int OutputSpan = 1000000;
		// ドアの数
		const int DoorCount = 3;

		static readonly Random Rand = new Random();

		static void Main(string[] args)
		{
			// 徐々に正解の確率に収束する
			Console.WriteLine("選び直さない場合");
			{
				var hit = 0;
				for (var i = 1; i <= Max; ++i)
				{
					// ドアの初期化
					var	hitDoor = Rand.Next(DoorCount);
					// 選択したドア
					var selection = Rand.Next(DoorCount);
					if (selection == hitDoor)
						++hit;
					// 確率出力
					if (i % OutputSpan == 0)
						Console.WriteLine("HIT : count = {0}, win = {1}", i, (double)hit / i);
				}
			}
			Console.WriteLine("選び直す場合");
			{
				var hit = 0;
				for (int i = 1; i <= Max; ++i)
				{
					// ドアの初期化
					var hitDoor = Rand.Next(DoorCount);
					// 選択したドア
					var selection = Rand.Next(DoorCount);
					// 司会者の選択
					var	hostSelection = selection;
					while (hostSelection == selection || hostSelection == hitDoor)
						hostSelection = Rand.Next(DoorCount);
					// 選び直す
					var lastSelection = Enumerable.Range(0, DoorCount).SingleOrDefault(n => n != selection && n != hostSelection);
					if (lastSelection == hitDoor)
						++hit;
					// 確率出力
					if (i % OutputSpan == 0)
						Console.WriteLine("HIT : count = {0}, win = {1}", i, (double)hit / i);
				}
			}
			Console.WriteLine("[ENTER]");
			Console.ReadLine();
		}
	}
}
