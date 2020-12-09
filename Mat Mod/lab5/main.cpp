#include <iostream>
#include <clocale>
#include <string> 
#include <fstream>
#include <Windows.h>
#include <cmath>
#include <iomanip>
#define PI 3.1415926535
using namespace std;

//������� ������ � ���� ��� ������������
void In_VTK_file(double **P, int N, double dx, string filename) 
{
	ofstream file(filename);
	//����� VTK �����
	file << "# vtk DataFile Version 5.0" << endl;
	file << "Example 3D regular grid VTK file." << endl;
	file << "ASCII" << endl;
	file << "DATASET UNSTRUCTURED_GRID" << endl;
	file << "POINTS " << (N + 1) * (N + 1) << " float" << endl;
	//������ ����� � ����
	for (int i = 0; i <= N; i++)
	{
		float x = i * dx;
		for (int j = 0; j <= N; j++)
		{
			float y = j * dx;
			file << x << " " << y << " 0" << endl;
		}
	}
	//����� ��� ������ � ������
	file << "POINT_DATA " << (N + 1) * (N + 1) << endl;
	file << "SCALARS P float" << endl;
	file << "LOOKUP_TABLE default" << endl;
	//������ �������� � ������ �����
	for (int i = 0; i <= N; i++)
	{
		for (int j = 0; j <= N; j++)
		{
			file << fixed << setprecision(4) << P[i][j] << endl;
		}
	}
	file.close();
}
//�������� �������
double Q(double x, double y) 
{
	if (x == 100 && y == 50)
		return 2000; //�������� �������
	else
		return 0;
}

int main()
{
	setlocale(LC_ALL, "Rus");
	double dx = 10; //��� �� x
	double dt; //��� �� �������
	double t = 0; //��������� �����
	double t_end = 500; //�������� �����
	double x_last = 3000;
	double C = 10; //�����
	double D = 100; //��������
	double alpha = 45.0 * PI / 180.0; //���� ����������� �����
	double M1, M2, M3, M4;
	M1 = M2 = M3 = M4 = 0;
	double K1, K2, K3, K4, K5;
	double k = 0.05; //����������� �������
	double Cx = C * cos(alpha);
	double Cy = C * sin(alpha);
	int i, j;
	int N = x_last / dx;
	//��������� ������� � ������� ������ �������
	double** P = new double* [N + 2.0]; 
	for (int i = 0; i < N + 2.0; i++)
	{
		P[i] = new double[N + 2.0];
	}
	//��������� ������� � ������� ������ �������
	double** P_next = new double* [N + 2.0]; 
	for (int i = 0; i < N + 2.0; i++)
	{
		P_next[i] = new double[N + 2.0];
	}
	//��������� �������
	for (i = 0; i <= N + 1; i++)
	{
		for (j = 0; j <= N + 1; j++)
		{
			P[i][j] = 0;
			P_next[i][j] = 0;
		}
	}
	int n = 0;
	//������� ������������
	dt = k * min((dx * dx) / (2 * D) + dx / abs(Cx), (dx * dx) / (2 * D) + dx / abs(Cy));

	t += dt;
	//�������� �������
	do
	{
		for (i = 1; i <= N; i++)
		{
			for (j = 1; j <= N; j++)
			{
				if (Cx > 0)
				{
					M1 = P[i][j] * Cx * dx * dt;
					M2 = P[i - 1][j] * Cx * dx * dt;
				}
				else if (Cx < 0)
				{
					M1 = P[i + 1][j] * Cx * dx * dt;
					M2 = P[i][j] * Cx * dx * dt;
				}
				if (Cy > 0)
				{
					M3 = P[i][j] * Cy * dx * dt;
					M4 = P[i][j - 1] * Cy * dx * dt;
				}
				else if (Cy < 0)
				{
					M3 = P[i][j + 1] * Cy * dx * dt;
					M4 = P[i][j] * Cy * dx * dt;
				}
				//�������� �������
				//������� �� 5 ������, ����� ������� ���� � ��� ��������
				K1 = P[i][j];
				K2 = 1.0 / (dx * dx) * (M1 - M2 + M3 - M4);
				K3 = (dt / (dx * dx)) * (D * (P[i + 1][j] - P[i][j]) - D * (P[i][j] - P[i - 1][j]));
				K4 = (dt / (dx * dx)) * (D * (P[i][j + 1] - P[i][j]) - D * (P[i][j] - P[i][j - 1]));
				K5 = Q(i * dx, j * dx) * dt;

				P_next[i][j] = K1 - K2 + K3 + K4 + K5;
			}
		}
		//��������� �������
		for (j = 0; j <= N + 1; j++) 
		{
			P_next[0][j] = P_next[1][j];
			P_next[N + 1][j] = P_next[N][j];
		}
		for (i = 0; i <= N + 1; i++)
		{
			P_next[i][0] = P_next[i][1];
			P_next[i][N + 1] = P_next[i][N];
		}
		//������ ������� �������
		for (i = 0; i <= N + 1; i++)
		{
			for (j = 0; j <= N + 1; j++)
			{
				P[i][j] = P_next[i][j];
			}
		}
		//������ � ����
		if (n % (int)(0.5 * N) == 0)
		{
			auto s = to_string(n);
			//������ �������� ����� � �������
			string filename = "test\\p" + s + ".vtk";
			In_VTK_file(P, N, dx, filename);
		}
		n++;
		t += dt;
	}
	while (t <= t_end);
	//������� ������
	for (int i = 0; i < N + 2.0; i++)
	{
		delete[] P[i];
	}
	for (int i = 0; i < N + 2.0; i++)
	{
		delete[] P_next[i];
	}
	system("pause");
	return 0;
}
