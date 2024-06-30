# String Manipulation

- Strings are immutable in python, that means you can't modify an existing string.
```python
a = "John"
a.upper() # will create a new string with upper case
a = a.upper() # assigning the new string to already defined varible
```

# Functions

- Functions in Python use the ```def``` keyword to define a function.
```python
def greet_user(name, greeting="Welcome"):
    print(f"{greeting}, {name}")

greet_user("John","Hello")
```

# Tuples

- Tuples in Python are immutable sequences used to store collections of items, defined by enclosing the items in parentheses.
```python
my_tuple = (1, 2, 3)
print(my_tuple[0])  # Output: 1
```

# Dictionaries

- Dictionaries in Python are unordered collections of key-value pairs, providing a flexible way to store and retrieve data based on keys.

```python
student = {
    "name": "Alice",
    "age": 20,
    "major": "Computer Science",
    "gpa": 3.8
}

print(f"Name: {student['name']}")

```
# Sets

- Sets in Python are unordered collections of unique elements, providing efficient methods for set operations like intersection, union, and difference.

```python
set1 = {1, 2, 3, 3, 4, 4, 5}
print(set)  # Output: {1, 2, 3, 4, 5} (Duplicates removed)

```