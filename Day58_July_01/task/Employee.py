from datetime import date, datetime


class Employee:
    def __init__(self, name, dob, phone, email):
        self.name = name
        self.dob = dob
        self.phone = phone
        self.email = email

    def calculate_age(self):
        today = date.today()
        dob = datetime.strptime(self.dob, '%Y-%m-%d').date()
        age = today.year - dob.year - ((today.month, today.day) < (dob.month, dob.day))
        return age
