using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matris1GrupBulma
{
	class Block
	{
		public int data;
		public Block next;
		public Block(int veri)
		{
			this.data = veri;
		}
	}

	class Program
	{

		Block front = null;
		Block rear = null;
		public void Enquene(int a, int b, int[,] Matris)
		{
			Block b1 = new Block(Matris[a, b]);
			if (front == null) front = rear = b1;
			else
			{
				rear.next = b1;
				rear = b1;
			}
		}

		public int Dequene(int a, int b, int[,] QueneDizi)//a eşit i b eşit j
		{
			int data = front.data;
			if (front == null) return -1;
			else front = front.next;
			adet++;
			return data;
		}
		static int adet = 0;
		static int temp = 0;
		static int etrafıAra(int[,] M, int i, int j, int Satir, int Sütun, int adet)
		{

			if (i < 0 || j < 0 || i > (Satir - 1) || j > (Sütun - 1) || M[i, j] != 1) return adet;

			if (M[i, j] == 1)
			{

				Program Değer = new Program();
				Değer.Enquene(i, j, M);
				Değer.Dequene(i, j, M); M[i, j] = 0;

				//konumun üst sırası
				etrafıAra(M, i + 1, j, Satir, Sütun, adet); etrafıAra(M, i - 1, j, Satir, Sütun, adet); etrafıAra(M, i, j + 1, Satir, Sütun, adet);
				//konumun sağı ve solu
				etrafıAra(M, i, j - 1, Satir, Sütun, adet); etrafıAra(M, i + 1, j + 1, Satir, Sütun, adet);
				//konumun alt sırası
				etrafıAra(M, i - 1, j - 1, Satir, Sütun, adet); etrafıAra(M, i + 1, j - 1, Satir, Sütun, adet); etrafıAra(M, i - 1, j + 1, Satir, Sütun, adet);


			}
			return temp;
		}

		static void Main()
		{

			int[,] x = new int[10, 10];
			//------------------1.grup------------------------------------
			x[1, 4] = 1; x[2, 4] = 1; x[2, 5] = 1; x[4, 4] = 1; x[3, 3] = 1;
			x[5, 5] = 1; x[6, 4] = 1; x[7, 5] = 1; x[7, 6] = 1; x[7, 7] = 1;
			x[7, 8] = 1; x[7, 9] = 1; x[5, 8] = 1; x[6, 8] = 1; x[4, 9] = 1;
			//------------------2.grup------------------------------------
			x[9, 5] = 1; x[9, 6] = 1; x[9, 7] = 1;
			////------------------3.grup------------------------------------
			x[5, 0] = 1; x[7, 0] = 1; x[6, 1] = 1; x[7, 1] = 1; x[8, 1] = 1; x[9, 1] = 1;
			////------------------4.grup------------------------------------
			x[8, 3] = 1; x[9, 3] = 1;

			for (int i = 0; i < x.GetLength(0); i++)
			{
				for (int j = 0; j < x.GetLength(1); j++)
				{
					if (x[i, j] == 1)
					{
						if (adet > temp)
						{ temp = adet; adet = 0; }
						adet++;

						etrafıAra(x, i, j, x.GetLength(0), x.GetLength(1), adet);
					}
				}
			}
			temp -= 1;
			Console.WriteLine(" en büyük grubun 1 sayısı:" + temp);

			Console.ReadLine();
		}
	}
}