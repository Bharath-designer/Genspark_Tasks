# 3) Take name and gender print greet with salutation

salutations = {
    "M": "Mr.",
    "F": "Ms."
}

name = input("Enter your name: ")
gender = input("Enter your gender (M/F): ").upper()

salutation = salutations.get(gender, "")

if salutation:
    print(f"Hello, {salutation} {name}!")
else:
    print(f"Hello, {name}!")


