#include <stdio.h>

#define ROWS 5
#define COLS 5

void bubbleSort(int arr[], int cols) {
	for (int i = 0; i < cols - 1; i++) {
		for (int j = 0; j < cols - i - 1; j++) {
			if (arr[j] > arr[j + 1]) {
				// Меняем местами элементы
				int temp = arr[j];
				arr[j] = arr[j + 1];
				arr[j + 1] = temp;
			}
		}
	}
}

void sortKthRowAndColumns(int matrix[ROWS][COLS], int k) {
	// Сохраняем элементы K-ой строки
	int tempRow[COLS];
	for (int j = 0; j < COLS; j++) {
		tempRow[j] = matrix[k][j];
	}

	// Сортируем K-ую строку
	bubbleSort(tempRow, COLS);

	// Переставляем элементы в соответствующих столбцах
	for (int j = 0; j < COLS; j++) {
		matrix[k][j] = tempRow[j];
	}

	// Обновляем остальные строки в соответствии с новой K-ой строкой
	for (int i = 0; i < ROWS; i++) {
		for (int j = 0; j < COLS; j++) {
			if (i != k) {
				matrix[i][j] = matrix[i][j]; // Оставляем остальные строки без изменений
			}
		}
	}
}

void printMatrix(int matrix[ROWS][COLS]) {
	for (int i = 0; i < ROWS; i++) {
		for (int j = 0; j < COLS; j++) {
			printf("%d ", matrix[i][j]);
		}
		printf("\n");
	}
}

int main() {
	int matrix[ROWS][COLS];

	// Ввод элементов матрицы с клавиатуры
	printf("Введите элементы матрицы %dx%d:\n", ROWS, COLS);
	for (int i = 0; i < ROWS; i++) {
		for (int j = 0; j < COLS; j++) {
			printf("Элемент [%d][%d]: ", i, j);
			scanf("%d", &matrix[i][j]);
		}
	}

	int k;
	printf("Введите номер строки для сортировки (0-%d): ", ROWS - 1);
	scanf("%d", &k);

	if (k < 0 || k >= ROWS) {
		printf("Недопустимый номер строки.\n");
		return 1;
	}

	printf("Исходная матрица:\n");
	printMatrix(matrix);

	sortKthRowAndColumns(matrix, k);

	printf("Матрица после сортировки %d-ой строки:\n", k);
	printMatrix(matrix);

	return 0;
}