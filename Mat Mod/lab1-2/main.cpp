#include<iostream>
#include<clocale>
#include<fstream>
#include<Windows.h>
using namespace std;

double DD(double x, double t)
{
	return (x + t)/2;
}

int main()
{
	setlocale(LC_ALL, "Rus");
	double D = 1.0; //����������� ����������������
	double t_end = 2; //����� ��������� ������������
	double a = 0.0, b = 1.0; //������ � ����� �������
	double dx = 0.02; //��� ���������������� ����������
	double dt = (dx * dx) / (4 * D); //��� ��������� ����������
	double q = (D * dt) / (dx * dx); //����������
	int N = (b - a) / dx; //���������� ����� ����� �� x
	double* T = new double[N + 1.0]; //����������� �� ������� ����
	double* T_next = new double[N + 1.0]; //����������� �� �������� ����
	double* T_perem = new double[N + 1.0]; //����������� �� ������� ����
	double* T_next_perem = new double[N + 1.0]; //����������� �� �������� ����
	double* A = new double[N + 1.0]; //����. ��������
	double* B = new double[N + 1.0]; //����. ��������
	//��������� �������:
	for (int i = 0; i <= N; i++)
	{
		T[i] = 0.0;
	}
	for (int i = 0; i <= N; i++)
	{
		T_perem[i] = 0.0;
	}
	ofstream file;
	file.open("��������� �������.txt");
	cout << "���������� ��������� � ���� '��������� �������.txt'." << endl;
	file << "x" << ";" << "T" << endl;
	for (int i = 0; i <= N; i++)
	{
		file << "(" << i * dx << ";" << T[i] << ")" << endl;
	}
	file.close();

	//����� �����:
	for (double t = dt; t <= t_end; t += dt)
	{
		int i = 1;
		//���������� � ������� ������� ����� �����
		for (double x = dx; x < b; x += dx)
		{
			//T_next[i] = (D * dt) / (dx * dx) * T[i + 1] + (1 - 2 * (D * dt) / (dx * dx)) * T[i] + (D * dt) / (dx * dx) * T[i - 1];
			T_next_perem[i] = (DD(x, t) * dt) / (dx * dx) * T_perem[i + 1] + (1 - 2 * (DD(x, t) * dt) / (dx * dx)) * T_perem[i] + (DD(x, t) * dt) / (dx * dx) * T_perem[i - 1];
			i++;
		}
		//���� ��������� �������:
		T_next[0] = t / (1 + t);
		T_next[N] = 0;
		//���� ��������� �������:
		T_next_perem[0] = t / (1 + t);
		T_next_perem[N] = 0;
		//�������� � �������� � "�������"
		for (int i = 0; i <= N; i++)
			T[i] = T_next[i];
		for (int i = 0; i <= N; i++)
			T_perem[i] = T_next_perem[i];
	}
	file.open("����� �����.txt");
	cout << "���������� ��������� � ���� '����� �����.txt'." << endl;
	file << "x" << ";" << "T" << endl;
	for (int i = 0; i <= N; i++)
	{
		file << "(" << i * dx << ";" << T_perem[i] << ")" << endl;
	}
	file.close();
	delete[] T;
	delete[] T_next;
	delete[] T_perem;
	delete[] T_next_perem;
	system("pause");
	return 0;
}
