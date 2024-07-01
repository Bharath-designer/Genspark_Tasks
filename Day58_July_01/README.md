# Class

- Python class is a blueprint for creating objects

#### Simple class
```python
class SampleClass:
    pass

my_object = SampleClass() 
```

# Inheritance

- Inheritance allows to inherit attributes and methods of another class

```python
class Animal:
    def __init__(self, name):
        self.name = name

    def speak(self):
        raise NotImplementedError("Subclass must implement abstract method")

class Dog(Animal):
    def speak(self):
        print(f"{self.name} says woof!")

my_dog = Dog('Buddy')
my_dog.speak()  # Output: Buddy says woof!
```

# Polymorphism

- Polymorphism allows different classes to be treated as instances of the same class through inheritance.

```python
class Vehicle:
    def __init__(self, brand):
        self.brand = brand
    
    def move(self):
        raise NotImplementedError("Subclass should implement abstract method")

class Car(Vehicle):
    def move(self):
        print(f"{self.brand} car is moving")

class Bike(Vehicle):
    def move(self):
        print(f"{self.brand} bike is moving")
        
car1 = Car("Volvo")
bike1 = Bike("BMW")

for vehicle in (car1, bike1):
    vehicle.move()
```

# Modules

- Modules allows to import specific or all variables, functions, classes from a python file.

```python
# CustomMath.py
class CustomMath:
    @staticmethod
    def add(a,b):
        return a+b

# main.py

from CustomMath import CustomMath

addedValue = CustomMath.add(1,3)
print(addedValue) # output 4
```

# Exception Handling(Try Except)

```python
try:
    result = 10 / 2
except ZeroDivisionError:
    print("Error: Division by zero")
else: # if no exceptions were called, else block will be executed after try block
    print("Division operation successful")
finally: # finally will execute regardless of whether an exception occurred or not.
    print("Finally block always executes")
```


# File handling - Read and Write

### Read

```python
file = open('./practice.txt') # opens file in read mode

content = file.read()  # reads all content of the file

file.seek(0) # reset file pointer
line1 = file.readline() # reads first line
line2 = file.readline() # reads second line

file.seek(0)
lines = file.readlines() # reads all line as list

print(content)
print(line1)
print(line2)
print(lines)
```


### Write 

```python
file = open('practice.txt', 'w')

file.write("This is line 1\n")
file.write("This is line 2\n")
file.writelines(["This is line 3\n", "This is line 4\n"])

# Close the file
file.close()
```
