#include <iostream>
#include <clocale>
#include <string> 
#include <fstream>
#include <cmath>
#include <Windows.h>
#include <iomanip>
#define PI 3.1415926535
using namespace std;

//Структура с тремя временными слоями
struct Temp
{
	double cur, prev, next;
};
//Функция для записи в файл для визуализации
void In_file(Temp* T, int N, double dx, string filename)
{
	ofstream file(filename);
	//Шапка файла
	file << "x,T" << endl;
	//Запись значений в каждой точке
	for (int i = 0; i <= N; i++)
	{
		file << setprecision(2) << dx * i << ",";
		file << fixed << setprecision(6) << T[i].cur << endl;
	}
	file.close();
}

double t_end = 4; //Время окончания эксперемента
double a = 0.0, b = 1.0; //Начало и конец отрезка
double dx = 0.02; //Шаг пространственной переменной
int N = (b - a) / dx; //Количество узлов сетки по x
double c = 1.0; //Коэффициент скорости распространения волны
double dt = dx / c; //Шаг временной переменной

//Функция с вычислениями
Temp Calculations(Temp *T, double t_end)
{
	double* x = new double[N + 1.0];
	int i = 0;
	while (i <= N)
	{ 
		x[i] = i * dx;
		//Граничные условия
		if (i == 0 || i == N - 1)
		{ 
			T[i].cur = 0;
			T[i].prev = 0;
			T[i].next = 0;
			i++;
			continue;
		}
		//Начальные условия
		if (x[i] <= 1.0 / 3.0)
		{
			T[i].cur = -0.6 * PI * sin(6 * PI * x[i]);
		}
		else
		{
			T[i].cur = 0;
		}
		if (x[i] <= 1.0 / 3.0)
		{
			T[i].prev = 0.2 * sin(3.0 * PI * x[i]) * sin(3.0 * PI * x[i]);
		}
		else
		{
			T[i].prev = 0;
		}
		T[i].next = 0;
		i++;
	}
	double t = 2 * dt;
	while (t <= t_end)
	{
		i = 1;
		//Основная формула
		while (i < N)
		{
			T[i].next = (((c * c) * (dt * dt) / (dx * dx)) * (T[i + 1].cur - 2 * T[i].cur + T[i - 1].cur)) + 2 * T[i].cur - T[i].prev;
			i++;
		}
		i = 0;
		//Меняем массивы местами
		while (i <= N)
		{
			T[i].prev = T[i].cur;
			T[i].cur = T[i].next;
			i++;
		}
		t += dt;
	}
		return *T;
}

int main()
{
	setlocale(LC_ALL, "Rus");
	Temp* T = new Temp[N + 1.0];
	double t = 0.5;
	int n = 0;
	while (t <= 4)
	{
		*T = Calculations(T, t);
		//Запись в файлы
		for (int i = 0; i <= N; i++)
		{
			auto s = to_string(n);
			//Строка названия файла с данными
			string filename = "test\\t" + s + ".txt";
			In_file(T, N, dx, filename);
		}
		t += 0.5;
		n++;
	}
	delete[] T;
	system("pause");
	return 0;
}