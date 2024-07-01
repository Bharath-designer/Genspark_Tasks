import re
from datetime import datetime


def validate_email(email):
    pattern = r'^[\w\.-]+@[a-zA-Z\d\.-]+\.[a-zA-Z]{2,}$'
    return re.match(pattern, email)


def validate_phone(phone):
    pattern = r'^\d{10}$'
    return re.match(pattern, phone)


def validate_date(dob):
    try:
        datetime.strptime(dob, '%Y-%m-%d')
        return True
    except ValueError:
        return False
