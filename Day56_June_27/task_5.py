# 5) Add validation the entered  name, age, date of birth and phone print details in proper format


from tabulate import tabulate
import re


def validate_name(name):
    if not name:
        return False
    return True


def validate_age(age):
    try:    
        age = int(age)
        if age <= 0:
            raise ValueError()
    except ValueError:
        return False
    return True


def validate_dob(dob):
    if not re.match(r'^\d{4}-\d{2}-\d{2}$', dob):
        return False
    return True


def validate_phone(phone):
    if not re.match(r'^\d{3}-\d{3}-\d{4}$', phone):
        return False
    return True


while True:
    name = input("Enter your name: ")
    if validate_name(name):
        break
    else:
        print("Invalid name. Please enter a valid name.")

while True:
    age = input("Enter your age: ")
    if validate_age(age):
        break
    else:
        print("Invalid age. Please enter a valid age (positive integer).")

while True:
    dob = input("Enter your date of birth (YYYY-MM-DD): ")
    if validate_dob(dob):
        break
    else:
        print("Invalid date of birth format. Please enter date in YYYY-MM-DD format.")

while True:
    phone = input("Enter your phone number (XXX-XXX-XXXX): ")
    if validate_phone(phone):
        break
    else:
        print("Invalid phone number format. Please enter phone number in XXX-XXX-XXXX format.")

data = [
    ["Name", name],
    ["Age", age],
    ["Date of Birth", dob],
    ["Phone Number", phone]
]

print("\nYour details:")
print(tabulate(data, headers=["Label", "Value"], tablefmt="grid"))
