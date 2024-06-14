import validateForm from "./validator.js"

const professionsList = [
    "Accountant",
    "Architect",
    "Engineer",
    "Graphic Designer",
    "Lawyer",
    "Marketing Specialist",
    "Nurse",
    "Software Developer",
    "Teacher",
    "Web Developer"
]

export const LoadProfessionOptions = () => {
    const dataList = document.querySelector("datalist#browsers")
    professionsList.forEach(element => {
        const option = document.createElement("option")
        option.value = element
        dataList.appendChild(option)
    })
}


const validations = [
    {
        field: 'name',
        required: true,
        type: 'string'
    },
    {
        field: 'phone',
        required: true,
        type: 'number'
    },
    {
        field: 'dob',
        required: true,
        type: 'string'
    },
    {
        field: 'age',
        required: true,
        type: 'string'
    },
    {
        field: 'gender',
        required: true,
        type: 'string'
    },
    {
        field: 'qualification',
        required: true,
        type: 'string'
    },
    {
        field: 'profession',
        required: true,
        type: 'string'
    }
]

export const handleSubmit = (e) => {
    e.preventDefault()
    const formdata = new FormData(e.target);

    const { valid, value } = validateForm(e.target, formdata, validations)
    console.log(valid);
    if (!valid) return;

    document.write("<h2>Data received successfully</h2>")
    document.write(JSON.stringify(value))

}   
