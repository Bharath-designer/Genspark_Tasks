import fetchData from './FetchData.js'
export const payNow = async (orderId) => {
    
    const data = await fetchData(`/api/payment/${orderId}`)
    alert("done")
}