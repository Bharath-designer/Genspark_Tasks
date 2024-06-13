const products = [
    {
        name: "Mobile",
        price: "120,000",
        picture: "https://img.etimg.com/photo/msid-98945112,imgsize-13860/SamsungGalaxyS23Ultra.jpg",
        quantity: 10
    },
    {
        name: "Laptop",
        price: "250,000",
        picture: "https://images.firstpost.com/wp-content/uploads/2023/07/MacBook-Air-15-inch-Review-All-the-laptop-that-youll-ever-need-2.jpg",
        quantity: 32
    }
]

const createTableData = (data) => {
    const td = document.createElement("td");
    td.innerText = data
    return td;

}

const createTableImage = (data) => {
    const td = document.createElement("td");
    const img = document.createElement("img");
    td.appendChild(img)
    img.classList.add("product-img");
    img.src = data
    return td;
}

const productTable = document.querySelector(".product-table tbody");

const makeTable = () => {
    productTable.innerHTML = ""
    products.forEach((product, index) => {
        const tr = document.createElement("tr");
        tr.appendChild(createTableData(product.name))
        tr.appendChild(createTableData(product.price))
        tr.appendChild(createTableImage(product.picture))
        tr.appendChild(createTableData(product.quantity))
        productTable.appendChild(tr)
    })
}

makeTable()

const handleSubmit = (e) => {
    e.preventDefault()
    const errorElement = document.querySelector(".error-section");
    errorElement.innerHTML = ""

    const formdata = new FormData(e.target)
    const errorList = []

    for (let [key, value] of formdata.entries()) {
        console.log(value);
        if (value === "") {
            errorList.push(key)
        }

        if (typeof(value) === 'object' && value.name === "") {
            errorList.push(key)
        }
    }

    if (errorList.length > 0) {
        errorElement.textContent = `${errorList.join(", ")} field${errorList.length > 1 ? "s" : ""} missing`
        return;
    }

    const temp = {
        name: formdata.get('name'),
        price: formdata.get('price'),
        picture: URL.createObjectURL(formdata.get("image")),
        quantity: formdata.get('quantity'),
    }
    products.push(temp)
    makeTable()
    e.target.reset()
}


const toggleForm = () => {
    document.querySelector(".add-product-container").classList.toggle("collapsed")
}