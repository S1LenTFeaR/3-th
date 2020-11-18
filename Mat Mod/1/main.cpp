#include<iostream>
#include<iomanip>
#include<clocale>
#include<fstream>
#include<Windows.h>
using namespace std;

int main()
{
	setlocale(LC_ALL, "Rus");
	double* T, * T_sled;
	int N;
	double a = 0.0, b = 1.0;//��������� �������
	double D = 1.0;//����������� ����������������
	double tn = 3.0;//����� ��������� ������������
	double h = 0.02, tau = 0.0;
	N = (b - a) / h;//���������� ���������� ��������� �����
	tau = (h * h) / (2 * D);//���������� ��� ��� ����� �����, ������ �� ������� ������������
	T = new double[N + 1];
	T_sled = new double[N + 1];
	//��������� �������
	for (int i = 0; i <= N; i++)
	{
		T[i] = 0.0;
	}
	cout << "��������� �������:" << endl;
	for (int i = 0; i <= N; i++)
	{
		cout << i * h << ";" << T[i] << endl;
	}
	for (double t = tau; t <= tn; t += tau)
	{
		for (int i = 1; i < N; i++)
		{
			T_sled[i] = (D * tau) / (h * h) * T[i + 1] + (1 - 2 * (tau * D) / (h * h)) * T[i] + (tau * D) / (h * h) * T[i - 1];
		}
		//��������� ��������� �������
		T_sled[0] = -2;
		T_sled[N] = 1;
		for (int i = 0; i <= N; i++)
			T[i] = T_sled[i];//������ ������� �������
	}
	cout << "���������:" << endl;
	for (int i = 0; i <= N; i++)
	{
		cout << i * h << ";" << T[i] << endl;
	}
	system("pause");
}
