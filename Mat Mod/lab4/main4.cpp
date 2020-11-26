#include <iostream>
#include <clocale>
#include <string> 
#include <fstream>
#include <Windows.h>
using namespace std;
//���������� ������������ ����������������
double PK(double x, double t)
{
	return x + t;
}

int main()
{
	setlocale(LC_ALL, "Rus");
	double D = 1.0; //����������� ����������������
	double t_end = 4; //����� ��������� ������������
	double a = 0.0, b = 1.0; //������ � ����� �������
	double dx = 0.02; //��� ���������������� ����������
	double dt = (dx * dx) / 2.5; //��� ��������� ����������
	double q = (D * dt) / (dx * dx); //����������
	double Aplus, Aminus; //���������� ����������� ��������������
	int N = (b - a) / dx; //���������� ����� ����� �� x
	double* T = new double[N + 1.0]; //����������� �� ������� ����
	double* T_next = new double[N + 1.0]; //����������� �� �������� ����
	string filename;
	//��������� �������:
	for (int i = 0; i <= N; i++)
	{
		T[i] = 0.0;
	}
	ofstream file;
	//����� �����:
	//������� ��������� ������� � ���������� � ���� Const0.txt
	file.open("Const\\Const0.txt");
	file << "x" << "," << "T" << endl;
	for (int i = 0; i <= N; i++)
	{
		file << i * dx << "," << T[i] << endl;
	}
	file.close();
	int n = 100; //���������� ��� ������ � �����
	for (double t = dt; t <= t_end; t += dt)
	{
		//���������� � ������� ������� ����� �����
		for (int i = 1; i < N; i++)
		{
			T_next[i] = q * T[i + 1] + (1 - 2 * q) * T[i] + q * T[i - 1];
		}
		//���� ��������� �������:
		T_next[0] = t / (1 + t);
		T_next[N] = 0;
		//�������� � �������� � "�������"
		for (int i = 0; i <= N; i++)
			T[i] = T_next[i];
		//������ � ����� Const..txt ��� � 100 �����
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
	//������ � ��������� ���� Const..txt �������� �����������
	auto s = to_string(n / 100);
	filename = "Const\\Const";
	file.open(filename + s + ".txt");
	file << "x" << "," << "T" << endl;
	for (int i = 0; i <= N; i++)
	{
		file << i * dx << "," << T[i] << endl;
	}
	file.close();
	//������� ��������� �� �������� �����������
	cout << "���������� ��������� � ����� 'Const'." << endl;
	//��������� �������:
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
	//����� ����� � ���������� ������������� ����������������:
	for (double t = dt; t <= t_end; t += dt)
	{
		for (int i = 1; i < N; i++)
		{
			//��������� ����������� ����������������
			Aplus = (PK(i * dx, t) + PK((i + 1.0) * dx, t)) / 2;
			Aminus = (PK((i - 1.0) * dx, t) + PK(i * dx, t)) / 2;
			//�������� ������� ������������
			if (Aplus > ((0.5 * dx * dx) / dt))
				Aplus = (0.5 * dx * dx) / dt;
			if (Aminus > ((0.5 * dx * dx) / dt))
				Aminus = (0.5 * dx * dx) / dt;
			//�������� �������
			T_next[i] = ((Aplus * T[i + 1] - (Aplus + Aminus) * T[i] + Aminus * T[i - 1]) * dt) / (dx * dx) + T[i];
		}
		//���� ��������� �������:
		T_next[0] = t / (1 + t);
		T_next[N] = 0;
		//�������� � �������� � "�������"
		for (int i = 0; i <= N; i++)
			T[i] = T_next[i];
		//������ � ����� PK..txt ��� � 100 �����
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
	//������ � ��������� ���� PK..txt �������� �����������
	s = to_string(n / 100);
	filename = "PK\\PK";
	file.open(filename + s + ".txt");
	file << "x" << "," << "T" << endl;
	for (int i = 0; i <= N; i++)
	{
		file << i * dx << "," << T[i] << endl;
	}
	file.close();
	cout << "���������� ��������� � ����� 'PK'." << endl;
	delete[] T;
	delete[] T_next;
	system("pause");
	return 0;
}
