#include <iostream>
#include <clocale>
#include <string> 
#include <fstream>
#include <Windows.h>
using namespace std;
//���������� ������������ ����������������
double PK(double x, double t){
	return 1 - x / 2.0;
}
int main()
{
	setlocale(LC_ALL, "Rus");
	double D = 1.0; //����������� ����������������
	double tn = 4; //����� ��������� ������������
	double a = 0.0, b = 1.0; //��������� �������
	double h = 0.02; //��� �� x
	double tau = (h * h) / 2.5; //��� �� t 
	double q = (D * tau) / (h * h); //����������
	double A_sled, A_pred; //���������� ����������� ��������������
	int N = (b - a) / h; //���� ����� �� x
	double* T = new double[N + 1.0]; //����������� �� ������� ����
	double* T_next = new double[N + 1.0]; //����������� �� �������� ����
	//��������� �������
	for (int i = 0; i <= N; i++){
		T[i] = 0.0;
	}
	for (double t = tau; t <= tn; t += tau){
		for (int i = 1; i < N; i++){
			//��������� ����������� ����������������
			A_sled = (PK(i * h, t) + PK((i + 1.0) * h, t)) / 2;
			A_pred = (PK((i - 1.0) * h, t) + PK(i * h, t)) / 2;
			//�������� �������
			T_next[i] = ((A_sled * T[i + 1] - (A_sled + A_pred) * T[i] + A_pred * T[i - 1]) * tau) / (h * h) + T[i];
		}
		//���� ��������� �������:
		T_next[0] = -2;
		T_next[N] = 1;
		//����� �������� �������
		for (int i = 0; i <= N; i++)
			T[i] = T_next[i];
	}
	cout << "x" << ";" << "T" << endl;
	for (int i = 0; i <= N; i++)
		cout << i * h << ";" << T[i] << endl;
	delete[] T;
	delete[] T_next;
	system("pause");
	return 0;
}
