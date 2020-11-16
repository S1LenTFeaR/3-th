#include<iostream>
#include<clocale>
#include<fstream>
#include<Windows.h>
using namespace std;

int main()
{
	setlocale(LC_ALL, "Rus");
	double D = 1.0; //Коэффициент теплопроводности
	double t_end = 2; //Время окончания эксперимента
	double a = 0.0, b = 1.0; //Начало и конец отрезка
	double dx = 0.02; //Шаг пространственной переменной
	double dt = (dx * dx) / (4 * D); //Шаг временной переменной
	double q = (D * dt) / (dx * dx); //Сокращение
	int N = (b - a) / dx; //Количество узлов сетки по x
	double* T = new double[N + 1.0]; //Температура на текущем шаге
	double* T_next = new double[N + 1.0]; //Температура на слледущем шаге
	double* A = new double[N + 1.0]; //Коэф. прогонки
	double* B = new double[N + 1.0]; //Коэф. прогонки
	//Начальные условия:
	for (int i = 0; i <= N; i++)
	{
		T[i] = 0.0;
	}
	ofstream file;
	file.open("Начальные условия.txt");
	cout << "Вычисления загружены в файл 'Начальные условия.txt'." << endl;
	file << "x" << ";" << "T" << endl;
	for (int i = 0; i <= N; i++)
	{
		file << "(" << i * dx << ";" << T[i] << ")" << endl;
	}
	file.close();

	//Явная схема:
	for (double t = dt; t <= t_end; t += dt)
	{
		//Вычислление с помощью формулы явной схемы
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
	}
	file.open("Явная схема.txt");
	cout << "Вычисления загружены в файл 'Явная схема.txt'." << endl;
	file << "x" << ";" << "T" << endl;
	for (int i = 0; i <= N; i++)
	{
		file << "(" << i * dx << ";" << T[i] << ")" << endl;
	}
	file.close();

	//Неявная схема:
	//Начальные условия:
	for (int i = 0; i <= N; i++)
	{
		T[i] = 0.0;
	}
	for (double t = dt; t <= t_end; t += dt)
	{
		//Прогоночные коэффициенты:
		A[0] = 0;
		B[0] = t / (1 + t);
		//Прямая прогонка:
		for (int i = 1; i <= N; i++)
		{
			A[i] = (dt * D) / (dx * dx + D * dt * (2 - A[i - 1]));
			B[i] = (dx * dx * T[i - 1] + dt * D * B[i - 1]) / (dx * dx + dt * D * (2 - A[i - 1]));
		}
		T_next[N] = 0;
		//Обратная прогонка:
		for (int i = N - 1; i >= 0; i--)
		{
			T_next[i] = A[i + 1] * T_next[i + 1] + B[i + 1];
		}
		for (int i = 0; i <= N; i++)
		{
			T[i] = T_next[i];
		}
	}
	file.open("Неявная схема.txt");
	cout << "Вычисления загружены в файл 'Неявная схема.txt'." << endl;
	file << "x" << ";" << "T" << endl;
	for (int i = 0; i <= N; i++)
	{
		file << "(" << i * dx << ";" << T[i] << ")" << endl;
	}
	file.close();
	delete[] A;
	delete[] B;
	delete[] T;
	delete[] T_next;
	system("pause");
	return 0;
}
