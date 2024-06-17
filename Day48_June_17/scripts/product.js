const getProductDetailsById = async (id) => {

    const rawResult = await fetch("https://dummyjson.com/products/" + id)
    if (rawResult.ok) {
        const data = await rawResult.json()
        return data
    } else {
        return Promise.reject(rawResult.statusText)
    }
}

const detailsContainer = document.querySelector(".product-details-wrapper");

const updateDetails = async () => {
    const urlParams = new URLSearchParams(window.location.search);
    const data = await getProductDetailsById(urlParams.get('id'));
    detailsContainer.innerHTML = ""
    const template = document.createElement("template");
    template.innerHTML =
        `
            <div class="product-img">
                <img src="${data.thumbnail}" alt="">
            </div>
            <div class="title">${data.title}</div>
            <div class="desc">
                ${data.description}
            </div>
            <div class="tag-container">
                ${data.tags.reduce((prev,curr)=>{
                    return  `${prev}<div class="tag">${curr}</div>`
                },"")}
            </div>
            <div class="dimensions">
                <span class="dimension-title">Dimensions:</span> 
                <span>${data.dimensions.width}</span> X
                <span>${data.dimensions.height}</span> X
                <span>${data.dimensions.depth}</span>
            </div>
            <div class="return-policy">
                ${data.returnPolicy}
            </div>
            <div class="price">
                ₹ ${data.price}
            </div>
    `
    detailsContainer.appendChild(template.content)
}

updateDetails()