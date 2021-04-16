#include <iostream>
using namespace std;

void main()
{
	_asm
	{
		//С суффиксом h без для целочисленных констант
		/*
		MOV EAX, 1FFFF;
		*/
		MOV EAX, 1FFFFh;
		//EDX = EAX + EBX + ECX
		MOV EAX, 1Fh;
		MOV EBX, 2FFh;
		MOV ECX, 5h;
		MOV EDX, 0h;
		INC EDX;
		ADD EDX, EAX;
		ADD EDX, EBX;
		ADD EDX, ECX;
		//EDX = EAX - EBX - ECX
		MOV EDX, EAX;
		SUB EDX, EAX;
		SUB EDX, EBX;
		SUB EDX, ECX;
		//(a1 = AH, a2 = BH) + (b1 = AL, b2 = BL)
		MOV AH, 5;
		MOV BH, 7;
		MOV AL, 10;
		MOV BL, 8;
		MOV CH, AH;
		ADD CH, BH;
		MOV CL, AL;
		ADD CL, BL;
		//(с1 = СH, с2 = СL) = (a1 = AH, a2 = BH) - (b1 = AL, b2 = BL)
		MOV CH, AH;
		SUB CH, BH;
		MOV CL, AL;
		SUB CL, BL;
		//Факториал 6, 7 и 8 в регистре DX
		MOV AX, 0;
		MOV AL, 6;
		MOV BL, 7;
		MOV CL, 8;
		MUL BL;
		MUL CL;
		MOV DX, AX;
		MOV AX, 0;
	}
}

