import fetchData from "../utilities/FetchData.js"
import { makeActiveTab } from "../scripts/Profile.js"

const bindPaymentEventListener = () => {
    let payNowBtnList = document.querySelectorAll(".pay-now")
    payNowBtnList = Array.from(payNowBtnList)
    payNowBtnList.forEach(btn => {
        btn.addEventListener("click", async () => {
            const { orderId } = btn.dataset
            const data = await fetchData(`/api/payment/${orderId}`)
            location.href = data.paymentURL
        })
    })
}

const bindClientDecisionListener = () => {
    const actionBtns = document.querySelectorAll(".client-decision-btn")
    actionBtns.forEach(btn => {
        btn.addEventListener("click", async () => {
            const { quotationResponseId, quotationRequestId, decision } = btn.dataset
            await fetchData("/api/user/response", "POST", {
                quotationResponseId,
                clientDecision: decision
            })
            makeActiveTab("requestDetails", quotationRequestId)
        })
    })
}

const bindMarkAsCompletedListener = () => {
    const actionBtns = document.querySelectorAll(".mark-as-completed-btn")
    actionBtns.forEach(btn => {
        btn.addEventListener("click", async () => {
            const { scheduledEventId } = btn.dataset
            await fetchData(`/api/user/event/${scheduledEventId}`, "PUT")
        })
    })
}

export const requestDetailsMounted = async () => {
    bindPaymentEventListener()
    bindClientDecisionListener()
}

export const requestListMounted = (makeActiveTab) => {
    const requestItemsList = document.querySelectorAll("[data-quotation-request-id]")
    requestItemsList.forEach(element => {
        element.addEventListener("click", () => {
            makeActiveTab('requestDetails', element.dataset.quotationRequestId)
        })
    })
}

export const ordersMounted = () => {
    bindPaymentEventListener()
}

export const scheduledEventListMounted = () => {
    bindMarkAsCompletedListener()
    makeActiveTab("scheduledEvents")

}

export const adminScheduledEventListMounted = () => {
    bindMarkAsCompletedListener()
    makeActiveTab("adminScheduledEvents")
}

