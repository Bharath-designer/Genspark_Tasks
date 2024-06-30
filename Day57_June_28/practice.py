# string manuipulation

string = "   Some Sample Sample String"

upper = string.upper()
lower = string.lower()
casefolded = string.casefold()
count = string.count("Sample", 6)

# print(upper)
# print(lower)
# print(casefolded)
# print(count)


# 2) Functions

def greeting(greet_msg, name="Bharath"):
    print(f"{greet_msg}, {name}")


greeting(greet_msg= "Welcome")