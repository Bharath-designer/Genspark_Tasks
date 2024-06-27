import fetchData from "../utilities/FetchData.js"
import { makeActiveTab } from './Profile.js'

const createRespondToEventOverlayTemplate = (formTitle, formSubmitHandler) => {
    const template = document.createElement("template")
    template.innerHTML =
        `
    <div class="respond-to-event-overlay-container overlay-container">
        <form class="respond-to-event-form">
            <div class="form-title">${formTitle}</div>
            <div class="fields-container">
                <div class="inp-field">
                    <label for="requestStatus">Request Status</label>
                    <select id="requestStatus" name="requestStatus" type="text">
                        <option value="" selected disabled>Select a status</option>
                        <option value="Accepted">Accepted</option>
                        <option value="Denied">Denied</option>
                    </select>
                    <div class="error-section"></div>
                </div>
                <div class="inp-field amount-inp">
                    <label for="currency">Currency</label>
                    <select id="currency" name="currency" type="text">
                        <option value="" selected disabled>Select a currency</option>
                        <option value="USD">USD - US Dollar</option>
                        <option value="EUR">EUR - Euro</option>
                        <option value="INR">INR - Indian Rupee</option>
                    </select>                    
                    <div class="error-section"></div>
                </div>
                <div class="inp-field amount-inp">
                    <label for="quotedAmount">Quotation Amount</label>
                    <input id="quotedAmount" name="quotedAmount" type="text">
                    <div class="error-section"></div>
                </div>
                <div class="inp-field">
                    <label for="responseMessage">Message</label>
                    <textarea id="responseMessage" name="responseMessage"></textarea>
                    <div class="error-section"></div>
                </div>
                
            </div>
            <div class="form-btn-container">
                <button type="button" class="cancel-btn btn">Cancel</button>
                <button type="submit" class="save-btn btn">Save</button>
            </div>
        </form>

    </div>
    `

    const content = template.content
    const cancelBtn = content.querySelector('.cancel-btn')
    const form = content.querySelector("form")
    const requestStatus = form.querySelector("[name=requestStatus]")

    requestStatus.addEventListener("input", () => {
        if (requestStatus.value === "Accepted") {
            form.classList.add("accepted")
        } else {
            form.classList.remove("accepted")
        }
    })

    cancelBtn.onclick = cancelRespondToEventOverlay

    form.onsubmit = formSubmitHandler

    document.body.appendChild(content)
}


const submitHandler = async (e, saveFuntion) => {
    e.preventDefault()
    const formElement = document.querySelector('.respond-to-event-overlay-container form')
    const formdata = new FormData(formElement)
    const requestStatus = formdata.get('requestStatus')
    const quotedAmount = formdata.get('quotedAmount')
    const currency = formdata.get('currency')
    const responseMessage = formdata.get('responseMessage')

    const requestStatusErrorSection = formElement.querySelector("[name=requestStatus] + .error-section")
    const currencyErrorSection = formElement.querySelector("[name=currency] + .error-section")
    const amountErrorSection = formElement.querySelector("[name=quotedAmount] + .error-section")
    const responseMessageErrorSection = formElement.querySelector("[name=responseMessage] + .error-section")

    requestStatusErrorSection.textContent = ""
    currencyErrorSection.textContent = ""
    amountErrorSection.textContent = ""
    responseMessageErrorSection.textContent = ""

    if (!requestStatus) {
        requestStatusErrorSection.textContent = "Request Status is required"
        return;
    }
    if (requestStatus === "Accepted") {
        if (!currency) {
            currencyErrorSection.textContent = "Currency is required"
            return;
        }
        if (!quotedAmount) {
            amountErrorSection.textContent = "Quotation Amount is required"
            return;
        }
        if (!/\b\d+(\.\d+)?\b/.test(quotedAmount)) {
            amountErrorSection.textContent = "Amount should be number."
            return;
        }
    }
    if (!responseMessage) {
        responseMessageErrorSection.textContent = "Response Message is required"
        return;
    }

    await saveFuntion(requestStatus, parseInt(quotedAmount), currency, responseMessage)

    cancelRespondToEventOverlay()
    makeActiveTab('adminRequests')

}

export const createRespondToEventOverlay = (quotationRequestId) => {

    const saveFunc = async (requestStatus, quotedAmount, currency, responseMessage) => {
        await fetchData(`/api/quotation/response`, "POST", {
            quotationRequestId,
            requestStatus,
            quotedAmount,
            currency,
            responseMessage
        })
    }
    createRespondToEventOverlayTemplate("Create Event", (e) => submitHandler(e, saveFunc))
}


export const cancelRespondToEventOverlay = () => {
    const overlay = document.querySelector('.respond-to-event-overlay-container')
    overlay?.remove()
}
