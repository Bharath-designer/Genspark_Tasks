import {handleSubmit, LoadProfessionOptions} from './script.js'

const form = document.querySelector(".login-container");
form.addEventListener("submit", handleSubmit)

const professionField = document.querySelector("input[name=profession]");
professionField.addEventListener("focus", LoadProfessionOptions)

const dobElement = document.querySelector("#dob");
const ageElement = document.querySelector("#age");

dobElement.addEventListener("change", () => {
    const dobValue = dobElement.value;
    const age = calculateAge(dobValue);
    ageElement.value = age;
});

function calculateAge(dob) {
    const dobDate = new Date(dob);
    const today = new Date();
    let age = today.getFullYear() - dobDate.getFullYear();
    const monthDiff = today.getMonth() - dobDate.getMonth();

    if (monthDiff < 0 || (monthDiff === 0 && today.getDate() < dobDate.getDate())) {
        age--;
    }

    return age;
}
