from GetEmployeeDetails import get_employee_details
import pandas as pd
from reportlab.lib.pagesizes import letter
from reportlab.pdfgen import canvas


def save_to_text(employee):
    with open('employee_details.txt', 'a') as file:
        file.write(f"Name: {employee.name}\n")
        file.write(f"DOB: {employee.dob}\n")
        file.write(f"Phone: {employee.phone}\n")
        file.write(f"Email: {employee.email}\n")
        file.write(f"Age: {employee.calculate_age()}\n\n")


def save_to_excel(employee):
    data = {
        'Name': [employee.name],
        'DOB': [employee.dob],
        'Phone': [employee.phone],
        'Email': [employee.email],
        'Age': [employee.calculate_age()]
    }
    df = pd.DataFrame(data)

    df.to_excel('employee_details.xlsx')


def save_to_pdf(employee):
    file_name = f"{employee.name}_details.pdf"

    c = canvas.Canvas(file_name, pagesize=letter)

    c.setFont("Helvetica", 12)

    c.drawString(100, 750, "Employee Details:")
    c.drawString(100, 730, f"Name: {employee.name}")
    c.drawString(100, 710, f"DOB: {employee.dob}")
    c.drawString(100, 690, f"Phone: {employee.phone}")
    c.drawString(100, 670, f"Email: {employee.email}")
    c.drawString(100, 650, f"Age: {employee.calculate_age()}")

    # Save the PDF
    c.save()


def bulk_upload(file_path):
    if file_path.endswith('.xlsx'):
        data = pd.read_excel(file_path)
    elif file_path.endswith('.csv'):
        data = pd.read_csv(file_path)
    else:
        raise ValueError("Unsupported file type. Please provide an .xlsx or .csv file.")

    print(data)


def main():

    while True:
        print("\nMenu:")
        print("1. Save to text file")
        print("2. Save to Excel file")
        print("3. Save to PDF file")
        print("4. Bulk upload and display data")
        print("5. Exit")

        choice = input("Enter your choice: ")


        if choice == '1':
            employee = get_employee_details()
            save_to_text(employee)
            print("Data saved to text file.")
        elif choice == '2':
            employee = get_employee_details()
            save_to_excel(employee)
            print("Data saved to Excel file.")
        elif choice == '3':
            employee = get_employee_details()
            save_to_pdf(employee)
            print("Data saved to PDF file.")
        elif choice == '4':
            bulk_upload('sample_bulk_upload.xlsx')
        elif choice == '5':
            print("Exiting program.")
            break
        else:
            print("Invalid choice. Please enter a valid option.")


main()
