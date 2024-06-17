const fetchData = async () => {
    const rawResult = await fetch("https://dummyjson.com/products?select=id,title,description,price,thumbnail")
    if(rawResult.ok) {
        const data = await rawResult.json()
        return data
    } else {
        return Promise.reject(rawResult.statusText)
    }
}

const productWrapper = document.querySelector(".product-wrapper");

const updateProductDetails = async () => {
    const data = await fetchData().catch(err=>console.log(err))
    productWrapper.innerHTML = ""
    data.products.forEach(product=>{
        
        const template = document.createElement("template")
        template.innerHTML = 
        `
            <div onclick="navigateToDetails(event)" data-id="${product.id}" class="product">
                <div class="left">
                    <img src="${product.thumbnail}" alt="">
                </div>
                <div class="right">
                    <div class="title">${product.title}</div>
                    <div class="desc">${product.description}</div>
                    <div class="price">₹${product.price}</div>
                </div>
            </div>
        `
        productWrapper.appendChild(template.content)
    })


}

const navigateToDetails = (e) => {
    const id = e.currentTarget.dataset.id
    const newUrl = 'product.html?id=' + id;
    location.href = newUrl
}


updateProductDetails()

