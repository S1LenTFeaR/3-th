#include<iostream>
#include<iomanip>
#include<clocale>
#include<cmath>
#include<fstream>
#include<Windows.h>
#define pi 3.141592653589793
using namespace std;
int main()
{
	setlocale(LC_ALL, "Rus");
	double a = 0, b = 1.0;//границы расчётной области
	double dx = 0.02, dt;//шаги по пространственной координате и по времени
	int N = (b - a) / dx;//число элементов сетки
	double t_end = 2.5;//время окончания эксперимента
	double c = 1.0;//скорость распространения волн (некоторый постоянный коэффициент)
	//значения на текущем, на следующем и на предыдущем шаге по времени
	double* T = new double[N + 1.0]; 
	double* T_next = new double[N + 1.0];
	double* T_prev = new double[N + 1.0];
	dt = dx / (c * c);//определяем шаг по времени из условия устойчивости Куранта - Фридрихса - Леви
	//Начальные условия:
	for (int i = 0; i <= N; i++)
	{
		if (i == 0 || i == N)//Граничные условия
		{
			T_prev[i] = 0.0;
			T[i] = 0.0;
		}
		else
		{
			T_prev[i] = 0.0;
			T[i] = T_prev[i];
		}
	}
	for (double t = 2 * dt; t <= t_end; t += dt)
	{
		for (int i = 0; i <= N; i++)
		{
			double x = 0;
			if (i == 0 || i == N)//Граничные условия
			{
				if (t < 1)
				{
					if (i == 0)
					{
						T_next[i] = sin(pi * t);
					}
					else
						T_next[i] = 0.0;
				}
				else
				{
					T_next[i] = 0.0;
				}
			}
			else
			{
				x += dx;
				dt = dx / (2 * (3 - 2 * x) * (3 - 2 * x));
				T_next[i] = (3 - 2 * x) * (3 - 2 * x) * c * dt * dt * (T[i + 1] - 2 * T[i] + T[i - 1]) / (dx * dx) - T_prev[i] + 2 * T[i];

			}
			dt = dx / (c * c);
		}
		for (int i = 0; i <= N; i++)
		{
			T_prev[i] = T[i];
			T[i] = T_next[i];
		}
	}
	ofstream file;
	file.open("result.txt");
	for (int i = 0; i <= N; i++)
	{
		cout << setw(12) << i * dx << setw(12) << T[i] << endl;
		file << "(" << i * dx << ";" << T[i] << ")";

	}
	file.close();
	delete[] T;
	delete[] T_next;
	delete[] T_prev;
	return 0;
}