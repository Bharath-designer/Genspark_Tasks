import fetchData from '../utilities/FetchData.js'

const validateForm = (formElement, formData, validations) => {
    const result = { valid: true, value: {} }
    validations.forEach(fieldValidation => {
        resetErrors(formElement, fieldValidation.field)
        const formvalue = formData.get(fieldValidation.field)
        let errorMessage = ""

        if (!fieldValidation.required && (formvalue == "" || formvalue == null)) {
            return;
        }

        if (formvalue !== "" && formvalue !== null) {
            if (fieldValidation.type === "number") {
                const regex = /^\d{10}$/;

                if (regex.test(formvalue)) {
                    result.value[fieldValidation.field] = formvalue
                    return;
                } else {
                    errorMessage = "Value should be a number of 10 digits"
                }
            } else if (fieldValidation.field === "email") {
                const regex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
                if (regex.test(formvalue)) {
                    result.value[fieldValidation.field] = formvalue
                    return;
                } else {
                    errorMessage = "Invalid Email"
                }
            }
            
            else {
                result.value[fieldValidation.field] = formvalue
                return;
            }
        } else {
            errorMessage = "Field is required"
        }
        result.valid = false;
        displayErrorMessage(formElement, fieldValidation.field, errorMessage)
    })

    return result
}

const resetErrors = (formElement, field) => {
    const formField = formElement.querySelector(`[name=${field}]`).closest(".form-field")
    const errorField = formField.nextElementSibling
    errorField.innerHTML = ""
    formField.classList.remove('error')
}

const displayErrorMessage = (formElement, field, errorMessage) => {
    const formField = formElement.querySelector(`[name=${field}]`).closest(".form-field")
    const errorField = formField.nextElementSibling
    errorField.innerHTML = errorMessage
    formField.classList.add('error')
}

const validations = [
    {
        field: 'fullName',
        required: true,
        type: 'string'
    },
    {
        field: 'phoneNumber',
        required: true,
        type: 'number'
    },
    {
        field: 'email',
        required: true,
        type: 'string'
    },
    {
        field: 'password',
        required: true,
        type: 'string'
    }
]

const handleSubmit = async (e) => {
    e.preventDefault()
    const formdata = new FormData(e.target);

    const { valid, value } = validateForm(e.target, formdata, validations)
    if (!valid) return;

    await fetchData("/api/register","POST", value)
    location.href = "/Login.html"
}   

const form = document.querySelector(".login-container");
form.addEventListener("submit", handleSubmit)
