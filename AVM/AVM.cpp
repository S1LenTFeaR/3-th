#include <iostream>
#include <cmath> 
#include <clocale> 
#define PI 3.14159265

using namespace std;

void main()
{
	setlocale(LC_ALL, "Russian");
	while(true)
	{ 
		int y = 0; //год
		int m = 0; //мес
		int dy, dm = 0;
		int check, i = 1;
		cout << "Введите год: ";
		cin >> y;
		cout << "Введите месяц: ";
		cin >> m;
		_asm
		{
			//Проверка, был ли введен m > 12
			cmp		m, 12
			jg		my_exit
		my_begin:
			//Проверка на количество дней в году
			//check = (y / 4) * 4;
			mov		eax, y
			sar		eax, 2 //сдвиг вправо
			shl		eax, 2 //сдвиг влево
			mov		check, eax
			//Сравниваем, если y != check, то число не кратно 4
			//Если кратно, то 366 дней в году, иначе 365
			mov		eax, check
			cmp		eax, y
			jne		label365
		label366:
			mov		dy, 366
			jmp		label366end
		label365:
			mov		dy, 365
		//Проверяем, введен ли месяц, в котором 31 день
		label366end:
			cmp		m, 1
			je		label31
			cmp		m, 3
			je		label31
			cmp		m, 5
			je		label31
			cmp		m, 7
			je		label31
			cmp		m, 8
			je		label31
			cmp		m, 10
			je		label31
			cmp		m, 12
			jne		label30
		label31:
			mov		dm, 31
			jmp		my_exit
		//Проверяем, введен ли месяц, в котором 30 дней
		label30:
			cmp		m, 4
			je		label30a
			cmp		m, 6
			je		label30a
			cmp		m, 9
			je		label30a
			cmp		m, 11
			jne		label29
		label30a:
			mov		dm, 30
			jmp		my_exit
		//Проверяем, введен ли месяц, в котором 29 дней
		//29 дней при условии, что в году 366 дней
		label29:
			cmp		m, 2
			jne		label28a
			cmp		dy, 366
			jne		label28a
			mov		dm, 29
			jmp		my_exit
		//Иначе 28 дней
		label28a:
			mov		dm, 28
		//Выход
		my_exit :
		}
		if(i != 13)
		{
			cout << "В " << y << " году: " << dy << " дней" << endl;
			cout << m << "-й месяц: " << dy << " дней" << endl;
		}
		cout << endl;
	}
}


/*
	if (check == y)
	{
		dy = 366;
	}
	else
	{
		dy = 365;
	}

	if (m == 1 || m == 3 || m == 5 || m == 7 || m == 8 || m == 10 || m == 12)
	{
		dm = 31;
	}
	else if (m == 4 || m == 6 || m == 9 || m == 11)
	{
		dm = 30;
	}
	else if (m == 2 && dy == 366)
	{
		dm = 29;
	}
	else
	{
		dm = 28;
	}
*/