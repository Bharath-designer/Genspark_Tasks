let data = []
const QUOTES_PER_PAGE = 5;
let currentIndex = 1

const fetchData = async () => {
    const rawData = await fetch(`https://dummyjson.com/quotes?limit=${QUOTES_PER_PAGE}&skip=${QUOTES_PER_PAGE * (currentIndex - 1)}`)
    data = await rawData.json()
}

const manipulateContainer = async () => {
    const quotesContainer = document.querySelector(".quotes")
    quotesContainer.innerHTML = "Loading quotes..."

    quotesContainer.innerHTML = ""
    data.quotes.forEach(quote => {
        const template = document.createElement("template")
        template.innerHTML = 
        `
            <div class="quote">
                    <span class="value">
                       ${quote.quote}
                    </span>
                    <span class="author">- ${quote.author}</span>
                </div>
        `

        quotesContainer.appendChild(template.content)
    })

}

fetchData()
.then(()=>{
    manipulateContainer()
})

const changePagination = async (option) => {
    clearInp()
    if (option === 'next') {
        currentIndex++
    } else {
        if (currentIndex == 1) return;
        currentIndex--
    }
    await fetchData()
    await manipulateContainer()
}


const clearInp = async () => {
    document.querySelector(".search-inp").value = ""
    await fetchData()
    await manipulateContainer()
}

const search = async () => {
    const searchText = document.querySelector(".search-inp").value

    const rawData = await fetch(`https://dummyjson.com/quotes`)
    const parsedData = await rawData.json()
    data = {quotes: parsedData.quotes.filter(element => element.quote.toLowerCase().includes(searchText.toLowerCase()) || element.author.toLowerCase().includes(searchText.toLowerCase()))}
    manipulateContainer();
}

