# 10) Print a pyramid of starts for the number of rows specified


def print_pyramid(rows):
    for i in range(1, rows + 1):
        print(' ' * (rows - i), end='')
        print('* ' * i)


num_rows = int(input("Enter number of rows: "))
print_pyramid(num_rows)
