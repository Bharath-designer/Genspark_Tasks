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
                const regex = /^-?\d+(\.\d+)?$/;

                if (regex.test(formvalue)) {
                    result.value[fieldValidation.field] = parseInt(formvalue)
                    return;
                } else {
                    errorMessage = "Value should be a number"
                }
            } else {
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

export default validateForm