#include <iostream>
#include <clocale>
#include <string> 
#include <fstream>
#include <Windows.h>
#include <cmath>
#define PI 3.1415926535
using namespace std;

double Q(double x, double y) //Источник выброса
{
	if (x == 100 && y == 50)
		return 200000; //Мощность выброса
	else
		return 0;
}


int main()
{
	setlocale(LC_ALL, "Rus");
	double t = 0; //Начальное время
	double t_end = 500; //Конечное время
	double x_last = 300;
	double dx = 50; //Шаг по x
	double C = 10; //Ветер
	double D = 1; //Диффузия
	double dt;
	double alpha = 45.0 * PI / 180.0; //Угол направления ветра
	double M1, M2, M3, M4;
	M1 = M2 = M3 = M4 = 0;
	double K1, K2, K3, K4, K5;
	double k = 0.1; //Коэффициент Куранта
	double Cx = C * cos(alpha);
	double Cy = C * sin(alpha);
	
	int i, j;
	int N = x_last / dx;

	double* P = new double[N + 2.0, N + 2.0]; //Плотность примеси в текущий момент времени
	double* P_next = new double[N + 2.0, N + 2.0]; //Плотность примеси в следующий момент времени

	//Начальные условия
	for (i = 0; i <= N + 1; i++)
	{
		for (j = 0; j < N + 1; j++)
		{
			P[i, j] = 0;
		}
	}

	dt = k * min((dx * dx) / (2 * D) + dx / abs(Cx), (dx * dx) / (2 * D) + dx / abs(Cy));
	//dt = 0.1;
	t += dt;

	//Основные расчеты
	do
	{
		for (i = 1; i <= N; i++)
		{
			for (j = 1; j <= N; j++)
			{
				if (Cx > 0)
				{
					M1 = P[i, j] * Cx * dx * dt;
					M2 = P[i - 1, j] * Cx * dx * dt;
				}
				else if (Cx < 0)
				{
					M1 = P[i + 1, j] * Cx * dx * dt;
					M2 = P[i, j] * Cx * dx * dt;
				}
				if (Cy > 0)
				{
					M3 = P[i, j] * Cy * dx * dt;
					M4 = P[i, j - 1] * Cy * dx * dt;
				}
				else if (Cy < 0)
				{
					M3 = P[i, j + 1] * Cy * dx * dt;
					M4 = P[i, j] * Cy * dx * dt;
				}
				//Основная формула
				K1 = P[i, j];
				K2 = 1.0 / (dx * dx) * (M1 - M2 + M3 - M4);
				K3 = (dt / (dx * dx)) * (D * (P[i + 1, j] - P[i, j]) - D * (P[i, j] - P[i - 1, j]));
				K4 = (dt / (dx * dx)) * (D * (P[i, j + 1] - P[i, j]) - D * (P[i, j] - P[i, j - 1]));
				K5 = Q(i * dx, j * dx) * dt;

				P_next[i, j] = K1 - K2 + K3 + K4 + K5;
			}
		}
		//Граничные условия
		for (j = 0; j <= N + 1; j++) 
		{
			P_next[0, j] = P_next[1, j];
			P_next[N + 1, j] = P_next[N, j];
		}
		for (i = 0; i <= N + 1; i++)
		{
			P_next[i, 0] = P_next[i, 1];
			P_next[i, N + 1] = P_next[i, N];
		}
		//Меняем массивы местами
		for (i = 0; i <= N + 1; i++)
		{
			for (j = 0; j <= N + 1; j++)
			{
				P[i, j] = P_next[i, j];
			}
		}

		t += dt;
	}
	while (t <= t_end);
	/*int n;
	string filename;
	ofstream file;
	
	auto s = to_string(n);
	filename = "Const\\Const";
	file.open(filename + s + ".txt");
	file << "x" << "," << "T" << endl;

		//file << i * dx << "," << T[i] << endl;

	file.close();*/
	for (int i = 0; i <= N; i++)
	{
		double x = i * dx;
		for (int j = 0; j <= N; j++)
		{
			double y = j * dx;
			if (P[i, j] <= 1) cout << x << "," << y << " -1 " << P[i, j] << endl;
			else if (P[i, j] > 1 && P[i, j] <= 50) cout << x << "," << y << " 0 " << P[i, j] << endl;
			else if (P[i, j] > 50 && P[i, j] <= 1000) cout << x << "," << y << " 1 " << P[i, j] << endl;
			else if (P[i, j] > 500 && P[i, j] <= 1000) cout << x << "," << y << " 2 " << P[i, j] << endl;
			else if (P[i, j] > 1000 && P[i, j] <= 2000) cout << x << "," << y << " 3 " << P[i, j] << endl;
			else if (P[i, j] > 2000) cout << x << "," << y << " 4 " << P[i, j] << endl;
		}
	}
	delete[] P;
	delete[] P_next;
	system("pause");
	return 0;
}
