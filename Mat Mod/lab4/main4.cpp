#include <iostream>
#include <clocale>
#include <string> 
#include <fstream>
#include <Windows.h>
using namespace std;
//Вычисление коэффициента теплопроводности
double PK(double x, double t)
{
	return x + t;
}

int main()
{
	setlocale(LC_ALL, "Rus");
	double D = 1.0; //Коэффициент теплопроводности
	double t_end = 4; //Время окончания эксперимента
	double a = 0.0, b = 1.0; //Начало и конец отрезка
	double dx = 0.02; //Шаг пространственной переменной
	double dt = (dx * dx) / 2.5; //Шаг временной переменной
	double q = (D * dt) / (dx * dx); //Сокращение
	double Aplus, Aminus; //Переменный коэффициент теплопродности
	int N = (b - a) / dx; //Количество узлов сетки по x
	double* T = new double[N + 1.0]; //Температура на текущем шаге
	double* T_next = new double[N + 1.0]; //Температура на следущем шаге
	string filename;
	//Начальные условия:
	for (int i = 0; i <= N; i++)
	{
		T[i] = 0.0;
	}
	ofstream file;
	//Явная схема:
	//Считаем начальные условия и записываем в файл Const0.txt
	file.open("Const\\Const0.txt");
	file << "x" << "," << "T" << endl;
	for (int i = 0; i <= N; i++)
	{
		file << i * dx << "," << T[i] << endl;
	}
	file.close();
	int n = 100; //Переменная для записи в файлы
	for (double t = dt; t <= t_end; t += dt)
	{
		//Вычисление с помощью формулы явной схемы
		for (int i = 1; i < N; i++)
		{
			T_next[i] = q * T[i + 1] + (1 - 2 * q) * T[i] + q * T[i - 1];
		}
		//Учёт граничных условий:
		T_next[0] = t / (1 + t);
		T_next[N] = 0;
		//Помещаем в значение в "текущее"
		for (int i = 0; i <= N; i++)
			T[i] = T_next[i];
		//Запись в файлы Const..txt раз в 100 шагов
		if (n % 100 == 0);
		{
			auto s = to_string(n / 100);
			filename = "Const\\Const";
			file.open(filename + s + ".txt");
			file << "x" << "," << "T" << endl;
			for (int i = 0; i <= N; i++)
			{
				file << i * dx << "," << T[i] << endl;
			}
			file.close();
		}
		n++;
	}
	//Запись в последний файл Const..txt конечных результатов
	auto s = to_string(n / 100);
	filename = "Const\\Const";
	file.open(filename + s + ".txt");
	file << "x" << "," << "T" << endl;
	for (int i = 0; i <= N; i++)
	{
		file << i * dx << "," << T[i] << endl;
	}
	file.close();
	//Выводим сообщение об успешных вычислениях
	cout << "Вычисления загружены в папку 'Const'." << endl;
	//Начальные условия:
	for (int i = 0; i <= N; i++)
	{
		T[i] = 0.0;
	}
	file.open("PK\\PK0.txt");
	file << "x" << "," << "T" << endl;
	for (int i = 0; i <= N; i++)
	{
		file << i * dx << "," << T[i] << endl;
	}
	file.close();
	n = 100;
	//Явная схема с переменным коэффициентом теплопроводности:
	for (double t = dt; t <= t_end; t += dt)
	{
		for (int i = 1; i < N; i++)
		{
			//Вычисляем коэффиценты теплопроводности
			Aplus = (PK(i * dx, t) + PK((i + 1.0) * dx, t)) / 2;
			Aminus = (PK((i - 1.0) * dx, t) + PK(i * dx, t)) / 2;
			//Проверка условия устойчивости
			if (Aplus > ((0.5 * dx * dx) / dt))
				Aplus = (0.5 * dx * dx) / dt;
			if (Aminus > ((0.5 * dx * dx) / dt))
				Aminus = (0.5 * dx * dx) / dt;
			//Основная формула
			T_next[i] = ((Aplus * T[i + 1] - (Aplus + Aminus) * T[i] + Aminus * T[i - 1]) * dt) / (dx * dx) + T[i];
		}
		//Учёт граничных условий:
		T_next[0] = t / (1 + t);
		T_next[N] = 0;
		//Помещаем в значение в "текущее"
		for (int i = 0; i <= N; i++)
			T[i] = T_next[i];
		//Запись в файлы PK..txt раз в 100 шагов
		if (n % 100 == 0);
		{
			auto s = to_string(n / 100);
			filename = "PK\\PK";
			file.open(filename + s + ".txt");
			file << "x" << "," << "T" << endl;
			for (int i = 0; i <= N; i++)
			{
				file << i * dx << "," << T[i] << endl;
			}
			file.close();
		}
		n++;
	}
	//Запись в последний файл PK..txt конечных результатов
	s = to_string(n / 100);
	filename = "PK\\PK";
	file.open(filename + s + ".txt");
	file << "x" << "," << "T" << endl;
	for (int i = 0; i <= N; i++)
	{
		file << i * dx << "," << T[i] << endl;
	}
	file.close();
	cout << "Вычисления загружены в папку 'PK'." << endl;
	delete[] T;
	delete[] T_next;
	system("pause");
	return 0;
}
