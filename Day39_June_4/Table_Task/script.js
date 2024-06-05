const products = [
    {
        name:"Mobile",
        price: "120,000",
        picture: "https://img.etimg.com/photo/msid-98945112,imgsize-13860/SamsungGalaxyS23Ultra.jpg",
        quantity: 10
    },
    {
        name:"Laptop",
        price: "250,000",
        picture: "https://images.firstpost.com/wp-content/uploads/2023/07/MacBook-Air-15-inch-Review-All-the-laptop-that-youll-ever-need-2.jpg",
        quantity: 32
    },
    {
        name:"Smart Watch",
        price: "8,999",
        picture: "https://images.samsung.com/is/image/samsung/p6pim/levant/2208/gallery/levant-galaxy-watch5-40mm-sm-r900nzsamea-thumb-533191093?$344_344_PNG$",
        quantity: 5
    },
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

products.forEach((product, index)=>{

    const tr = document.createElement("tr");
    tr.appendChild(createTableData(product.name))
    tr.appendChild(createTableData(product.price))
    tr.appendChild(createTableImage(product.picture))
    console.log(createTableImage(product.picture));
    tr.appendChild(createTableData(product.quantity))
    productTable.appendChild(tr)
})