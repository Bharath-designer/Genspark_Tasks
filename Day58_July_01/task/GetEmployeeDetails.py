from Validations import *
from Employee import Employee


def get_employee_details():
    while True:
        name = input("Enter employee name: ")
        dob = input("Enter employee date of birth (YYYY-MM-DD): ")
        phone = input("Enter employee phone number (10 digits): ")
        email = input("Enter employee email: ")

        if not validate_date(dob):
            print("Invalid date format. Please use YYYY-MM-DD.")
            continue
        if not validate_phone(phone):
            print("Invalid phone number. Please enter 10 digits.")
            continue
        if not validate_email(email):
            print("Invalid email format. Please enter a valid email.")
            continue

        return Employee(name, dob, phone, email)
