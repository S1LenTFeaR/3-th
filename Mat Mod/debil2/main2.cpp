#include<iostream>
#include<iomanip>
#include<cmath>
#include<clocale>
#include<fstream>
#include<Windows.h>
using namespace std;

int main()
{
	setlocale(LC_ALL, "Rus");
	double* T, * T_sled, * A, * B;
	int N;
	double a = 0.0, b = 1.0;//расчётная область
	double D = 1.0;//коэффициент теплопроводности
	double tn = 3.0;//время окончания эксперимента
	double h = 0.02, tau = 0.0;
	N = (b - a) / h;//определяем количество элементов сетки
	tau = (h * h) / (2 * D);//определяем шаг для явной схемы, исходя из условия устойчивости
	T = new double[N + 1];
	T_sled = new double[N + 1];
	A = new double[N + 1];
	B = new double[N + 1];
	//начальные условия
	for (int i = 0; i <= N; i++)
	{
		T[i] = 0.0;
	}
	cout << "Начальные условия:" << endl;
	cout << endl;
	for (int i = 0; i <= N; i++)
	{
		cout << i * h << ";" << T[i] << endl;
	}
	cout << endl;
	for (double t = tau; t <= tn; t += tau)
	{
		for (int i = 1; i < N; i++)
		{
			T_sled[i] = (D * tau) / (h * h) * T[i + 1] + (1 - 2 * (tau * D) / (h * h)) * T[i] + (tau * D) / (h * h) * T[i - 1];
		}
		//учитываем граничные условия
		T_sled[0] = -2;
		T_sled[N] = 1;
		for (int i = 0; i <= N; i++)
			T[i] = T_sled[i];//меняем местами массивы
	}
	cout << "Результат (явная схема):" << endl;
	cout << endl;
	for (int i = 0; i <= N; i++)
	{
		cout << i * h << ";" << T[i] << endl;
	}
	cout << endl;
	//неявная схема:
	//начальные условия:
	for (int i = 0; i <= N; i++)
	{
		T[i] = 0.0;
	}
	for (double t = tau; t <= tn; t += tau)
	{
		//прогоночные коэффициенты
		A[0] = 0;
		B[0] = -2;
		//прямая прогонка:
		for (int i = 1; i <= N; i++)
		{
			A[i] = (tau * D) / (h * h + D * tau * (2 - A[i - 1]));
			B[i] = (h * h * T[i - 1] + tau * D * B[i - 1]) / (h * h + tau * D * (2 - A[i - 1]));
		}
		T_sled[N] = 1;
		for (int i = N - 1; i >= 0; i--)//обратная прогонка
		{
			T_sled[i] = A[i + 1] * T_sled[i + 1] + B[i + 1];
		}
		for (int i = 0; i <= N; i++)
		{
			T[i] = T_sled[i];
		}
	}
	cout << "Результат (неявная схема):" << endl;
	cout << endl;
	for (int i = 0; i <= N; i++)
	{
		cout << i * h << ";" << T[i] << endl;
	}
	cout << endl;
	delete[] T;
	delete[] T_sled;
	delete[] A;
	delete[] B;
	system("pause");
	return 0;
}