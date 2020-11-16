#include<iostream>
#include<clocale>
#include<fstream>
#include<Windows.h>
using namespace std;

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
	double* T_next = new double[N + 1.0]; //����������� �� ��������� ����
	double* A = new double[N + 1.0]; //����. ��������
	double* B = new double[N + 1.0]; //����. ��������
	//��������� �������:
	for (int i = 0; i <= N; i++)
	{
		T[i] = 0.0;
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
		//����������� � ������� ������� ����� �����
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
	}
	file.open("����� �����.txt");
	cout << "���������� ��������� � ���� '����� �����.txt'." << endl;
	file << "x" << ";" << "T" << endl;
	for (int i = 0; i <= N; i++)
	{
		file << "(" << i * dx << ";" << T[i] << ")" << endl;
	}
	file.close();

	//������� �����:
	//��������� �������:
	for (int i = 0; i <= N; i++)
	{
		T[i] = 0.0;
	}
	for (double t = dt; t <= t_end; t += dt)
	{
		//����������� ������������:
		A[0] = 0;
		B[0] = t / (1 + t);
		//������ ��������:
		for (int i = 1; i <= N; i++)
		{
			A[i] = (dt * D) / (dx * dx + D * dt * (2 - A[i - 1]));
			B[i] = (dx * dx * T[i - 1] + dt * D * B[i - 1]) / (dx * dx + dt * D * (2 - A[i - 1]));
		}
		T_next[N] = 0;
		//�������� ��������:
		for (int i = N - 1; i >= 0; i--)
		{
			T_next[i] = A[i + 1] * T_next[i + 1] + B[i + 1];
		}
		for (int i = 0; i <= N; i++)
		{
			T[i] = T_next[i];
		}
	}
	file.open("������� �����.txt");
	cout << "���������� ��������� � ���� '������� �����.txt'." << endl;
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
