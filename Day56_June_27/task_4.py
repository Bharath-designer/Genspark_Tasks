# 4) Take name, age, date of birth and phone print details in proper format

from tabulate import tabulate

name = input("Enter your name: ")
age = input("Enter your age: ")
dob = input("Enter your date of birth (YYYY-MM-DD): ")
phone = input("Enter your phone number: ")

data = [
    ["Name", name],
    ["Age", age],
    ["Date of Birth", dob],
    ["Phone Number", phone]
]

print(tabulate(data, headers=["Label", "Value"], tablefmt="grid"))
