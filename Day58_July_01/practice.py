#
# # Polymorphism
#
# class Vehicle:
#     def __init__(self, brand):
#         self.brand = brand
#
#     def move(self):
#         raise NotImplementedError("Subclass should implement abstract method")
#
#
# class Car(Vehicle):
#     def move(self):
#         print(f"{self.brand} car is moving")
#
#
# class Bike(Vehicle):
#     def move(self):
#         print(f"{self.brand} bike is moving")
#
#
# car1 = Car("Volvo")
# bike1 = Bike("BMW")
#
# for vehicle in (car1, bike1):
#     vehicle.move()
#
#

# # Try catch
#
# try:
#     result = 10 / 2  # No exception here
# except ZeroDivisionError:
#     print("Error: Division by zero")
# else:
#     print("Division operation successful")
# finally:
#     print("Finally block always executes")


# File Handling

file = open('./practice.txt',"w")

# content = file.read()
#
# file.seek(0)
# line1 = file.readline()
# line2 = file.readline()
#
# file.seek(0)
# lines = file.readlines()

# print(content)
# print(line1)
# print(line2)
# print(lines)

file.writelines(["This is line 3\n", "This is line 4\n"])
