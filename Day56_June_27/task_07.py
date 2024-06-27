from is_prime import is_prime

numbers = []
for i in range(1,11):
    number = int(input(f"Enter number {i}: "))
    numbers.append(number)


prime_numbers = [num for num in numbers if is_prime(num)]
if prime_numbers:
    average_prime = sum(prime_numbers) / len(prime_numbers)
    print(f"Prime numbers in the collection: {prime_numbers}")
    print(f"Average of prime numbers: {average_prime:.2f}")
else:
    print("No prime numbers found in the collection.")
