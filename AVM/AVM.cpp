#include <iostream>
#include <cmath> 
#include <clocale> 
#define PI 3.14159265

using namespace std;

//Функция вычисления погрешности
double Eps(double sin_x, double y)
{
	double eps = 0;
	_asm
	{
		FLD sin_x
		FLD y
		FSUB
		FABS
		FXCH st(0)
		FSTP eps
	}
	cout << "Погрешность: " << eps << endl;
}

void main()
{
	while (true)
	{
		setlocale(LC_ALL, "RUS");

		double x_grad, x;
		cout << "Введите x: ";
		cin >> x_grad;
		
		x = x_grad * PI / 180;
		double sin_x;
		
		//Эталонное значение синуса
		_asm
		{
			FLD x
			FSIN
			FXCH st(0)
			FSTP sin_x
		}

		double x_3 = pow(x, 3);
		double x_5 = pow(x, 5);
		double x_7 = pow(x, 7);
		double x_9 = pow(x, 9);
		double x_11 = pow(x, 11);
		double fact_1 = 1;
		double fact_3 = fact_1 * 2 * 3;
		double fact_5 = fact_3 * 4 * 5;
		double fact_7 = fact_5 * 6 * 7;
		double fact_9 = fact_7 * 8 * 9;
		double fact_11 = fact_9 * 10 * 11;
		double y = 0;
		
		//Рассчет 4 членов ряда Тейлора
		_asm 
		{
			FLD x
			FLD x_3
			FLD fact_3
			//st(2) = 3!, st(1) = x3, st(0) = x
			FDIV //st(1) / st(2) --> st(1)
			FSUB //st(0) - st(1) --> st(0) 
			FLD x_5 //st(1) = x5
			FLD fact_5 //st(2) = 5!
			FDIV
			FADD
			FLD x_7
			FLD fact_7
			FDIV
			FSUB
			FXCH st(0)
			FSTP y
		}
		cout.precision(12);
		cout << "Для 4 членов ряда Тейлора" << endl;
		cout << "Рассчитанное значение: sin(" << x_grad << ") = " << y << endl;
		cout << "Эталонное значение: sin(" << x_grad << ") = " << sin_x << endl;
		Eps(sin_x, y);

		//Рассчет 5 членов ряда Тейлора
		_asm {
			FLD y
			FLD x_9
			FLD fact_9
			FDIV
			FADD
			FXCH st(0)
			FSTP y
		}
		cout << endl;
		cout << "Для 5 членов ряда Тейлора" << endl;
		cout << "Рассчитанное значение: sin(" << x_grad << ") = " << y << endl;
		cout << "Эталонное значение: sin(" << x_grad << ") = " << sin_x << endl;
		Eps(sin_x, y);
		cout << endl;

		//Рассчет 6 членов ряда Тейлора
		_asm {
			FLD y
			FLD x_11
			FLD fact_11
			FDIV
			FSUB
			FXCH st(0)
			FSTP y
		}
		cout << "Для 6 членов ряда Тейлора" << endl;
		cout << "Рассчитанное значение: sin(" << x_grad << ") = " << y << endl;
		cout << "Эталонное значение: sin(" << x_grad << ") = " << sin_x << endl;
		Eps(sin_x, y);
		cout << endl;
	}

}