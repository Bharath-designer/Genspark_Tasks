# 9) Find All Permutations of a given string


def all_permutations(string):
    if len(string) <= 1:
        return [string]

    permutations = []
    for i in range(len(string)):
        char = string[i]
        remaining_chars = string[:i] + string[i+1:]
        for permutation in all_permutations(remaining_chars):
            permutations.append(char + permutation)
    return permutations

input_string = input("Enter a string: ")
permutations = all_permutations(input_string)
print(f"Given string has {len(permutations)} permutations")
for perm in permutations:
    print(perm)
